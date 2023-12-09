using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
namespace SafeDriving.ViewModel
{
    public partial class ChatViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<MessageViewModel> messages;

        public ChatViewModel() 
        {
            var list = new List<MessageViewModel>
            {
                new MessageViewModel
                {
                    Body = "Привет",
                    DateTime = "23:12",
                    LayoutOptions = LayoutOptions.Start,
                },
                new MessageViewModel
                {
                    Body = "Здарова",
                    DateTime = "23:13",
                   LayoutOptions = LayoutOptions.End,
                },
                 new MessageViewModel
                {
                    Body = "AKLSDJFKLASDJFLKJASDLKFJLASDKJFLKASDJFLKAJSDDLFKJASDLKFJSLADKJFLAKSDJFLKASDJFLKJASDLKFJASDLKJFKL",
                    DateTime = "23:16",
                    LayoutOptions = LayoutOptions.Start,
                },
                  new MessageViewModel
                {
                    Body = "AKLSDJFKLASDJFLKJASDLKFJLASDKJFLKASDJFLKAJSDDLFKJASDLKFJSLADKJFLAKSDJFLKASDJFLKJASDLKFJASDLKJFKL",
                    DateTime = "23:18",
                    LayoutOptions = LayoutOptions.End,
                },
            };

            Messages = new(list);
        }
    }
}
