using System;
using System.Drawing;
using System.Net.Sockets;
using System.Windows.Forms;
using Windows_Forms_Chat;

namespace Windows_Forms_CORE_CHAT_UGH
{
    /*
        This class provides functionality for the connection form. A user can host or join
        a chat server. Basic validation (missing fields, incorrect field formats, etc) is provided
        and successful attempts trigger server or client setup.

        This form calls the main form 'ChatForm'.
    */
    public partial class ConnectionForm : Form
    {
        TCPChatServer server = null;
        TCPChatClient client = null;
        ChatForm chatForm;
        Forms forms;

        public ConnectionForm()
        {
            //initialisation and element colours
            InitializeComponent();
            chatForm = new ChatForm();
            chatForm.CreateControl();
            hostButton.ForeColor = Color.FromArgb(45, 118, 253);
            joinButton.ForeColor = Color.FromArgb(45, 118, 253);
        }

        public bool CanHostOrJoin()
        {
            //checks if an instance of the server or client is already running
            //and prevents further host/join attempts if true
            if (server == null && client == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
            This function provides the functionality for the 'Host Server' button.
            It checks for existing instances of 'TCPChatServer', and creates one if none are found.
            Once an instance is created, the form 'ConnectionForm' is hidden and server setup begins.

            Exceptions: most exceptions deal with a user entering an invalid port number or format. As the error
            label is user facing, I consolidated and simplified the error messages, especially for generic exception
            cases.
        */
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

        /*
            This function provides the functionality for the 'Host Server' button.
            It checks for existing instances of 'TCPChatClient', and creates one if none are found.
            Once an instance is created, the form 'ConnectionForm' is hidden and 'ChatForm' is shown.
            
            After an instance is created, the client tries to connect to the server, in this process the client sends
            its proposed username.

            Exceptions: most exceptions deal with a user missing required information, for example, a user will be prompted with
            an missing field error if they do not enter a username.
        */
        private void JoinButton_Click(object sender, EventArgs e)
        {
            if (CanHostOrJoin())
            {
                try
                {
                    //blank field exception
                    if (portTextBox.Text.Length < 1)
                    {
                        throw new ArgumentException("Please enter the port number for the server you want to connect to");
                    }
                    if (serverIPTextBox.Text.Length < 1)
                    {
                        throw new ArgumentException("Please enter the IP address for the server you want to connect to");
                    }

                    int port = int.Parse(portTextBox.Text);
                    client = TCPChatClient.CreateInstance(port, serverIPTextBox.Text, chatForm.ChatTextBox);
                    forms = new Forms(client, this, chatForm);
                    client.SetForms(forms);
                    chatForm.UpdateClient(client);

                    if (client == null)
                        throw new Exception("Incorrect port value!");

                    if (client.ConnectToServer()) 
                    {
                        Hide();
                        forms.preLoginForm.Show();
                    }
                    else 
                    {
                        //error label
                    }
                    //client.SendString($"!user {usernameTextBox.Text}");
                    //chatForm.Text = $"ChatterBox - Client: {usernameTextBox.Text}";
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
