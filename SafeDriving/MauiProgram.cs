using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SafeDriving.Pages;
using SafeDriving.Service.API;
using SafeDriving.ViewModel;

namespace SafeDriving;

public static class MauiProgram
{
    private static readonly string _authToken = "0IwGWvhf%2Bd9UGa7wkj8qTyAM8vW86T7HPzV11B9GNLvxMTZgPEFWacFk%2BbO2lmIVpB4FZl3gw4Gl4vqwmhv0ZvDpXNe5XGYCIDnXsxi%2Ba74OZq1SuJFcSdEIbJ43v4CU8zWhSl4Wn1MG8EJNUiwHDy75090t7ym31uBCuOR2OyY%3D\\";

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

        builder.Services.AddTransient<IApi>(p =>
        {
            var api = new PolytechApiService("https://e.mospolytech.ru/");
            api.SetAuthToken(_authToken);
            return api;
        });

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
