using Apartamente.Models;
namespace Apartamente;

public partial class IntrareApartament : ContentPage
{
	public IntrareApartament()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        VizualizareObiective.ItemsSource = await App.Database.GetShopsAsync();
    }
    async void OnShopAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PaginaApartament
        {
            BindingContext = new Apartament()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null) { await Navigation.PushAsync(new PaginaApartament { BindingContext = e.SelectedItem as Apartament }); }
    }
}