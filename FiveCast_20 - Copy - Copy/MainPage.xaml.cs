using FiveCast.Model;
using FiveCast.Services;
using FiveCast.Pages;
using System.Collections.ObjectModel;

namespace FiveCast
{
    public partial class MainPage : ContentPage
    {
        private readonly DatabaseService _database;
        public ObservableCollection<Destination> Destinations { get; set; }

        public ObservableCollection<string> Countries { get; set; } = new()
        {
            ""
        };

        public MainPage(DatabaseService database)
        {
            InitializeComponent();
            _database = database;
            Destinations = new ObservableCollection<Destination>();
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var list = await _database.GetDestinationsAsync();
            Destinations.Clear();
            foreach (var item in list)
                Destinations.Add(item);
        }

        private async void OnNewClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DestinationPage(_database));
        }

        private async void OnEditClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var destination = button?.BindingContext as Destination;
            if (destination != null)
                await Navigation.PushAsync(new DestinationPage(_database, destination));
        }
        
        private async void OnCompleteClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var destination = button?.BindingContext as Destination;
            if (destination != null)
            {
                destination.Status = "Complete";
                await _database.SaveDestinationAsync(destination);
            }
            OnAppearing();
        }
        
        private async void OnActiveClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var destination = button?.BindingContext as Destination;
            if (destination != null)
            {
                destination.Status = "Active";
                await _database.SaveDestinationAsync(destination);
            }
            OnAppearing();
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var destination = button?.BindingContext as Destination;
            if (destination != null)
            {
                await _database.DeleteDestinationAsync(destination);
                Destinations.Remove(destination);
            }
        }
    }
}
