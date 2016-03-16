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
    public static class UploadSonarMeasurementsNaarSlackTask
    { 
        public static async Task RunAsync(Uri endpointSonarQubeMeasurements, Uri slackEndpoint)
        {
            ISonarQubeSlackMessageFactory sonarQubeSlackMessageFactory = new SonarQubeSlackMessageFactory();
            ISlackIncomingWebhookMessageFactory slackIncomingWebhookMessageFactory = new SlackIncomingWebhookMessageFactory();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(endpointSonarQubeMeasurements);
                var responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);

                try
                {
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
