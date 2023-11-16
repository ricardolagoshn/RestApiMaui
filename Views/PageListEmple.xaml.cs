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

    private async void listemp_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if(e.CurrentSelection != null && e.CurrentSelection.Count > 0) 
        {
            var elemselect = e.CurrentSelection[0] as Empleado;

            await DisplayAlert("Aviso", "Elemento Selcccionado " + elemselect.nombres, "OK");

        }
    }
}