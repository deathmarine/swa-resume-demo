using MudBlazor;
using MudBlazor.Utilities;
using System.ComponentModel;
using static MudBlazor.CategoryTypes;

namespace JMSWAResume.Themes {
    public class CustomTypography: Typography {
        /*
        h1 { font-family: "Segoe UI"; font-size: 23px; font-style: normal; font-variant: normal; font-weight: 700; line-height: 23px; } 
        h3 { font-family: "Segoe UI"; font-size: 17px; font-style: normal; font-variant: normal; font-weight: 700; line-height: 23px; } 
        p { font-family: "Segoe UI"; font-size: 14px; font-style: normal; font-variant: normal; font-weight: 400; line-height: 23px; } 
        blockquote { font-family: "Segoe UI"; font-size: 17px; font-style: normal; font-variant: normal; font-weight: 400; line-height: 23px; } 
        pre { font-family: "Segoe UI"; font-size: 11px; font-style: normal; font-variant: normal; font-weight: 400; line-height: 23px; }
         */
        public static string[] TitleFamily = {
            "Segoe UI", "Tahoma", "Geneva", "Verdana", "sans-serif"
        };
        public static string[] FontFamilyCustom = {
            "Segoe UI", "Roboto", "Helvetica Neue", "Arial", "sans-serif"
        };
        public static string[] FontFamilyDefault = {
            "Roboto", "RobotoDraft", "Helvetica", "Arial", "sans-serif"
        };
        public static string[] FontFamilyMonospace = {
            "Consolas", "Menlo",  "Courier New", "monospace"
        };
        public static string[] FontFamilyNumeric = {
            "Roboto Mono", "monospace"
        };
        public CustomTypography() : base() {
            Default = new Default {
                FontFamily = TitleFamily, //Change this to your font stack
                FontSize = ".875rem",
                LineHeight = 1.43,
                FontWeight = 500,
                LetterSpacing = "0.01071em",
            };
        }

        public List<string[]> GetFontFamilies() {
            return new List<string[]> {
                FontFamilyCustom,
                FontFamilyDefault,
                FontFamilyMonospace,
                FontFamilyNumeric
            };
        }

        public BaseTypography GetTagByName(string tag) {
            switch (tag) {
                case "H1":
                    return H1;
                case "H2":
                    return H2;
                case "H3":
                    return H3;
                case "H4":
                    return H4;
                case "H5":
                    return H5;
                case "H6":
                    return H6;
                case "Subtitle1":
                    return Subtitle1;
                case "Subtitle2":
                    return Subtitle2;
                case "Body1":
                    return Body1;
                case "Body2":
                    return Body2;
                case "Caption":
                    return Caption;
                case "Button":
                    return Button;
                case "Overline":
                    return Overline;
                default:
                    return Default;
            }
        }
        public object GetBaseValueFromTypography(string tag, BaseTypography typography) {
            switch (tag) {
                case "FontFamily":
                    return typography.FontFamily;
                case "FontSize":
                    return typography.FontSize;
                case "FontWeight":
                    return typography.FontWeight;
                case "LetterSpacing":
                    return typography.LetterSpacing;
                case "LineHeight":
                    return typography.LineHeight;
                case "TextTransform":
                    return typography.TextTransform;
                default:
                    return null;
            }
        }
    }
}