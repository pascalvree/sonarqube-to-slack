using System.Linq;
using ConsoleApplication1.Factories.Interfaces;
using ConsoleApplication1.Mappings;
using ConsoleApplication1.Mappings.Interfaces;
using ConsoleApplication1.Models;

namespace ConsoleApplication1.Factories
{
    class SonarQubeSlackMessageFactory : ISonarQubeSlackMessageFactory
    {
        private readonly ISonarToSlackMapping mapping;

        public SonarQubeSlackMessageFactory()
        {
            this.mapping = new SonarToSlackMapping();
        }

        public SonarQubeSlackMessageModel Create(SonarQubeMetricModel sonarQubeMetric)
        {
            var sonarQubeSlackMessage = new SonarQubeSlackMessageModel();
            mapping.Apply(sonarQubeMetric, sonarQubeSlackMessage);
            sonarQubeMetric.msr.ToList().ForEach(
                measurement => mapping.Apply(measurement, sonarQubeSlackMessage)
            );

            return sonarQubeSlackMessage;
        }
    }
}