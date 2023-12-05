using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeDriving.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {

        [ObservableProperty]
        string mainText;

        public MainViewModel() {
            MainText = "string";
        }
    }
}
