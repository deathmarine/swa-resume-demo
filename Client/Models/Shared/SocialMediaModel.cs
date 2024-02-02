using JMSWAResume.Themes.Static;
using MudBlazor;
using System.Reflection;

namespace JMSWAResume.Models.Shared
{
    /// <summary>
    /// Be advised that this class uses reflection to get and set properties.
    /// This is not the most efficient way to do this, but it is the most dynamic.
    /// Changes to the personal.json file must be reflected here.
    /// </summary>
    /// 
    //Icon Link: https://www.mudblazor.com/features/icons#icons
    //Update the icons in the CustomIcons.cs file for extras.
    public class SocialMediaModel
    {
        public string Facebook
        {
            get; set;
        }
        public static string Facebook_Icon = Icons.Custom.Brands.Facebook;

        public string Instagram
        {
            get; set;
        }
        public static string Instagram_Icon = Icons.Custom.Brands.Instagram;

        public string LinkedIn
        {
            get; set;
        }
        public static string LinkedIn_Icon = Icons.Custom.Brands.LinkedIn;

        public string Github
        {
            get; set;
        }
        public static string Github_Icon = Icons.Custom.Brands.GitHub;

        public string StackOverflow
        {
            get; set;
        }
        public static string StackOverflow_Icon = Icons.Custom.Brands.StackOverflow;

        public string BitBucket
        {
            get; set;
        }
        public static string BitBucket_Icon = CustomIcons.BitBucket_Logo;

        public string Twitter
        {
            get; set;
        }
        public static string Twitter_Icon = Icons.Custom.Brands.Twitter;

        public string YouTube
        {
            get; set;
        }
        public static string YouTube_Icon = Icons.Custom.Brands.YouTube;

        public string Vimeo
        {
            get; set;
        }
        public static string Vimeo_Icon = Icons.Custom.Brands.Vimeo;

        public string TikTok
        {
            get; set;
        }
        public static string TikTok_Icon = Icons.Custom.Brands.TikTok;

        public string WhatsApp
        {
            get; set;
        }
        public static string WhatsApp_Icon = Icons.Custom.Brands.WhatsApp;

        public string Skype
        {
            get; set;
        }
        public static string Skype_Icon = CustomIcons.Skype_Logo;

        public string Slack
        {
            get; set;
        }
        public static string Slack_Icon = CustomIcons.Slack_Logo;

        public string Discord
        {
            get; set;
        }
        public static string Discord_Icon = Icons.Custom.Brands.Discord;

        public string Reddit
        {
            get; set;
        }
        public static string Reddit_Icon = Icons.Custom.Brands.Reddit;

        public string Twitch
        {
            get; set;
        }
        public static string Twitch_Icon = CustomIcons.Twitch_Logo;

        public string Steam
        {
            get; set;
        }
        public static string Steam_Icon = CustomIcons.Steam_Logo;

        public string Xbox
        {
            get; set;
        }
        public static string Xbox_Icon = CustomIcons.Xbox_Logo;


        public string Email
        {
            get; set;
        }
        public static string Email_Icon = Icons.Material.Filled.Email;

        public string Phone
        {
            get; set;
        }
        public static string Phone_Icon = Icons.Material.Filled.Phone;

        public string GetPropertyValue(string name)
        {
            Type _type = typeof(SocialMediaModel);
            foreach (var prop in _type.GetProperties())
            {
                if (prop.Name == name)
                {
                    return (string)prop.GetValue(this);
                }
            }
            return null;
        }

        public static string[] GetAllProperties()
        {
            Type model = typeof(SocialMediaModel);
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
        public void SetProperty(string name, string value)
        {
            Type _type = typeof(SocialMediaModel);
            foreach (var prop in _type.GetProperties())
            {
                if (prop.Name == name)
                {
                    prop.SetValue(this, value);
                }
            }
        }
        public static void SetProperty(SocialMediaModel model, string name, string value)
        {
            Type _type = typeof(SocialMediaModel);
            foreach (var prop in _type.GetProperties())
            {
                if (prop.Name == name)
                {
                    prop.SetValue(model, value);
                }
            }
        }

        public string GetIcon(string name)
        {
            Type _type = typeof(SocialMediaModel);
            foreach (var item in _type.GetRuntimeFields())
            {
                if (item.Name.StartsWith(name) && item.Name.EndsWith("Icon"))
                {
                    return item.GetValue(this) as string;
                }
            }
            return null;
        }
        public static string GetIcon(SocialMediaModel model, string name)
        {
            Type _type = typeof(SocialMediaModel);
            foreach (var prop in _type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (prop.Name.StartsWith(name) && prop.Name.EndsWith("Icon"))
                {
                    return prop.GetValue(model) as string;
                }
            }
            return null;
        }
    }
}
