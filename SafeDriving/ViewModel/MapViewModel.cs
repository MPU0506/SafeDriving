using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeDriving.ViewModel
{
    public partial class MapViewModel : ObservableObject
    {
        [ObservableProperty]
        string url;

        public MapViewModel()
        {
            Url = "https://yandex.ru/maps/213/moscow/?from=mapframe&ll=37.625407%2C55.843704&mode=usermaps&source=mapframe&um=constructor%3Afbb2272bd43874d2f07fb4fe89c7f03cafb56b61a80c76519c92ec62fbce174a&utm_source=mapframe&z=11";
        }
    }
}
