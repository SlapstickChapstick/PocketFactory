using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace TSMobileApp.Scripts.SQL
{
    class Authentication : SQL_Properties
    {
        public static async Task<LoginResult> AuthenicateLogin(string username, string password)
        {
            HttpClient http_client = new HttpClient();

            string url = String.Format(@"http://{0}:{1}/mobile/auth/login/?username={2}&password={3}", App.Server_Addr, App.Server_Port, username, password);

            string url_result = null;
            LoginResult login_result = null;

            try
            {
                login_result = new LoginResult();
                url_result = await http_client.GetStringAsync(url);
                login_result = JsonConvert.DeserializeObject<LoginResult>(url_result);
            }
            catch (Exception e)
            {
                login_result = new LoginResult();
                login_result.logged_in = false;
                login_result.status_code = 2;
            }
            
            return login_result;
        }

        public static async Task<bool> CheckGroups(string username)
        {
            bool user_in_group = false;

            HttpClient http_client = new HttpClient();

            string url = String.Format(@"http://{0}:{1}/mobile/auth/groups/?username={2}", App.Server_Addr, App.Server_Port, username);

            Task<string> get_result = http_client.GetStringAsync(url);

            string url_result = null;

            try
            {
                url_result = await http_client.GetStringAsync(url);
            }
            catch (Exception)
            {

            }

            JArray groups_json = JArray.Parse(url_result);

            foreach (var group in groups_json)
            {
                if(group.ToString() == "TE-Sec-Mobile App Users")
                {
                    return true;
                }
            }

            return user_in_group;
        }
    }

    class LoginResult
    {
        public bool logged_in { get; set; }
        public int status_code { get; set; }
    }
}