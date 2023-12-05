using CommunityToolkit.Mvvm.ComponentModel;

namespace SafeDriving.ViewModel
{
    public partial class ScheduleButtonViewModel : ObservableObject
    {
        [ObservableProperty]
        private Brush background;

        public string Text { get; set; }
        public string DayNumber { get; set; }
    }
}
