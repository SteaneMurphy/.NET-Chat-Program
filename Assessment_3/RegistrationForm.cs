using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Windows_Forms_Chat;

namespace Windows_Forms_CORE_CHAT_UGH
{
    public partial class RegistrationForm : Form
    {
        TCPChatClient client;

        public RegistrationForm(TCPChatClient _client)
        {
            InitializeComponent();
            client = _client;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            client.forms.registrationForm.Hide();
            client.forms.registrationForm.usernameErrorLabel.Text = "";
            client.forms.registrationForm.usernameTextBox.Text = "";
            client.forms.registrationForm.emailTextBox.Text = "";
            client.forms.registrationForm.passwordTextBox.Text = "";
            client.forms.registrationForm.reenterPasswordTextBox.Text = "";
            client.forms.preLoginForm.Show();
        }

        private void CreateAccountButton_Click(object sender, EventArgs e)
        {
            client.SendString($"!register {usernameTextBox.Text} {emailTextBox.Text} {passwordTextBox.Text} {reenterPasswordTextBox.Text}");
        }

        public void SetUsernameError(string errorMessage) 
        {
            usernameErrorLabel.Text = errorMessage;
        }

        public void SetPasswordError(string errorMessage)
        {
            passwordErrorLabel.Text = errorMessage;
        }

        public void SetEmailError(string errorMessage)
        {
            emailErrorLabel.Text = errorMessage;
        }
    }
}
