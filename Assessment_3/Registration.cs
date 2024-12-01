using System;
using System.Collections.Generic;
using System.Text;
using Windows_Forms_Chat;

namespace Windows_Forms_CORE_CHAT_UGH
{
    internal class Registration
    {
        ClientSocket client;
        string username;
        string password;
        string repeatPassword;

        public Registration(ClientSocket _client, string _username, string _password, string _repeatPassword)
        {
            client = _client;
            username = _username;
            password = _password;
            repeatPassword = _repeatPassword;
        }

        private bool ValidateUserDetails() 
        {
            

            return false;
        }
    }
}
