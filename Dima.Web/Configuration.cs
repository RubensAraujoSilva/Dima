using MudBlazor;
using MudBlazor.Utilities;

namespace Dima.Web;

public static class Configuration
{
    public const string HttpClientName = "dima";
    public static string BackendUrl { get; set; }

    public static readonly MudTheme Theme = new()
    {
        PaletteLight = new PaletteLight()
        {
            GrayDarker = "#374151",
            GrayDark = "#4b5563",
            GrayDefault = "#6b7280",
            GrayLight = "#9ca3af",
            GrayLighter = "#d1d5db",

            // Surfaces & Backgrounds
            Surface = "#ffffff",
            Background = "#f9fafb",
            BackgroundGray = "#f3f4f6",
            DrawerBackground = "#f3f4f6",
            AppbarBackground = "#6A4C9F",

            // Lines & Dividers
            LinesInputs = "#d1d5db",
            TableLines = "#e5e7eb",
            Divider = "#e5e7eb",
            DividerLight = "#f3f4f6",
            TableStriped = "rgba(243, 244, 246, 0.5)",
            TableHover = "rgba(243, 244, 246, 1)",

            // Suas cores de marca originais
            Primary = "#6a4c9f",
            PrimaryDarken = "#523b7b",       
            PrimaryLighten = "#e2d4f5",      
            PrimaryContrastText = "#ffffff",
            Secondary = "#000000",
            SecondaryDarken = "#8976ab",
            SecondaryLighten = "#eee9f6",
            SecondaryContrastText = "#333333",
            Tertiary = "rgba(68, 68, 68, 0.5)",
            TertiaryDarken = "rgba(68, 68, 68, 0.5)",
            TertiaryLighten = "rgba(68, 68, 68, 0.5)",
            TertiaryContrastText = "#fafafa",
            Info = "#009cdc",
            InfoDarken = "#003e58",
            InfoLighten = "#ccebf8",
            InfoContrastText = "#ccebf8",
            Success = "#00cc62",
            SuccessDarken = "#00994a",       
            SuccessLighten = "#ccf4df",      
            SuccessContrastText = "#ffffff",
            Warning = "#efa31d",
            WarningDarken = "#60410c",
            WarningLighten = "#fcedd2",
            WarningContrastText = "#fcedd2",
            Error = "rgba(244,67,54,1)",
            ErrorDarken = "rgb(242,28,13)",
            ErrorLighten = "rgb(246,96,85)",
            ErrorContrastText = "rgba(255,255,255,1)",

            // Textos
            TextPrimary = "#111827",
            TextSecondary = "#4b5563",
            TextDisabled = "#9ca3af",
            AppbarText = "#ffffff",
            DrawerText = "#4b5563",
            DrawerIcon = "#4b5563",

            // Outros
            Dark = "#17141f",
            DarkDarken = "rgb(46,46,46)",
            DarkLighten = "rgb(87,87,87)",
            DarkContrastText = "#cbc8d0",
            Black = "#000000",
            White = "#ffffff",
            ActionDefault = "#523b7b", //Hover
            ActionDisabled = "rgba(107, 114, 128, 0.5)",
            ActionDisabledBackground = "rgba(243, 244, 246, 1)",
            HoverOpacity = 0.08,
            RippleOpacity = 0.1,
            RippleOpacitySecondary = 0.2,
            OverlayLight = "rgba(255,255,255,0.5)",
            OverlayDark = "rgba(17, 24, 39, 0.5)",
        },
        PaletteDark = new PaletteDark()
        {
            Surface = "#1f2937",
            Background = "#111827",
            BackgroundGray = "#374151",
            DrawerBackground = "#1f2937",
            AppbarBackground = "#111827",

            LinesInputs = "#4b5563",
            TableLines = "#374151",
            Divider = "#374151",
            DividerLight = "#4b5563",
            TableStriped = "rgba(55, 65, 81, 0.5)",

            TextPrimary = "#f9fafb",
            TextSecondary = "#9ca3af",
            TextDisabled = "#6b7280",
            DrawerText = "#d1d5db",
            DrawerIcon = "#9ca3af",

            Primary = "#593196",
            PrimaryDarken = "#9b83c0",
            PrimaryLighten = "#120a1e",
            PrimaryContrastText = "#cececeff",
            Secondary = "#c8b8e8ff",
            SecondaryDarken = "#cbbde5",
            SecondaryLighten = "#221d2a",
            SecondaryContrastText = "#221d2a",
            Tertiary = "rgba(237, 237, 237, 0.5)",
            TertiaryDarken = "rgba(237, 237, 237, 0.5)",
            TertiaryLighten = "rgba(237, 237, 237, 0.5)",
            TertiaryContrastText = "#262730",
            Info = "#009cdc",
            InfoDarken = "#66c4ea",
            InfoLighten = "#001f2c",
            InfoContrastText = "#001f2c",
            Success = "#13b955",
            SuccessDarken = "#71d599",
            SuccessLighten = "#042511",
            SuccessContrastText = "#042511",
            Warning = "#efa31d",
            WarningDarken = "#f5c877",
            WarningLighten = "#302106",
            WarningContrastText = "#302106",
            Error = "rgba(244,67,54,1)",
            ErrorDarken = "rgb(242,28,13)",
            ErrorLighten = "rgb(246,96,85)",
            ErrorContrastText = "rgba(255,255,255,1)",

            Dark = "#17141f",
            DarkDarken = "rgb(23,23,28)",
            DarkLighten = "rgb(56,56,67)",
            DarkContrastText = "#ebebebff",
            Black = "#000000",
            White = "#ffffff",
            ActionDefault = "#9ca3af",
            ActionDisabled = "rgba(156, 163, 175, 0.5)",
            ActionDisabledBackground = "rgba(55, 65, 81, 1)",
        },
        Shadows = new Shadow()
        {
            // Margem de segurança de índices para garantir que nenhuma versão do MudBlazor jogue IndexOutOfRange
            Elevation = new string[]
            {
                "none", // 0
                "0 1px 2px 0 rgba(0, 0, 0, 0.05)", // 1  (Tailwind sm)
                "0 1px 3px 0 rgba(0, 0, 0, 0.1), 0 1px 2px -1px rgba(0, 0, 0, 0.1)", // 2  (Tailwind default)
                "0 1px 3px 0 rgba(0, 0, 0, 0.1), 0 1px 2px -1px rgba(0, 0, 0, 0.1)", // 3  
                "0 4px 6px -1px rgba(0, 0, 0, 0.1), 0 2px 4px -2px rgba(0, 0, 0, 0.1)", // 4  (Tailwind md)
                "0 4px 6px -1px rgba(0, 0, 0, 0.1), 0 2px 4px -2px rgba(0, 0, 0, 0.1)", // 5  
                "0 4px 6px -1px rgba(0, 0, 0, 0.1), 0 2px 4px -2px rgba(0, 0, 0, 0.1)", // 6  
                "0 4px 6px -1px rgba(0, 0, 0, 0.1), 0 2px 4px -2px rgba(0, 0, 0, 0.1)", // 7  
                "0 10px 15px -3px rgba(0, 0, 0, 0.1), 0 4px 6px -4px rgba(0, 0, 0, 0.1)", // 8  (Tailwind lg)
                "0 10px 15px -3px rgba(0, 0, 0, 0.1), 0 4px 6px -4px rgba(0, 0, 0, 0.1)", // 9  
                "0 10px 15px -3px rgba(0, 0, 0, 0.1), 0 4px 6px -4px rgba(0, 0, 0, 0.1)", // 10 
                "0 10px 15px -3px rgba(0, 0, 0, 0.1), 0 4px 6px -4px rgba(0, 0, 0, 0.1)", // 11 
                "0 20px 25px -5px rgba(0, 0, 0, 0.1), 0 8px 10px -6px rgba(0, 0, 0, 0.1)", // 12 (Tailwind xl)
                "0 20px 25px -5px rgba(0, 0, 0, 0.1), 0 8px 10px -6px rgba(0, 0, 0, 0.1)", // 13 
                "0 20px 25px -5px rgba(0, 0, 0, 0.1), 0 8px 10px -6px rgba(0, 0, 0, 0.1)", // 14 
                "0 20px 25px -5px rgba(0, 0, 0, 0.1), 0 8px 10px -6px rgba(0, 0, 0, 0.1)", // 15 
                "0 25px 50px -12px rgba(0, 0, 0, 0.25)", // 16 (Tailwind 2xl)
                "0 25px 50px -12px rgba(0, 0, 0, 0.25)", // 17 
                "0 25px 50px -12px rgba(0, 0, 0, 0.25)", // 18 
                "0 25px 50px -12px rgba(0, 0, 0, 0.25)", // 19 
                "0 25px 50px -12px rgba(0, 0, 0, 0.25)", // 20 
                "0 25px 50px -12px rgba(0, 0, 0, 0.25)", // 21 
                "0 25px 50px -12px rgba(0, 0, 0, 0.25)", // 22 
                "0 25px 50px -12px rgba(0, 0, 0, 0.25)", // 23 
                "0 25px 50px -12px rgba(0, 0, 0, 0.25)", // 24
                "0 25px 50px -12px rgba(0, 0, 0, 0.25)", // 25
                "0 25px 50px -12px rgba(0, 0, 0, 0.25)", // 26
                "0 25px 50px -12px rgba(0, 0, 0, 0.25)", // 27
                "0 25px 50px -12px rgba(0, 0, 0, 0.25)", // 28
                "0 25px 50px -12px rgba(0, 0, 0, 0.25)" // 29
            }
        },
        LayoutProperties = new LayoutProperties()
        {
            AppbarHeight = "45px",
            DefaultBorderRadius = "5px",
            DrawerMiniWidthLeft = "56px",
            DrawerMiniWidthRight = "56px",
            DrawerWidthLeft = "240px",
            DrawerWidthRight = "240px",
        },
        Typography = new Typography()
        {
            Default = new DefaultTypography
            {
                FontFamily =
                [
                    "Inter", "ui-sans-serif", "system-ui", "-apple-system", "BlinkMacSystemFont", "Segoe UI", "Roboto",
                    "Helvetica Neue", "Arial", "sans-serif"
                ],
                FontWeight = "400",
                FontSize = ".875rem",
                LineHeight = "1.5",
                LetterSpacing = "normal",
                TextTransform = "none",
            },
            H1 = new H1Typography
            {
                FontWeight = "800", FontSize = "4.5rem", LineHeight = "1", LetterSpacing = "-0.025em",
                TextTransform = "none"
            },
            H2 = new H2Typography
            {
                FontWeight = "700", FontSize = "3.75rem", LineHeight = "1", LetterSpacing = "-0.025em",
                TextTransform = "none"
            },
            H3 = new H3Typography
            {
                FontWeight = "700", FontSize = "3rem", LineHeight = "1", LetterSpacing = "-0.025em",
                TextTransform = "none"
            },
            H4 = new H4Typography
            {
                FontWeight = "600", FontSize = "2.25rem", LineHeight = "2.5rem", LetterSpacing = "-0.025em",
                TextTransform = "none"
            },
            H5 = new H5Typography
            {
                FontWeight = "600", FontSize = "1.5rem", LineHeight = "2rem", LetterSpacing = "normal",
                TextTransform = "none"
            },
            H6 = new H6Typography
            {
                FontWeight = "600", FontSize = "1.25rem", LineHeight = "1.75rem", LetterSpacing = "normal",
                TextTransform = "none"
            },
            Subtitle1 = new Subtitle1Typography
            {
                FontWeight = "400", FontSize = "1rem", LineHeight = "1.5", LetterSpacing = "normal",
                TextTransform = "none"
            },
            Subtitle2 = new Subtitle2Typography
            {
                FontWeight = "400", FontSize = ".875rem", LineHeight = "1.25", LetterSpacing = "normal",
                TextTransform = "none"
            },
            Body1 = new Body1Typography
            {
                FontWeight = "400", FontSize = "1rem", LineHeight = "1.5", LetterSpacing = "normal",
                TextTransform = "none"
            },
            Body2 = new Body2Typography
            {
                FontWeight = "400", FontSize = ".875rem", LineHeight = "1.25", LetterSpacing = "normal",
                TextTransform = "none"
            },
            Button = new ButtonTypography
            {
                FontWeight = "500", FontSize = ".875rem", LineHeight = "1.5", LetterSpacing = "normal",
                TextTransform = "none"
            },
            Caption = new CaptionTypography
            {
                FontWeight = "400", FontSize = ".75rem", LineHeight = "1rem", LetterSpacing = "normal",
                TextTransform = "none"
            },
            Overline = new OverlineTypography
            {
                FontWeight = "300", FontSize = ".75rem", LineHeight = "1rem", LetterSpacing = "0.05em",
                TextTransform = "uppercase"
            },
        },
        ZIndex = new ZIndex()
        {
            AppBar = 1300,
            Dialog = 1400,
            Drawer = 1100,
            Popover = 1200,
            Snackbar = 1500,
            Tooltip = 1600,
        },
    };

}