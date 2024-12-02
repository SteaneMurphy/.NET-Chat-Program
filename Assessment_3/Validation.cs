using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace Windows_Forms_CORE_CHAT_UGH
{
    internal class Validation
    {
        DatabaseManagement db;

        public Validation(DatabaseManagement _db) 
        {
            db = _db;
        }

        public (bool, string) ValidateLogin(string _username, string _password) 
        {
            (bool username, string usernameError) = ValidateUsername(_username);
            bool password = PasswordExists(_password);
            Console.WriteLine($"username: {username}, pass: {password}");
            if (username && password)
            {
                return (true, "");
            }
            else 
            {
                return (false, "Username or password incorrect");
            }
        }

        public (bool, string, string, string) ValidateRegistration(string _username, string _email, string _password, string _reenterPassword) 
        {
            (bool usernameValid, string usernameError) = UsernameExists(_username);
            (bool passwordValid, string passwordError) = ValidatePassword(_password, _reenterPassword);
            (bool emailValid, string emailError) = ValidateEmail(_email);

            if (usernameValid && passwordValid && emailValid)
            {
                return (true, "", "", "");
            }
            else 
            {
                return (false, usernameError, passwordError, emailError);
            }
        }

        public (bool, string) UsernameExists(string _username) 
        {
            if (db.QueryUsername(_username) == _username)
            {
                return (false, "Username already in use");
            }
            else 
            {
                return (true, "");
            }
        }

        public (bool, string) ValidateUsername(string _username)
        {
            if (db.QueryUsername(_username) == _username)
            {
                return (true, "");
            }
            else
            {
                return (false, "Username does not exist");
            }
        }

        public bool PasswordExists(string _password) 
        {
            if (db.QueryPassword(_password) == _password)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public (bool, string) ValidatePassword(string _password, string _reenterPassword) 
        {
            string pattern = @"^(?=.*[A-Z])(?=.*[\W_]).{8,}$";

            if (_password == _reenterPassword)
            {
                if (Regex.IsMatch(_password, pattern))
                {
                    return (true, "");
                }
                else 
                {
                    return (false, "Password does not meet requirements");
                }
            }
            else 
            {
                return (false, "The passwords do not match");
            }
        }

        public (bool, string) ValidateEmail(string _email)
        {
            if (db.QueryEmail(_email) == _email)
            {
                return (false, "Email already in use");
            }
            else 
            {
                return (true, "");
            }
        }
    }
}
