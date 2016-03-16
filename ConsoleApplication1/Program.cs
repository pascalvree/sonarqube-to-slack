using System;
using ConsoleApplication1.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var slackEndpoint = new Uri("");

            const string endpointSonarQubeMeasurements = "";
            const string metrics = "";

            var endpointZowonenBusinessSonarQubeMeasurements = new Uri($"{endpointSonarQubeMeasurements}&resource=3&{metrics}");
            var endpointZowonenWebSonarQubeMeasurements = new Uri($"{endpointSonarQubeMeasurements}&resource=5&{metrics}");

            UploadSonarMeasurementsNaarSlackTask.RunAsync(endpointZowonenBusinessSonarQubeMeasurements, slackEndpoint);
            UploadSonarMeasurementsNaarSlackTask.RunAsync(endpointZowonenWebSonarQubeMeasurements, slackEndpoint);
        }
    }
}
