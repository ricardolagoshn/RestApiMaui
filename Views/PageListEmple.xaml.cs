namespace RestApiMaui.Views;
using RestApiMaui.Models;

public partial class PageListEmple : ContentPage
{
	public PageListEmple()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        List<Models.Empleado> listemple = new List<Models.Empleado>();
        listemple = await Controllers.EmpleController.GetEmpleados();
        listemp.ItemsSource = listemple;    

    }
}