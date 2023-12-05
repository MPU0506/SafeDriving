using SafeDriving.ViewModel;

namespace SafeDriving;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}

