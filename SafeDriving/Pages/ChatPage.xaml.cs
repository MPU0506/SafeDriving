using SafeDriving.ViewModel;

namespace SafeDriving.Pages;

public partial class ChatPage : ContentPage
{
	public ChatPage(ChatViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }
}