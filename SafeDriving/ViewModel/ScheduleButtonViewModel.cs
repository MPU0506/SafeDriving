using CommunityToolkit.Mvvm.ComponentModel;
using SafeDriving.Models;

namespace SafeDriving.ViewModel
{
    public partial class ScheduleButtonViewModel : ObservableObject
    {
        [ObservableProperty]
        private Brush background;

        [ObservableProperty]
        private Day day;

        public string Text { get; set; }
        public string DayNumber { get; set; }
    }
}
