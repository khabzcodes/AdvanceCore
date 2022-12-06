using AdvanceCore.UI.Data;
using Microsoft.AspNetCore.Components.WebView.Maui;

namespace AdvanceCore.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>();

            builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif
            builder.Services.AddAntDesign();

            builder.Services.AddSingleton<WeatherForecastService>();

            return builder.Build();
        }
    }
}