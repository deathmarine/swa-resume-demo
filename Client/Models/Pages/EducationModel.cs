using System.ComponentModel.DataAnnotations;

namespace JMSWAResume.Models.Pages
{
    public class EducationModel
    {
        public static readonly string Path = "/content/education.json";

        [Required]
        [StringLength(32, ErrorMessage = "Name length can't be less than 3 or more than 32.", MinimumLength = 3)]
        public string Name
        {
            get; set;
        }
        public string Period
        {
            get; set;
        }
        public string Image
        {
            get; set;
        }
        public string Color
        {
            get; set;
        }
        public string Major
        {
            get; set;
        }
        public string Minor
        {
            get; set;
        }
        public string Location
        {
            get; set;
        }
        public string GPA
        {
            get; set;
        }
        public string[] Honors
        {
            get; set;
        }
        public EducationModel()
        {
            //Blank Constructor
        }

        public EducationModel(string name, string period, string image, string color, string major, string minor, string location, string gpa, string[] honors)
        {
            Name = name;
            Period = period;
            Image = image;
            Color = color;
            Major = major;
            Minor = minor;
            Location = location;
            GPA = gpa;
            Honors = honors;
        }

    }
}
