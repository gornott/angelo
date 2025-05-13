using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using FiveCast.Model;
using FiveCast.Services;

namespace FiveCast.Pages
{
    public partial class DestinationPage : ContentPage
    {
        public Destination Destination { get; set; }
        private readonly DatabaseService _database;
        private readonly WeatherService _weatherService = new();
        public List<string> CityNames => CityList.Names.OrderBy(name => name).ToList();

        public DestinationPage(DatabaseService database, Destination destination = null)
        {
            InitializeComponent();
            _database = database;

            Destination = destination ?? new Destination
            {
                StartDate = DateTime.Today,
                Duration = 1,
                Status = "draft",
                Country = "Bulgaria"
            };

            BindingContext = this;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            await _database.SaveDestinationAsync(Destination);
            await Navigation.PopAsync();
        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void OnExpensesClicked(object sender, EventArgs e)
        {
            try
            {
                if (Destination != null)
                    await Navigation.PushAsync(new ExpensesPage(_database, Destination.Id));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void OnGetWeatherClicked(object sender, EventArgs e)
        {
            try
            {
                DateTime start = Destination.StartDate;

                var forecast = await _weatherService.GetForecastAsync(Destination.City, Destination.Country, start, Destination.Duration);
                if (forecast == null || forecast.weather == null || forecast.weather.Length == 0)
                {
                    WeatherResultLabel.Text = "Няма прогноза за тази дата.";
                    return;
                }

                var result = $"{Destination.City}:\n";

                foreach (var day in forecast.weather)
                {
                    string date = DateTime.Parse(day.date).ToString("dd MMM");
                    string desc = day.hourly[0].weatherDesc[0].value;
                    string temp = day.hourly[0].tempC;

                    result += $"{date} – {desc}, {temp}°C\n";
                }
                
                WeatherResultLabel.Text = result.Trim();
            }
            catch (Exception ex)
            {
                WeatherResultLabel.Text = "Грешка при извличане на времето.";
            }
        }
    }
}
