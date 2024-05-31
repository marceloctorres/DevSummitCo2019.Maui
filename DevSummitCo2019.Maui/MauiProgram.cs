using DevSummitCo2019.Maui.ViewModels;
using DevSummitCo2019.Maui.Views;

using Esri.ArcGISRuntime;
using Esri.ArcGISRuntime.Maui;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace DevSummitCo2019.Maui
{
  public static class MauiProgram
  {
    public static MauiApp CreateMauiApp()
    {
      var builder = MauiApp.CreateBuilder();
      var config = new ConfigurationBuilder()
        .AddUserSecrets(Assembly.GetExecutingAssembly())
        .Build();
      var ARCGIS_API_KEY = config["ArcGISRuntime:ApiKey"];

      builder
        .UseMauiApp<App>()
        .UseArcGISRuntime(config => config.UseApiKey(ARCGIS_API_KEY))
        .UsePrism(prism => prism
            .RegisterTypes(registry =>
            {
              registry.RegisterForNavigation<NavigationPage>();
              registry.RegisterForNavigation<MainPage, MainPageViewModel>();
            })
            .CreateWindow(async navigationService => await navigationService.NavigateAsync("NavigationPage/MainPage")))
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
