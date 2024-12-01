using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Windows_Forms_Chat;

namespace Windows_Forms_CORE_CHAT_UGH
{
    public class Login
    {
        ClientSocket client;
        string username;
        string password;

        public Login(ClientSocket _client, string _username, string _password) 
        {
            client = _client;
            username = _username;
            password = _password;
        }

        private bool CanLogin() 
        {
            if (client.stateLogin)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        private bool ValidateLogin() 
        {
            if (CanLogin()) 
            {
                if (username == client.username) 
                {
                    if (password == client.password) 
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }        
    }
}
