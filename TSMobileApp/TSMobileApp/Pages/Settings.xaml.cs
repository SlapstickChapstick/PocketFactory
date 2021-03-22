using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TSMobileApp.Objects;
using System.Collections.Generic;

namespace TSMobileApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        public Settings()
        {
            InitializeComponent();
            UpdateTextBox();
        }

        private void Apply_Btn_Clicked(object sender, EventArgs e)
        {
            string server = Server_Entry.Text;
            string port = Port_Entry.Text;

            bool file_status = Scripts.Files.ReadSettings.CheckIfConfigExists();

            if (file_status)
            {
                Scripts.Files.ReadSettings.UpdateConfigFile(server, port);
            }
            else
            {
                DisplayAlert("Oops!", "Configuration file does not exist!", "OK");
                Scripts.Files.ReadSettings.UpdateConfigFile(server, port);
            }
        }

        private void UpdateTextBox()
        {
            List<string> server_details = Scripts.Files.ReadSettings.ReadFromConfigFile();

            bool file_status = Scripts.Files.ReadSettings.CheckIfConfigExists();

            if (file_status)
            {
                Server_Entry.Text = server_details[0];
                Port_Entry.Text = server_details[1];

                App.Server_Addr = server_details[0];
                App.Server_Port = server_details[1];
            }
            else
            {
                DisplayAlert("Oops!", "Configuration file does not exist!", "OK");
                Server_Entry.Text = server_details[0];
                Port_Entry.Text = server_details[1];

                App.Server_Addr = server_details[0];
                App.Server_Port = server_details[1];
            }
        }
    }
}