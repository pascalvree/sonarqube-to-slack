using System.Web.Script.Serialization;
using ConsoleApplication1.Factories.Interfaces;
using ConsoleApplication1.Models;

namespace ConsoleApplication1.Factories
{
    class SlackIncomingWebhookMessageFactory : ISlackIncomingWebhookMessageFactory
    {
        private readonly JavaScriptSerializer serializer;

        public SlackIncomingWebhookMessageFactory()
        {
            serializer = new JavaScriptSerializer();
        }

        public SlackIncomingWebhookMessageModel Create(SonarQubeSlackMessageModel sonarQubeSlackMessage)
        {
            return new SlackIncomingWebhookMessageModel() { text = serializer.Serialize(sonarQubeSlackMessage) };
        }
    }
}