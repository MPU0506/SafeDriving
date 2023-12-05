using SafeDriving.ViewModel;

namespace SafeDriving.Pages;

public partial class AccountPage : ContentPage
{
	public AccountPage(AccountViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}