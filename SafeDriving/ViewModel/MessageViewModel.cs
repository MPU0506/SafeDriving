using CommunityToolkit.Mvvm.ComponentModel;

namespace SafeDriving.ViewModel
{
    public partial class MessageViewModel : ObservableObject
    {
        public string Body { get; set; }
        public DateTime DateTime { get; set; }

        [ObservableProperty]
        public string horizontal;
    }
}
