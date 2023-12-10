using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SafeDriving.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SafeDriving.ViewModel
{
    public partial class ListChatsViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<ChatItemViewModel> chats;


        [RelayCommand]
        async Task TapItem(ChatItemViewModel vm)
        {
            await Shell.Current.GoToAsync($"{nameof(ChatPage)}?id={vm.Id}");
        }
        
        
        public ListChatsViewModel()
        {
            chats = new ObservableCollection<ChatItemViewModel>
            {
                new ChatItemViewModel()
                {
                    Id = 1,
                    MyMessage = true,
                    Time = "10:23",
                    ChatName = "Ира Пронина",
                    LastMessage = "Привет, что задавали по математике?"
                },
                new ChatItemViewModel()
                {
                    Id = 2,
                    MyMessage = true,
                    Time = "14:31",
                    ChatName = "Иван Петров",
                    LastMessage = "Жалко. Ну ладно, хорошего дня!"
                },
                new ChatItemViewModel()
                {
                    Id = 3,
                    ChatName = "231-332",
                    Time = "22:46",
                    MyMessage = false,
                    LastMessage = "Карина: не знаю"
                },
                new ChatItemViewModel()
                {
                    Id = 4,
                    Time = "7:01",
                    ChatName = "Елизавета Янковская",
                    MyMessage = false,
                    LastMessage = "Думаю стоит все же пойти на пару"
                },
                 new ChatItemViewModel()
                {
                    Id = 5,
                    ChatName = "ПД 05_06",
                    Time = "12:09",
                    MyMessage = false,
                    LastMessage = "Аня: 331"
                },
                 new ChatItemViewModel()
                {
                    Id = 6,
                    MyMessage = true,
                    Time = "23:58",
                    ChatName = "Тамирлан Садвакасов",
                    LastMessage = "Было круто!!!"
                },
            };
        }
    }
}
