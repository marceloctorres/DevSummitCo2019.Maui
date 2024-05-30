using DevSummitCo2019.Maui.ViewModels;
using DevSummitCo2019.Maui.Views;

using Esri.ArcGISRuntime;
using Esri.ArcGISRuntime.Maui;

using Microsoft.Extensions.Logging;

namespace DevSummitCo2019.Maui
{
  public static class MauiProgram
  {
    public static MauiApp CreateMauiApp()
    {
      var builder = MauiApp.CreateBuilder();
      builder
        .UseMauiApp<App>()
        .UseArcGISRuntime(config => config.UseApiKey("AAPKc5e8d836cf334edd9063202b7a6c116diWf_PrnwqMwic9YnQGvcD-ZR09TKiYFW4qgKLLmOrgX3oHQXTeWGcsWS-A-5azVW"))
        .UsePrism(prism =>
        {
          prism
            .RegisterTypes(registry =>
            {
              registry.RegisterForNavigation<NavigationPage>();
              registry.RegisterForNavigation<MainPage, MainPageViewModel>();
            })
            .CreateWindow(async navigationService => await navigationService.NavigateAsync("NavigationPage/MainPage"));
        })
        .ConfigureFonts(fonts =>
        {
          fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
          fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        });

#if DEBUG
  		builder.Logging.AddDebug();
#endif

      return builder.Build();
    }
  }
}
