using CommunityToolkit.Mvvm.ComponentModel;
using SafeDriving.Pages;
using SafeDriving.Service;
using System.Windows.Input;

namespace SafeDriving.ViewModel
{

    // TODO: Надо сделать навигацию (см пример AuthViewModel и AuthPage.xaml)
    public partial class AccountViewModel : ObservableObject
    {
        [ObservableProperty]
        private string avatarSource;

        [ObservableProperty]
        private string fullName;

        private readonly UserService _userService;

        [ObservableProperty]
        ICommand clickChat;

        [ObservableProperty]
        ICommand clickSchedule;


        [ObservableProperty]
        ICommand clickMap;

        public AccountViewModel(UserService userService)
        {
            _userService = userService;

            ClickChat = new Command(async () => {
                await Shell.Current.GoToAsync($"{nameof(ListChatsPage)}");
            });

            ClickSchedule = new Command(async () =>
            {
                await Shell.Current.GoToAsync($"{nameof(SchedulePage)}");
            });

            ClickMap = new Command(async () => {
                await Shell.Current.GoToAsync($"{nameof(MapPage)}");
            });

            

            Task.Run(Init);
        }

        private async Task Init()
        {

            var user = _userService.Getuser();
            AvatarSource = user.Avatar;
            FullName = user.Name + user.Surname + user.Patronymic;
            // TODO Продолжить заполнять поля
            //тест1
        }
    }
}
