using Apartamente.Models;
namespace Apartamente;

public partial class PaginaObiective : ContentPage
{
	public PaginaObiective()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
	{
		var slist = (ListaObiective)BindingContext;
		slist.Date = DateTime.UtcNow;
		await App.Database.SaveShopListAsync(slist);
		await Navigation.PopAsync(); 
	}
    async void OnDeleteButtonClicked(object sender, EventArgs e) 
	{
		var slist = (ListaObiective)BindingContext;
		await App.Database.DeleteShopListAsync(slist);
		await Navigation.PopAsync();
	}
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ObiectivePredefinite((ListaObiective)this.BindingContext)
		{ 
			BindingContext = new Obiectiv() 
		});
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shopl = (ListaObiective)BindingContext;
        VizualizareaObiective.ItemsSource = await App.Database.GetListProductsAsync(shopl.ID);
    }
}