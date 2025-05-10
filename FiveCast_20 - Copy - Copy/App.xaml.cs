using System;
using Microsoft.Extensions.DependencyInjection;

namespace FiveCast
{
    public partial class App : Application
    {
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            MainPage = serviceProvider.GetRequiredService<AppShell>();
        }
    }
}
