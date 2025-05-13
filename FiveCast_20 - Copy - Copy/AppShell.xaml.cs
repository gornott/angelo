using FiveCast.Pages;

namespace FiveCast
{
    public partial class AppShell : Shell
    {
        public AppShell(MainPage mainPage)
        {
            InitializeComponent();
            this.Items.Add(new ShellContent
            {
                Title = "FiveCast",
                Content = mainPage
            });
            Routing.RegisterRoute("expenses", typeof(ExpensesPage));
        }
    }
}
