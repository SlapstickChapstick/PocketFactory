using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TSMobileApp
{
    public partial class App : Application
    {
        public static string Username { get; set; }
        public static string Role { get; set; }
        public static string Server_Addr { get; set; }
        public static string Server_Port { get; set; }
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
