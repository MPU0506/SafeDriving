using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.VisualBasic;
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

        //вот 1
        private Day selectedDay;
        public static Day Monday { get; private set; }
        public static Day Tuesday { get; private set; }
        public static Day Wednesday { get; private set; }
        public static Day Thursday { get; private set; }
        public static Day Friday { get; private set; }
        public static Day Saturday { get; private set; }

        private Dictionary<string, Day> _days = new Dictionary<string, Day>()
        {
            { "Пн" , Monday},
            { "Вт" , Tuesday},
            { "Ср", Wednesday},
            { "Чт", Thursday},
            { "Пт", Friday},
            { "Сб", Saturday}
        };
        //вот 1 закончилось
        private readonly IApi _api;

        public ScheduleViewModel(IApi api)
        {
            _api = api;
            Task.Run(Init);
        }
        private async Task Init()
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

                        DayNumber = _days.ToString(), // TODO: тут надо сделать чтобы отображался номер дня в месяце
                        Text = SelectedDay.ToString(),
                    }); ;
                }
            }

            Buttons = new(list);
        }

        //вот 2
        int currentSelectedButton;
        [RelayCommand]
        async Task Tap(ScheduleButtonViewModel button)
        {
            await Task.Run(() =>
            {
                button.Background = Brush.DarkBlue;
                Buttons[currentSelectedButton].Background = Brush.Blue;
                currentSelectedButton = Buttons.IndexOf(button);

                // Получение текущего дня недели
                DateTime currentDate = DateTime.Now;
                DayOfWeek currentDayOfWeek = currentDate.DayOfWeek;

                // Установка значений currentSelectedButton и selectedDay в зависимости от текущего дня недели
                switch (currentDayOfWeek)
                {
                    case DayOfWeek.Monday:
                        currentSelectedButton = 0;
                        SelectedDay = _days["Monday"];
                        break;
                    case DayOfWeek.Tuesday:
                        currentSelectedButton = 1;
                        SelectedDay = _days["Tuesday"];
                        break;
                    case DayOfWeek.Wednesday:
                        currentSelectedButton = 2;
                        SelectedDay = _days["Wednesday"];
                        break;
                    case DayOfWeek.Thursday:
                        currentSelectedButton = 3;
                        SelectedDay = _days["Thursday"];
                        break;
                    case DayOfWeek.Friday:
                        currentSelectedButton = 4;
                        SelectedDay = _days["Friday"];
                        break;
                    case DayOfWeek.Saturday:
                        currentSelectedButton = 5;
                        SelectedDay = _days["Saturday"];
                        break;
                    case DayOfWeek.Sunday:
                        currentSelectedButton = 6;
                        SelectedDay = _days["Sunday"];
                        break;
                }
            });
        }
        //вот 1 закончилось
    }
}
