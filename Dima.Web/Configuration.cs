using MudBlazor;
using MudBlazor.Utilities;

namespace Dima.Web;

public static class Configuration
{
    public const string HttpClientName = "dima";
    public static string BackendUrl { get; set; } 
    
    public static MudTheme Theme = new()
    {
        Typography = new Typography
        {
            Default = new DefaultTypography
            {
                FontFamily = ["Raleway", "sans-serif"]
            }
        },

        PaletteLight = new PaletteLight
        {
            Primary = new MudColor("#c9aaff"),
            PrimaryContrastText =  new MudColor("#FFFFFF"),
            Secondary = new MudColor("#000000"),
            SecondaryContrastText =   new MudColor("#FFFFFF"),
            Background = Colors.Gray.Lighten4,
            AppbarBackground = new MudColor("#6a4c9f"),
            AppbarText = Colors.Shades.White,
            TextPrimary = Colors.Shades.Black,
            DrawerText = Colors.Shades.White,
            DrawerBackground = new MudColor("#6a4c9f"),
            
        },

        PaletteDark = new PaletteDark
        {
            Primary = new MudColor("#6a4c9f"),
            PrimaryContrastText =  new  MudColor("#000000"),
            Secondary = Colors.Purple.Accent1,
            AppbarBackground = new MudColor("#6a4c9f"),
            AppbarText = Colors.Shades.White
            
        },
    };
}