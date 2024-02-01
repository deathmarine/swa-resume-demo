using JMSWAResume.Models.Shared;

namespace JMSWAResume.Models.Pages
{
    public class CertificationModel
    {
        public static readonly string Path = "/content/certifications.json";
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
