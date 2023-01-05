using Apartamente.Models;

namespace Apartamente;

public partial class ListaTuturorOb : ContentPage
{
	public ListaTuturorOb()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
       VizualizareObiective.ItemsSource = await App.Database.GetShopListsAsync();
    }
    async void OnShopListAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PaginaObiective
        {
            BindingContext = new ListaObiective() 
        }); 
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)

    {
        if (e.SelectedItem != null) 
        {
            await Navigation.PushAsync(new PaginaObiective 
            {
                BindingContext = e.SelectedItem as ListaObiective 
            });
        }
    }
}