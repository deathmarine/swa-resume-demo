using MudBlazor;
using MudBlazor.Utilities;

namespace JMSWAResume.Themes {
    public class CustomTheme : MudTheme{
        public CustomTheme() : base() {
            Palette = new PaletteLight {
                Black = new MudColor("#272c34"),
                White= new MudColor("#ffffff"),
                Primary = new MudColor("#2a2084"),
                PrimaryContrastText = new MudColor("#ffffff"),
                Secondary = new MudColor("#4135a9"),
                Info = new MudColor("#64a7e2"),
                Success = new MudColor("#2ECC40"),
                Warning = new MudColor("#FFC107"),
                Error = new MudColor("#FF0000"),
                TextPrimary = new MudColor("#242440"),
                TextSecondary = new MudColor("#2a622d"),
                Background = new MudColor("#f0f0f5"),
                BackgroundGrey = new MudColor("#f5f5f5"),
                Surface = new MudColor("#fcfcff"),
                Tertiary = new MudColor("#119220"),
                AppbarBackground = new MudColor("#393966"),
                
            };
            PaletteDark = new PaletteDark {
                Black = new MudColor("#272c34"),
                White = new MudColor("#ffffff"),
                Primary = new MudColor("#96bdd2"),
                Secondary = new MudColor("#7b9bac"),
                Info = new MudColor("#a4c2dd"),
                Success = new MudColor("#2ECC40"),
                Warning = new MudColor("#dc2d7e"),
                Error = new MudColor("#de2000"),
                TextPrimary = new MudColor("#E0E0E0"),
                TextSecondary = new MudColor("#BDBDBD"),
                AppbarBackground = new MudColor("#121212"),
                AppbarText = new MudColor("#E0E0E0"),
            };
            Typography = new CustomTypography();
        }
    }
}