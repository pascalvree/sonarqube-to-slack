using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using ConsoleApplication1.Factories;
using ConsoleApplication1.Factories.Interfaces;
using ConsoleApplication1.Models;

namespace ConsoleApplication1.Tasks
{
    /* van:
    [{
        "id": 3,
        "key": "ZOWonen:ZOWonen:2487B82B-554F-40F7-826B-3F0D2B1A5229",
        "name": "ZoWonen.Business",
        "scope": "PRJ",
        "qualifier": "BRC",
        "date": "2016-03-15T15:53:14+0100",
        "creationDate": "2015-10-08T14:07:39+0200",
        "lname": "ZoWonen.Business",
        "version": "0.1",
        "branch": "2487B82B-554F-40F7-826B-3F0D2B1A5229",
        "description": "",
        "msr": [{
            "key": "ncloc",
            "val": 3667.0,
            "frmt_val": "3,667"
        }]
    }]

    naar: { text: "{"project":"ZoWonen.Business","creationDate":"2015-10-08T14:07:39+0200","ncloc":"3,667","public_api":"769","duplicated_blocks":"4","complexity":"216","public_documented_api_density":"13.3%","statements":"568","functions":"128","files":"188","classes":"169","violations":"625"}" }
    */

    public static class UploadSonarMeasurementsNaarSlackTask
    { 
        public static async Task RunAsync(Uri endpointSonarQubeMeasurements, Uri slackEndpoint)
        {
            ISonarQubeSlackMessageFactory sonarQubeSlackMessageFactory = new SonarQubeSlackMessageFactory();
            ISlackIncomingWebhookMessageFactory slackIncomingWebhookMessageFactory = new SlackIncomingWebhookMessageFactory();

            using (var client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = await client.GetAsync(endpointSonarQubeMeasurements);
                    var responseBody = await response.Content.ReadAsStringAsync();

                    var serializer = new JavaScriptSerializer();
                    var sonarQubeMetrics = serializer.Deserialize<SonarQubeMetricModel[]>(responseBody).ToList();

                    var sonarQubeMetric = sonarQubeMetrics.First();
                    var sonarQubeSlackMessage = sonarQubeSlackMessageFactory.Create(sonarQubeMetric);

                    var slackIncomingWebhookMessage = slackIncomingWebhookMessageFactory.Create(sonarQubeSlackMessage);
                    var payload = new StringContent(serializer.Serialize(slackIncomingWebhookMessage));

                    await client.PostAsync(slackEndpoint, payload);
                }
                catch (InvalidOperationException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}