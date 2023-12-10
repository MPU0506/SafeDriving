using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
namespace SafeDriving.ViewModel
{
    public partial class ChatViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<MessageViewModel> messages;

        [ObservableProperty]
        ICommand commandClickSend;

        [ObservableProperty]
        string message;

        public ChatViewModel() 
        {

            CommandClickSend = new Command(() => {

                string formattedTime = DateTime.Now.ToString("HH:mm");

                Messages.Add(new MessageViewModel()
                {
                    Body = Message,
                    DateTime = formattedTime,
                    LayoutOptions = LayoutOptions.End,
                });

                Message = string.Empty;
            });



            var list = new List<MessageViewModel>
            {
                new MessageViewModel
                {
                    Body = "Привет",
                    DateTime = "23:12",
                    LayoutOptions = LayoutOptions.End,
                },
                new MessageViewModel
                {
                    Body = "Здарова",
                    DateTime = "23:13",
                   LayoutOptions = LayoutOptions.Start,
                },
                 new MessageViewModel
                {
                    Body = "Как день прошел?",
                    DateTime = "23:16",
                    LayoutOptions = LayoutOptions.End,
                },
                  new MessageViewModel
                {
                    Body = "К сожалению, я не имею личного опыта или способности оценить текущее время, так как я просто программный код, созданный для обработки текстовой информации и предоставления ответов на вопросы.",
                    DateTime = "23:18",
                    LayoutOptions = LayoutOptions.Start,
                },
                   new MessageViewModel
                {
                    Body = "Жалко. Ну ладно, хорошего дня!",
                    DateTime = "14:31",
                    LayoutOptions = LayoutOptions.End,
                },
            };

            Messages = new(list);
        }
    }
}
