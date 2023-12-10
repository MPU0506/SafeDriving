using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SafeDriving.Pages;
using SafeDriving.Service;
using SafeDriving.Service.API;
using SafeDriving.ViewModel;

namespace SafeDriving;

//меняю что то 
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

        builder.Services.AddSingleton<IApi>(p =>
        {
            return new PolytechApiService("https://e.mospolytech.ru/");
        });

        builder.Services.AddSingleton<UserService>();

        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<MainViewModel>();

        builder.Services.AddTransient<AccountPage>();
        builder.Services.AddTransient<AccountViewModel>();

        builder.Services.AddTransient<AuthPage>();
        builder.Services.AddTransient<AuthViewModel>();

        builder.Services.AddTransient<ChatPage>();
        builder.Services.AddTransient<ChatViewModel>();

        builder.Services.AddTransient<ListChatsPage>();
        builder.Services.AddTransient<ListChatsViewModel>();

        builder.Services.AddTransient<SchedulePage>();
        builder.Services.AddTransient<ScheduleViewModel>();




#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
