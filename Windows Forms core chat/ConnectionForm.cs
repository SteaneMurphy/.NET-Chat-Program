using System;
using System.Net.Sockets;
using System.Windows.Forms;
using Windows_Forms_Chat;

namespace Windows_Forms_CORE_CHAT_UGH
{
    public partial class ConnectionForm : Form
    {
        TCPChatServer server = null;
        TCPChatClient client = null;
        ChatForm chatForm;

        public ConnectionForm()
        {
            InitializeComponent();
            chatForm = new ChatForm();
        }

        public bool CanHostOrJoin()
        {
            if (server == null && client == null) 
            {
                return true;
            }
                
            else
                return false;
        }

        private void HostButton_Click(object sender, EventArgs e)
        {
            if (CanHostOrJoin())
            {
                try
                {
                    int port = int.Parse(portTextBox.Text);
                    server = TCPChatServer.createInstance(port, chatForm.ChatTextBox, errorLabel);
                    chatForm.UpdateServer(server);
                    if (server == null) 
                    {
                        throw new Exception();
                    }
                    
                    Hide();
                    chatForm.Show();
                    server.SetupServer();
                    chatForm.Text = "ChatterBox - Server Running";
                }
                catch (FormatException)
                {
                    errorLabel.Text = "Port entered incorrectly, try a port between 0 and 65535";
                }
                catch (SocketException sockExc)
                {
                    errorLabel.Text = sockExc.ToString();
                }
                catch (OverflowException) 
                {
                    errorLabel.Text = "Port entered incorrectly, try a port between 0 and 65535";
                }
                catch (ArgumentNullException)
                {
                    errorLabel.Text = "Port value cannot be empty, try a port between 0 and 65535";
                }
                catch (Exception) 
                {
                    errorLabel.Text = "There was an error when trying to host your server";
                }
            }
        }

        private void JoinButton_Click(object sender, EventArgs e)
        {
            if (CanHostOrJoin())
            {
                try
                {
                    //blank field exception
                    if (usernameTextBox.Text.Length < 1)
                    {
                        throw new ArgumentException("Please choose a username");
                    }
                    if (portTextBox.Text.Length < 1) 
                    {
                        throw new ArgumentException("Please enter the port number for the server you want to connect to");
                    }
                    if (serverIPTextBox.Text.Length < 1) 
                    {
                        throw new ArgumentException("Please enter the IP address for the server you want to connect to");
                    }

                    int port = int.Parse(portTextBox.Text);
                    client = TCPChatClient.CreateInstance(port, serverIPTextBox.Text, chatForm.ChatTextBox, usernameTextBox.Text);
                    chatForm.UpdateClient(client);

                    if (client == null)
                        throw new Exception("Incorrect port value!");

                    Hide();
                    chatForm.Show();
                    client.ConnectToServer();
                    client.SendString($"!username {usernameTextBox.Text}");
                    chatForm.Text = $"ChatterBox - Client: {usernameTextBox.Text}";
                }
                catch (ArgumentException argNullExc) 
                {
                    errorLabel.Text = argNullExc.Message;
                }
                catch (Exception ex)
                {
                    client = null;
                    errorLabel.Text = ex.ToString();
                }
            }
        }
    }
}
