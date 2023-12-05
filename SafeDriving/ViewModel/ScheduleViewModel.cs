using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SafeDriving.Service.API;
using System.Collections.ObjectModel;

namespace SafeDriving.ViewModel
{

    public partial class ScheduleViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<ScheduleButtonViewModel> buttons;

        [ObservableProperty]
        private string date;

        private int currentSelectedButton = 0;

        private readonly IApi _api;

        public ScheduleViewModel(IApi api)
        {
            _api = api;
            Init();
        }

        public async void Init()
        {
            _api.SetAuthToken("0IwGWvhf%2Bd9UGa7wkj8qTyAM8vW86T7HPzV11B9GNLvxMTZgPEFWacFk%2BbO2lmIVpB4FZl3gw4Gl4vqwmhv0ZvDpXNe5XGYCIDnXsxi%2Ba74OZq1SuJFcSdEIbJ43v4CU8zWhSl4Wn1MG8EJNUiwHDy75090t7ym31uBCuOR2OyY%3D\\");
            
            var schedule = await _api.GetSchedule("231-332");

            var list = new List<ScheduleButtonViewModel>();

            for (int i = 1; i < 7; i++)
            {
                list.Add(new ScheduleButtonViewModel
                {
                    Background = Brush.Blue,
                    DateTime = DateTime.Now,
                    DayNumber = i.ToString(),
                    Text = "Пн"
                });
            }

            Buttons = new(list);
        }


        [RelayCommand]
        async Task Tap(ScheduleButtonViewModel button)
        {
            await Task.Run(() => {
                Date = button.DateTime.ToShortDateString();
                button.Background = Brush.DarkBlue;

                Buttons[currentSelectedButton].Background = Brush.Blue;
                currentSelectedButton = Buttons.IndexOf(button);
            });
        }
    }
}
