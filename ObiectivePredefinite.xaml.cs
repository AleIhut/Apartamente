using Apartamente.Models;

namespace Apartamente;

public partial class ObiectivePredefinite : ContentPage
{
    ListaObiective lo;
    public ObiectivePredefinite(ListaObiective olista)
    {
        InitializeComponent();
        lo = olista;
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var obiectiv = (Obiectiv)BindingContext;
        await App.Database.SaveProductAsync(obiectiv);
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var obiectiv = (Obiectiv)BindingContext;
        await App.Database.DeleteProductAsync(obiectiv);
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Obiectiv o;
        if (listView.SelectedItem != null)
        {
            o = listView.SelectedItem as Obiectiv;
            var lp = new ObiectivLista()
            {
                ListaObiectiveID = lo.ID,
                ObiectivID = o.ID
            };
            await App.Database.SaveListProductAsync(lp);
            o.ObiectivLista = new List<ObiectivLista> { lp };
            await Navigation.PopAsync();
        }
    }
}