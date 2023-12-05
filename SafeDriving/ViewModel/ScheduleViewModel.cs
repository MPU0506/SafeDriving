using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SafeDriving.Models;
using SafeDriving.Service.API;
using System.Collections.ObjectModel;
using System.Reflection;

namespace SafeDriving.ViewModel
{
    // TODO : Почему то иногда пары дублируются в JSON-е, надо разобратся.

    // TODO : Нужно сделать красивый вывод информации о паре 
    // (не знаю как сверстать на xaml то что в эскизном, думаю можно)
    // думаю можно обойтись списком блоков (сейчас отображается только название пары)

    // TODO: Надо заполнять currentSelectedButton и selectedDay в зависимости от текущего дня недели
    public partial class ScheduleViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<ScheduleButtonViewModel> buttons;

        [ObservableProperty]
        private Day selectedDay;

        private Dictionary<string, Day> _days = new Dictionary<string, Day>();

        private int currentSelectedButton = 0;

        private readonly IApi _api;

        public ScheduleViewModel(IApi api)
        {
            _api = api;
            Task.Run(Init);
        }

        public async Task Init()
        {
            var schedule = await _api.GetSchedule("231-332");

            var list = new List<ScheduleButtonViewModel>();

            foreach (PropertyInfo property in typeof(Schedule).GetProperties())
            {
                if (property.PropertyType == typeof(Day))
                {
                    var day = (Day)property.GetValue(schedule);

                    var dayName = property.Name; // TODO: тут надо чтобы отображался не Monday, Tuesday ... а пн, вт итд

                    _days.Add(dayName, day); 

                    list.Add(new ScheduleButtonViewModel
                    {
                        Background = Brush.Blue,
                        DayNumber = "1", // TODO: тут надо сделать чтобы отображался номер дня в месяце
                        Text = dayName
                    });
                }
            }

            Buttons = new(list);
        }


        [RelayCommand]
        async Task Tap(ScheduleButtonViewModel button)
        {
            await Task.Run(() => {
                button.Background = Brush.DarkBlue;
                Buttons[currentSelectedButton].Background = Brush.Blue;
                currentSelectedButton = Buttons.IndexOf(button);
                SelectedDay = _days[button.Text];
            });
        }
    }
}
