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
        private Day selectedDay;
        
        private int currentSelectedButton = 0;

        private Dictionary<string, string> _days = new Dictionary<string, string>()
        {
            { "Monday", "Пн"},
            { "Tuesday", "Вт"},
            { "Wednesday", "Ср"},
            { "Thursday" , "Чт"},
            { "Friday", "Пт"},
            { "Saturday", "Сб"}
        };

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

            var now = DateTime.Now.AddDays(-1);
            DateTime monday = now.AddDays(-(int)now.DayOfWeek + (int)DayOfWeek.Monday).Date;
            var dayNumber = monday.Day;


            foreach (PropertyInfo property in typeof(Schedule).GetProperties())
            {
                if (property.PropertyType == typeof(Day))
                {
                    var day = (Day)property.GetValue(schedule);

                    var dayName = _days[property.Name]; 
                    
                    list.Add(new ScheduleButtonViewModel
                    {
                        Background = Brush.Transparent,
                        DayNumber = (dayNumber++).ToString(), // TODO: тут надо сделать чтобы отображался номер дня в месяце
                        Text = dayName,
                        Day = day,
                    }); ;
                }
            }

            currentSelectedButton = (int) DateTime.Now.DayOfWeek - 1;

            if(currentSelectedButton == -1) currentSelectedButton = 0;

            var selectedB = list[currentSelectedButton];
            selectedB.Background = Brush.Blue;
            SelectedDay = selectedB.Day;
            Buttons = new(list);
        }

        [RelayCommand]
        async Task Tap(ScheduleButtonViewModel button)
        {
            await Task.Run(() =>
            {
                SelectedDay = button.Day;
                button.Background = Brush.Blue;
                Buttons[currentSelectedButton].Background = Brush.Transparent;
                currentSelectedButton = Buttons.IndexOf(button);
            });
        }
    }
}
