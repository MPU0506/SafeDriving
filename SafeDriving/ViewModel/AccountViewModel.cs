using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeDriving.ViewModel
{
    public partial class AccountViewModel : ObservableObject
    {
        [ObservableProperty]
        private string avatarSource;

        public AccountViewModel()
        {
            AvatarSource = "https://e.mospolytech.ru/old/img/photos/upc_33acd7a2a52067fb48ecf948c6037e41_1694025553.jpg";
        }
    }
}
