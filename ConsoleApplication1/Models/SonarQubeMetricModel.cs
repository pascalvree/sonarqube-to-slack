using ConsoleApplication1.Models.Interfaces;

namespace ConsoleApplication1.Models
{
    public class SonarQubeMetricModel : Model
    {
        public string id;
        public string key;
        public string name;
        public string scope;
        public string qualifier;
        public string date;
        public string creationDate;
        public string lname;
        public string version;
        public string branch;
        public string description;

        public SonarQubeMsrModel[] msr;
    }
}