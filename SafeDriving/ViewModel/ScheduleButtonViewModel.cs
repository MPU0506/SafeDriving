using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SafeDriving.ViewModel
{
    public partial class ScheduleButtonViewModel : ObservableObject
    {
        [ObservableProperty]
        private Brush background;

        public string Text { get; set; }
        public string DayNumber { get; set; }

        public DateTime DateTime { get; set; }


        
    }
}
