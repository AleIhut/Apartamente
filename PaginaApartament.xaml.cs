using Apartamente.Models;
using Plugin.LocalNotification;

namespace Apartamente;

public partial class PaginaApartament : ContentPage
{
    public PaginaApartament()
    {
        InitializeComponent();
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var apartament = (Apartament)BindingContext;
        await App.Database.SaveShopAsync(apartament);
        await Navigation.PopAsync();
    }
    async void OnShowMapButtonClicked(object sender, EventArgs e)
    {
        var apartament = (Apartament)BindingContext;
        var address = apartament.Adress; 
        var locations = await Geocoding.GetLocationsAsync(address);
        var options = new MapLaunchOptions { Name = "Apartamentul meu favorit" };
        var location = locations?.FirstOrDefault();
        // var myLocation = await Geolocation.GetLocationAsync();
        var myLocation = new Location(46.7731796289, 23.6213886738);
        
        var distance = myLocation.CalculateDistance(location, DistanceUnits.Kilometers);
        if (distance < 4)
        {
            var request = new NotificationRequest
            {
                Title = "Ai de reparat ceva in apropiere!",
                Description = address,
                Schedule = new NotificationRequestSchedule { NotifyTime = DateTime.Now.AddSeconds(1) }
            };
            LocalNotificationCenter.Current.Show(request);
        
    }
        await Map.OpenAsync(location, options);
    }
}