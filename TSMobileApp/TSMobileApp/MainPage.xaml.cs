using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using TSMobileApp.Pages;

namespace TSMobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Login_Btn_Clicked(object sender, EventArgs e)
        {
            string username = Username_Entry.Text;
            string password = Password_Entry.Text;

            if (AuthenticateLogin(username, password).Item1)
            {
                Application.Current.MainPage = new HomePage();
            }
            else
            {
                DisplayAlert("Error!", "Your login details were incorrect. Please try again!", "OK");
            }
        }

        private Tuple<bool,int> AuthenticateLogin(string username, string password)
        {
            bool auth_result = false;

            if (auth_result)
            {
                return Tuple.Create(true, 1);
            }
            else if (auth_result == false)
            {
                return Tuple.Create(true, 0);
            }
            else
            {
                return Tuple.Create(true, 2);
            }
        }
    }
}