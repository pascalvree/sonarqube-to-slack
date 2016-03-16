using ConsoleApplication1.Models;

namespace ConsoleApplication1.Factories.Interfaces
{
    public interface ISonarQubeSlackMessageFactory : IBaseFactory
    {
        SonarQubeSlackMessageModel Create(SonarQubeMetricModel sonarQubeMetric);
    }
}