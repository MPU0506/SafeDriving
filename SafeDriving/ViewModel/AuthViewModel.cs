using CommunityToolkit.Mvvm.ComponentModel;
using SafeDriving.Pages;
using SafeDriving.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace SafeDriving.ViewModel
{
    public partial class AuthViewModel : ObservableObject
    {
        [ObservableProperty]
        private string login;

        [ObservableProperty]
        private string password;


        private readonly UserService _userService;

        [ObservableProperty]
        ICommand clickLogin;

        public AuthViewModel(UserService userService)
        {
            _userService = userService;

            ClickLogin = new Command(async () =>
            {
               var ok = await userService.Login(Login, Password);

                if(ok)
                {
                    await Shell.Current.GoToAsync($"{nameof(AccountPage)}");
                }
                else
                {
                    // TODO: Обработать надо
                }
            });
        }
    }
}
