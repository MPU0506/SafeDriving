using SafeDriving.ViewModel;

namespace SafeDriving.Pages;

public partial class MapPage : ContentPage
{
	public MapPage(MapViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}