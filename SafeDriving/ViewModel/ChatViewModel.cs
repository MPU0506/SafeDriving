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
                    DateTime = DateTime.Now,
                    Horizontal = "Start",
                },
                new MessageViewModel
                {
                    Body = "Здарова",
                    DateTime = DateTime.Now.AddMinutes(1),
                    Horizontal = "End",
                },
                 new MessageViewModel
                {
                    Body = "AKLSDJFKLASDJFLKJASDLKFJLASDKJFLKASDJFLKAJSDDLFKJASDLKFJSLADKJFLAKSDJFLKASDJFLKJASDLKFJASDLKJFKL",
                    DateTime = DateTime.Now.AddMinutes(1),
                    Horizontal = "Start",
                },
            };

            Messages = new(list);
        }
    }
}
