using System;
using ConsoleApplication1.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var slackEndpoint = new Uri("https://hooks.slack.com/services/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");

            const string endpointSonarQubeMeasurements = "http://zow-dev1:9000/api/resources?depth=0";
            const string metrics = "metrics=ncloc,public_api,duplicated_blocks,complexity,public_documented_api_density,statements,functions,files,classes,violations";

            var endpointZowonenBusinessSonarQubeMeasurements = new Uri($"{endpointSonarQubeMeasurements}&resource=3&{metrics}");
            var endpointZowonenWebSonarQubeMeasurements = new Uri($"{endpointSonarQubeMeasurements}&resource=5&{metrics}");

            UploadSonarMeasurementsNaarSlackTask.RunAsync(endpointZowonenBusinessSonarQubeMeasurements, slackEndpoint).Wait();
            UploadSonarMeasurementsNaarSlackTask.RunAsync(endpointZowonenWebSonarQubeMeasurements, slackEndpoint).Wait();
        }
    }
}