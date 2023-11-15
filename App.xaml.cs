namespace RestApiMaui;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage( new Views.PageListEmple());
	}
}
