using SafeDriving.ViewModel;

namespace SafeDriving.Pages;

public partial class AuthPage : ContentPage
{
	public AuthPage(AuthViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}