using JMSWAResume.Models.Shared;

namespace JMSWAResume.Models.Pages
{
    public class AwardModel
    {
        public static readonly string Path = "/content/awards.json";
        public string Title
        {
            get; set;
        }
        public string Description
        {
            get; set;
        }
        public LinkModel Link
        {
            get; set;
        }
        public int Year
        {
            get; set;
        }
        public string Organization
        {
            get; set;
        }

    }
}
