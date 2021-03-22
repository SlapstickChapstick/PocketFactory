using System;
using TSMobileApp.Scripts.Security;
using Xamarin.Forms;
using TSMobileApp.Pages;

namespace TSMobileApp
{
    public partial class MainPage : ContentPage
    {
        private string pass_crypt = null;
        public MainPage()
        {
            InitializeComponent();
        }

        private void Login_Btn_Clicked(object sender, EventArgs e)
        {
            string username = Username_Entry.Text;
            string password = Password_Entry.Text;

            Console.WriteLine("Plain Text: " + password);
            pass_crypt = Encryption.AES_Encrypt(password);
            Console.WriteLine(pass_crypt);

            if (Scripts.SQL.Authentication.AuthenicateLogin(username, pass_crypt))
            {
                Application.Current.MainPage = new HomePage();
            }
            else
            {
                DisplayAlert("Error!", "Your login details were incorrect. Please try again!", "OK");
            }
        }

        private void Setting_Btn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Pages.Settings());
        }
    }
}