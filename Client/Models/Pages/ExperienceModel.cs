using System.ComponentModel.DataAnnotations;

namespace JMSWAResume.Models.Pages
{
    public class ExperienceModel
    {
        public static readonly string Path = "/content/experience.json";

        [Required]
        [StringLength(32, ErrorMessage = "Company length can't be less than 3 or more than 32.", MinimumLength = 3)]
        public string Company
        {
            get; set;
        }
        public string Position
        {
            get; set;
        }
        public string Period
        {
            get; set;
        }
        public string[] Description
        {
            get; set;
        }
        public string Color
        {
            get; set;
        }
        public string Image
        {
            get; set;
        }
        [Url]
        public string Video
        {
            get; set;
        }
        [Url]
        public string Link
        {
            get; set;
        }
        public string LinkTitle
        {
            get; set;
        }

        public ExperienceModel()
        {
            //Blank Constructor
        }

        public ExperienceModel(string company, string position, string period, string[] description, string color, string image, string video, string link, string linkTitle)
        {
            Company = company;
            Position = position;
            Period = period;
            Description = description;
            Color = color;
            Image = image;
            Video = video;
            Link = link;
            LinkTitle = linkTitle;
        }
    }
}
