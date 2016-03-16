using ConsoleApplication1.Models;

namespace ConsoleApplication1.Factories.Interfaces
{
    public interface ISlackIncomingWebhookMessageFactory : IBaseFactory
    {
        SlackIncomingWebhookMessageModel Create(SonarQubeSlackMessageModel sonarQubeSlackMessage);
    }
}