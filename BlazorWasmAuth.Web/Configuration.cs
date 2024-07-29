using MudBlazor.Utilities;
using MudBlazor;

namespace BlazorWasmAuth.Web;

public static class Configuration
{
    public const string HttpClientName = "dima";
    public static string BackendUrl { get; set; } = string.Empty;

    public static MudTheme Theme = new MudTheme()
    {
        Typography = new Typography
        {
            Default = new Default()
            {
                FontFamily = new[] { "Raleway", "sans-serif" }
            }
        },
        Palette = new PaletteLight
        {
            Primary = new MudColor("#1565C0"), // Azul intermediário
            PrimaryContrastText = new MudColor("#FFFFFF"), // Contraste em branco
            Secondary = new MudColor("#64B5F6"), // Azul claro
            Background = new MudColor("#F5F5F5"), // Fundo claro
            AppbarBackground = new MudColor("#1565C0"), // Azul intermediário
            AppbarText = new MudColor("#FFFFFF"), // Texto da Appbar em branco
            TextPrimary = new MudColor("#000000"), // Texto primário em preto
            DrawerText = new MudColor("#000000"), // Texto da gaveta em preto
            DrawerBackground = new MudColor("#FFFFFF") // Fundo da gaveta em azul claro
        },
        PaletteDark = new PaletteDark
        {
            Primary = new MudColor("#1565C0"), // Azul intermediário
            Secondary = new MudColor("#64B5F6"), // Azul claro
            AppbarBackground = new MudColor("#1565C0"), // Fundo da barra de app em azul intermediário
            AppbarText = new MudColor("#FFFFFF"), // Texto da Appbar em branco
            PrimaryContrastText = new MudColor("#FFFFFF"), // Contraste em branco
            Background = new MudColor("#121212"), // Fundo escuro
            TextPrimary = new MudColor("#FFFFFF"), // Texto primário em branco
            DrawerText = new MudColor("#FFFFFF"), // Texto da gaveta em branco
            DrawerBackground = new MudColor("#1C1C1C") // Fundo da gaveta em cinza escuro
        }
    };

}