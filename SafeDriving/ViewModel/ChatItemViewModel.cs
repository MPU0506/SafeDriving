using CommunityToolkit.Mvvm.ComponentModel;

namespace SafeDriving.ViewModel
{
    public partial class ChatItemViewModel : ObservableObject
    {
        public int Id { get; set; }

        [ObservableProperty]
        string chatName;

        [ObservableProperty]
        string lastMessage;
    }
}
