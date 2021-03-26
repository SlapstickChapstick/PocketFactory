using System;
using TSMobileApp.Scripts.Security;
using Xamarin.Forms;
using TSMobileApp.Pages;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TSMobileApp
{
    public partial class MainPage : ContentPage
    {
        private string pass_crypt = null;
        public MainPage()
        {
            InitializeComponent();

            List<string> server_details = Scripts.Files.ReadSettings.ReadFromConfigFile();

            App.Server_Addr = server_details[0];
            App.Server_Port = server_details[1];

            Console.WriteLine(App.Server_Addr + ":" + App.Server_Port);
        }

        private async void Login_Btn_Clicked(object sender, EventArgs e)
        {
            string username = Username_Entry.Text;
            string password = Password_Entry.Text;

            Console.WriteLine("Plain Text: " + password);
            pass_crypt = Encryption.AES_Encrypt(password);
            Console.WriteLine(pass_crypt);

            var result = await Scripts.SQL.Authentication.AuthenicateLogin(username, pass_crypt);

            Console.WriteLine(result.logged_in);

            if (result.logged_in)
            {
                if (await Scripts.SQL.Authentication.CheckGroups(username))
                {
                    Application.Current.MainPage = new HomePage();
                }
                else
                {
                    DisplayAlert("Error!", "Your do not have permission to use this app. Please contact a system administrator.", "OK");
                }
            }
            else
            {
                switch (result.status_code)
                {
                    case 1:
                        DisplayAlert("Error!", "Your login details were incorrect. Please check them and try again!", "OK");
                        break;

                    case 2:
                        DisplayAlert("Error!", "The server details are incorrect. Please check them and try again!", "OK");
                        break;
                }
            }
        }

        private void Setting_Btn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Pages.Settings());
        }
    }
}