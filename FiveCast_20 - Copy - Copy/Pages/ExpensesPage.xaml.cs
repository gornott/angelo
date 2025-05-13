using System.Collections.ObjectModel;
using FiveCast.Model;
using FiveCast.Services;

namespace FiveCast.Pages
{
    [QueryProperty(nameof(DestinationId), "destinationId")]
    public partial class ExpensesPage : ContentPage
    {
        private readonly DatabaseService _db;

        public int DestinationId { get; set; }
        public ObservableCollection<Expense> Expenses { get; set; } = new();

        public ExpensesPage()
        {
            InitializeComponent();
            _db = MauiProgram.ServiceProvider.GetRequiredService<DatabaseService>();
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                var list = await _db.GetExpensesAsync(DestinationId);
                Expenses.Clear();
                foreach (var e in list)
                    Expenses.Add(e);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void OnAddExpenseClicked(object sender, EventArgs e)
        {
            if (double.TryParse(AmountEntry.Text, out double amount) && !string.IsNullOrWhiteSpace(TypeEntry.Text))
            {
                var expense = new Expense { DestinationId = DestinationId, Type = TypeEntry.Text, Amount = amount };
                await _db.SaveExpenseAsync(expense);
                Expenses.Add(expense);
                TypeEntry.Text = string.Empty;
                AmountEntry.Text = string.Empty;
            }
            else
            {
                await DisplayAlert("Error", "Please enter a valid type and amount.", "OK");
            }
        }

        private async void OnDeleteExpenseClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var expense = button?.BindingContext as Expense;
            if (expense != null)
            {
                await _db.DeleteExpenseAsync(expense);
                Expenses.Remove(expense);
            }
        }
    }
}
