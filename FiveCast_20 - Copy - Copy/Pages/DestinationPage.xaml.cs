
using System;
using Microsoft.Maui.Controls;
using FiveCast.Model;
using FiveCast.Services;

namespace FiveCast.Pages
{
    public partial class DestinationPage : ContentPage
    {
        public Destination Destination { get; set; }
        private readonly DatabaseService _database;
        public List<string> CityNames => CityList.Names.OrderBy(name => name).ToList();

        public DestinationPage(DatabaseService database, Destination destination = null)
        {
            InitializeComponent();
            ExpensesButton.Clicked += OnExpensesClicked;
            _database = database;

            Destination = destination ?? new Destination
            {
                StartDate = DateTime.Today,
                Duration = 1,
                Status = "draft"
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
                
            }
            
        }
    }
}

