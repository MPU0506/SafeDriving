using SafeDriving.ViewModel;

namespace SafeDriving.Pages;

public partial class SchedulePage : ContentPage
{
	public SchedulePage(ScheduleViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}