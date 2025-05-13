using System.Collections.ObjectModel;
using FiveCast.Model;

namespace FiveCast.Pages
{
    public partial class ExpensesPage : ContentPage
    {
        private readonly Services.DatabaseService _db;
        private readonly int _destinationId;
        public ObservableCollection<Expense> Expenses { get; set; } = new();

        public ExpensesPage(Services.DatabaseService db, int destinationId)
        {
            InitializeComponent();
            _db = db;
            _destinationId = destinationId;
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var list = await _db.GetExpensesAsync(_destinationId);
            Expenses.Clear();
            foreach (var e in list)
                Expenses.Add(e);
        }

        private async void OnAddExpenseClicked(object sender, EventArgs e)
        {
            if (double.TryParse(AmountEntry.Text, out double amount) && !string.IsNullOrWhiteSpace(TypeEntry.Text))
            {
                var expense = new Expense { DestinationId = _destinationId, Type = TypeEntry.Text, Amount = amount };
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
