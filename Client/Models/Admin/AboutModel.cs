namespace JMSWAResume.Models.Admin
{
    public class AboutModel
    {
        public static readonly string Path = "/content/about.json";
        public string Header
        {
            get; set;
        }
        public string[] Sections
        {
            get; set;
        }
        public string Rights
        {
            get; set;
        }
        public string RightsLink
        {
            get; set;
        }
        public string Copyright
        {
            get; set;
        }

        public string ARMTemplateURL
        {
            get; set;
        }

        public string GitHubURL
        {
            get; set;
        }
        public Configuration Configuration
        {
            get; set;
        }
    }

    public class Configuration
    {
        public bool DisplayAwards
        {
            get; set;
        }
        public bool DisplayProjects
        {
            get; set;
        }
        public bool DisplayExperience
        {
            get; set;
        }
        public bool DisplayEducation
        {
            get; set;
        }
        public bool DisplayContact
        {
            get; set;
        }
        public bool DisplayBuild
        {
            get; set;
        }
        public static string[] GetAllProperties()
        {
            Type model = typeof(Configuration);
            List<string> names = new List<string>();
            foreach (var prop in model.GetProperties())
            {
                if (prop.PropertyType == typeof(string))
                {
                    names.Add(prop.Name);
                }
            }
            return names.ToArray();
        }
    }

}
