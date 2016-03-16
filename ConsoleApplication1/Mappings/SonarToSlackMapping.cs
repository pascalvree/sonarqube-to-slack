using ConsoleApplication1.Mappings.Interfaces;
using ConsoleApplication1.Models;

namespace ConsoleApplication1.Mappings
{
    class SonarToSlackMapping : ISonarToSlackMapping
    {
        public void Apply(SonarQubeMetricModel sonarQubeMetric, SonarQubeSlackMessageModel sonarQubeSlackMessage)
        {
            sonarQubeSlackMessage.creationDate = sonarQubeMetric.creationDate;
            sonarQubeSlackMessage.project = sonarQubeMetric.name;
        }

        public void Apply(SonarQubeMsrModel measurement, SonarQubeSlackMessageModel sonarQubeSlackMessage)
        { 
            switch (measurement.key)
            {
                case "ncloc":
                    sonarQubeSlackMessage.ncloc = measurement.frmt_val;
                    break;

                case "public_api":
                    sonarQubeSlackMessage.public_api = measurement.frmt_val;
                    break;

                case "duplicated_blocks":
                    sonarQubeSlackMessage.duplicated_blocks = measurement.frmt_val;
                    break;

                case "complexity":
                    sonarQubeSlackMessage.complexity = measurement.frmt_val;
                    break;

                case "public_documented_api_density":
                    sonarQubeSlackMessage.public_documented_api_density = measurement.frmt_val;
                    break;

                case "statements":
                    sonarQubeSlackMessage.statements = measurement.frmt_val;
                    break;

                case "functions":
                    sonarQubeSlackMessage.functions = measurement.frmt_val;
                    break;

                case "classes":
                    sonarQubeSlackMessage.classes = measurement.frmt_val;
                    break;

                case "files":
                    sonarQubeSlackMessage.files = measurement.frmt_val;
                    break;

                case "violations":
                    sonarQubeSlackMessage.violations = measurement.frmt_val;
                    break;
            }
        }
    }
}