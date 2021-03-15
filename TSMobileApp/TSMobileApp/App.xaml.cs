using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TSMobileApp
{
    public partial class App : Application
    {
        public static string Username { get; set; }
        public static string Role { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
