using LearningMauiPart10.Service;
using LearningMauiPart10.View;
using LearningMauiPart10.ViewModel;

namespace LearningMauiPart10;

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

        builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
        builder.Services.AddSingleton<IMap>(Map.Default);

        builder.Services.AddSingleton<ZipCodeService>();
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<ZipCodeDetailsViewModel>();
        builder.Services.AddTransient<ZipCodeDetailsPage>();
        

        return builder.Build();
	}
}
