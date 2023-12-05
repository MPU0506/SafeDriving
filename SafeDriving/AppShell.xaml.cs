using SafeDriving.Pages;

namespace SafeDriving;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(AccountPage), typeof(AccountPage));
        Routing.RegisterRoute(nameof(AuthPage), typeof(AuthPage));
        Routing.RegisterRoute(nameof(ChatPage), typeof(ChatPage));
        Routing.RegisterRoute(nameof(ListChatsPage), typeof(ListChatsPage));
        Routing.RegisterRoute(nameof(SchedulePage), typeof(SchedulePage));
    }
}
