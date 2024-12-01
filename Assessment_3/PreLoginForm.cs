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
    public partial class PreLoginForm : Form
    {
        private TCPChatClient client;

        public PreLoginForm(TCPChatClient _client)
        {
            InitializeComponent();
            client = _client;
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            Hide();
            client.forms.registrationForm.Show();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Hide();
            client.forms.loginForm.Show();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            client.forms.preLoginForm.Hide();
            client.forms.connectionForm.Show();
        }
    }
}
