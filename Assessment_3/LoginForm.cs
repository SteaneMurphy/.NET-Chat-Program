using System;
using System.Windows.Forms;
using Windows_Forms_Chat;

namespace Windows_Forms_CORE_CHAT_UGH
{
    public partial class LoginForm : Form
    {
        TCPChatClient client;

        public LoginForm(TCPChatClient _client)
        {
            InitializeComponent();
            client = _client;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            client.SendString($"!login {usernameTextBox.Text} {passwordTextBox.Text}");
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            client.forms.loginForm.Hide();
            client.forms.loginForm.errorLabel.Text = "";
            client.forms.loginForm.usernameTextBox.Text = "";
            client.forms.loginForm.passwordTextBox.Text = "";
            client.forms.preLoginForm.Show();
        }

        public void SetErrorLabel(string errorMessage) 
        {
            errorLabel.Invoke(new Action(() => errorLabel.Text = errorMessage));
        }
    }
}
