using SafeDriving.ViewModel;

namespace SafeDriving.Pages;

public partial class ListChatsPage : ContentPage
{
	public ListChatsPage(ListChatsViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}