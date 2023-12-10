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
                    ChatName = "Ира Пронина",
                    LastMessage = "оаыадлиовалям мваораичжы "
                },
                new ChatItemViewModel()
                {
                    Id = 2,
                    ChatName = "Главный чел",
                    LastMessage = "оаыадлиовалям мваораичжы sdjfhjsd sjdfhjsdhfj sjdfhjshdfkj"
                }
            };
        }
    }
}
