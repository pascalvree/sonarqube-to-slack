using ConsoleApplication1.Models.Interfaces;

namespace ConsoleApplication1.Models
{
    public class SonarQubeSlackMessageModel : Model
    {
        public string project;
        public string creationDate;

        public string ncloc;
        public string public_api;
        public string duplicated_blocks;
        public string complexity;
        public string public_documented_api_density;
        public string statements;
        public string functions;
        public string files;
        public string classes;
        public string violations;
    }
}