using CommunityToolkit.Mvvm.ComponentModel;
using SafeDriving.Service;

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

        public AccountViewModel(UserService userService)
        {
            _userService = userService;
            Task.Run(Init);
        }

        private async Task Init()
        {
            var user = _userService.Getuser();
            AvatarSource = user.Avatar;
            FullName = user.Name + user.Surname + user.Patronymic;
            // TODO Продолжить заполнять поля
        }
    }
}
