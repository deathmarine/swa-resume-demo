using JMSWAResume.Models.Shared;

namespace JMSWAResume.Models.Pages
{
    public class ProjectModel
    {
        public static readonly string Path = "/content/projects.json";
        public string Name
        {
            get; set;
        }
        public string Image
        {
            get; set;
        }
        public string[] Description
        {
            get; set;
        }
        public LinkModel[] Links
        {
            get; set;
        }
        public string[] Details
        {
            get; set;
        }

    }
}
