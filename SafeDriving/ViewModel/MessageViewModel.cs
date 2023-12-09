using CommunityToolkit.Mvvm.ComponentModel;

namespace SafeDriving.ViewModel
{
    public partial class MessageViewModel : ObservableObject
    {
        public string Body { get; set; }
        public string DateTime { get; set; }

        [ObservableProperty]
        public LayoutOptions layoutOptions;
    }
}
