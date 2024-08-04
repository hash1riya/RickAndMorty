using Microsoft.Extensions.Logging;
using RickAndMorty.View.CharactersDetailsPage;
using RickAndMorty.View.MainPage;
using RickAndMorty.ViewModel.CharDetailsViewModel;
using RickAndMorty.ViewModel.MainViewModel;

namespace RickAndMorty
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services
                .AddSingleton<MainPage>()
                .AddSingleton<MainViewModel>()
                .AddTransient<CharactersDetailsPage>()
                .AddTransient<CharDetailsViewModel>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
