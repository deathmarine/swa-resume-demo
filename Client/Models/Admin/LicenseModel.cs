using System.Globalization;
using System.Text.RegularExpressions;

namespace JMSWAResume.Models.Admin
{
    public class LicenseModel
    {
        public static readonly string Path = "/content/LICENSE";
        public string license
        {
            get; set;
        }
        public string head
        {
            get; set;
        }
        public string version
        {
            get; set;
        }
        public string date
        {
            get; set;
        }
        public string copyright
        {
            get; set;
        }

        public LicenseModel(string license)
        {
            this.license = license;
            //Example of unnessesary complexity: License parsing
            var lines = license.Split('\n');
            head = lines[0];
            version = lines[1].Split(",")[0];
            var _date = DateTime.ParseExact(lines[1].Split(",")[1].Trim(), "dd MMMM yyyy", CultureInfo.CreateSpecificCulture("en-US"), DateTimeStyles.None);
            date = _date.ToString("MMMM dd, yyyy"); //Why, with the perfectionism?
            copyright = Regex.Replace(lines[3], "<.*?>", "");
            lines = null; //Clear for memory
                          //Asking for giveness from GC for the sake of this code
        }
    }
}
