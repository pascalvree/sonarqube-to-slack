using ConsoleApplication1.Models;

namespace ConsoleApplication1.Mappings.Interfaces
{
    public interface ISonarToSlackMapping
    {
        void Apply(SonarQubeMetricModel sonarQubeMetric, SonarQubeSlackMessageModel sonarQubeSlackMessage);
        void Apply(SonarQubeMsrModel measurement, SonarQubeSlackMessageModel sonarQubeSlackMessage);
    }
}