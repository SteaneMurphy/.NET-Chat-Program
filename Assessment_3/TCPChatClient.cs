using System;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using Windows_Forms_CORE_CHAT_UGH;

namespace Windows_Forms_Chat
{
    public class TCPChatClient : TCPChatBase
    {
        /*
            These variables are client specific. A reference to the current client's instance socket as well as
            reference to the server port/IP.
        */
        public Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public ClientSocket clientSocket = new ClientSocket();
        public int serverPort;
        public string serverIP;
        public Forms forms;

        /*
            This function creates a new instance of a client socket.
        */
        public static TCPChatClient CreateInstance(int port, string serverIP, RichTextBox chatTextBox)
        {
            TCPChatClient tcp = null;
            if (port > 0 && port < 65535 && 
                serverIP.Length > 0 &&
                chatTextBox != null)
            {
                tcp = new TCPChatClient();
                tcp.port = port;
                tcp.serverIP = serverIP;
                tcp.chatTextBox = chatTextBox;
                tcp.clientSocket.socket = tcp.socket;
            }
            return tcp;
        }

        public void SetForms(Forms _forms) 
        {
            forms = _forms;
        }

        /*
            This function connects the client to the server via the 'Connect' function.
            The server's IP and port are used.
            Once a successful connection has been made, a thread is created using the 'BeginReceive' function
            so that further communication can be made using the socket.
        */
        public bool ConnectToServer()
        {
            int attempts = 0;

            while (!socket.Connected)
            {
                try
                {
                    attempts++;
                    //SetChat("Connection attempt " + attempts);
                    socket.Connect(serverIP, port);
                }
                catch (SocketException)
                {
                    //errorLabel.Text = "";
                    return false;
                }
            }
            //AddToChat("Connected");
            clientSocket.socket.BeginReceive(clientSocket.buffer, 0, ClientSocket.BUFFER_SIZE, SocketFlags.None, ReceiveCallback, clientSocket);
            return true;
            //Console.WriteLine($"Client Port: {((IPEndPoint)socket.LocalEndPoint).Port}");
        }

        /*
            This function encodes a string into a byte array and sends the data to the server
            using the socket interface.
        */
        public void SendString(string text)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(text);
            socket.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }

        /*
            This function listens for incoming data from its connected socket. In this case, that is
            messages sent from the server.

            The 'EndReceive' function ends the current message and is opened again with 'BeginReceive'.
            If the socket returns '0', then the server has disconnected and the client will close the socket.
            This will also happen if the socket throws a socket exception of any kind.
        */
        public void ReceiveCallback(IAsyncResult AR)
        {
            ClientSocket currentClientSocket = (ClientSocket)AR.AsyncState;

            int received;

            try
            {
                received = currentClientSocket.socket.EndReceive(AR);

                if (received == 0)
                {
                    AddToChat("Server has disconnected.");
                    currentClientSocket.socket.Close(); 
                    return;
                }
            }
            catch (SocketException)
            {
                AddToChat("Client forcefully disconnected");
                currentClientSocket.socket.Close();
                return;
            }

            /*
                The bytes are read as a packet and converted into a string.
                The 'AddToChat' function adds the received string to the chatbox display.
            */
            byte[] recBuf = new byte[received];
            Array.Copy(currentClientSocket.buffer, recBuf, received);
            string text = Encoding.ASCII.GetString(recBuf);

            string[] incomingText = text.Split(" ");

            switch (incomingText[0].ToLower()) 
            {
                case "!login":
                    if (incomingText[1] == "valid")
                    {
                        forms.loginForm.Hide();
                        forms.chatForm.Show();
                    }
                    else 
                    {
                        forms.loginForm.SetErrorLabel(string.Join(", ", incomingText.Skip(1)));
                    }
                    break;
                default:
                    AddToChat(text);
                    break;
                case "!regError":
                    if (incomingText[1] != "") 
                    {
                        forms.registrationForm.SetUsernameError(incomingText[1]);
                    }
                    if (incomingText[2] != "")
                    {
                        forms.registrationForm.SetPasswordError(incomingText[2]);
                    }
                    if (incomingText[3] != "")
                    {
                        forms.registrationForm.SetEmailError(incomingText[3]);
                    }
                    break;
            }                    
            //continue listening for more data
            currentClientSocket.socket.BeginReceive(currentClientSocket.buffer, 0, ClientSocket.BUFFER_SIZE, SocketFlags.None, ReceiveCallback, currentClientSocket);
        }

        /*
            Closes the current socket connection.
        */
        public void Close()
        {
            socket.Close();
        }
    }

}
