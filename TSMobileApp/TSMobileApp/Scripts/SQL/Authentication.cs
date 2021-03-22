using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace TSMobileApp.Scripts.SQL
{
    class Authentication : SQL_Properties
    {
        public static bool AuthenicateLogin(string username, string password)
        {
            Console.WriteLine(password);
            return false;
        }
    }
}
