using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.ComponentModel;
using System.Linq;

//https://github.com/AbleOpus/NetworkingSamples/blob/master/MultiServer/Program.cs
namespace Windows_Forms_Chat
{
    public class TCPChatServer : TCPChatBase
    {
        
        public Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //connected clients
        public List<ClientSocket> clientSockets = new List<ClientSocket>();

        public static TCPChatServer createInstance(int port, TextBox chatTextBox, Label errorLabel)
        {
            TCPChatServer tcp = null;
            //setup if port within range and valid chat box given
            try
            {
                if (port > 0 && port < 65535 && chatTextBox != null)
                {
                    tcp = new TCPChatServer();
                    tcp.port = port;
                    tcp.chatTextBox = chatTextBox;
                }
            }
            catch (Exception) 
            {
                errorLabel.Text = "Port was invalid";
            }

            //return empty if user not enter useful details
            return tcp;
        }

        public void SetupServer()
        {
            chatTextBox.Clear();
            chatTextBox.Text += "Setting up server...\r\n";
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, port));
            serverSocket.Listen(0);
            //kick off thread to read connecting clients, when one connects, it'll call out AcceptCallback function
            serverSocket.BeginAccept(AcceptCallback, this);
            chatTextBox.Text += "Server setup complete\r\n";
        }

        public void CloseAllSockets()
        {
            foreach (ClientSocket clientSocket in clientSockets)
            {
                clientSocket.socket.Shutdown(SocketShutdown.Both);
                clientSocket.socket.Close();
            }
            clientSockets.Clear();
            serverSocket.Close();
        }

        public void AcceptCallback(IAsyncResult AR)
        {
            Socket joiningSocket;

            try
            {
                joiningSocket = serverSocket.EndAccept(AR);
            }
            catch (ObjectDisposedException) // I cannot seem to avoid this (on exit when properly closing sockets)
            {
                return;
            }

            ClientSocket newClientSocket = new ClientSocket();
            newClientSocket.socket = joiningSocket;

            clientSockets.Add(newClientSocket);
            //start a thread to listen out for this new joining socket. Therefore there is a thread open for each client
            joiningSocket.BeginReceive(newClientSocket.buffer, 0, ClientSocket.BUFFER_SIZE, SocketFlags.None, ReceiveCallback, newClientSocket);
            //Console.WriteLine(newClientSocket.username);
            AddToChat("Client connected, waiting for request...\r\n");

            //we finished this accept thread, better kick off another so more people can join
            serverSocket.BeginAccept(AcceptCallback, null);
        }

        public void ReceiveCallback(IAsyncResult AR)
        {
            ClientSocket currentClientSocket = (ClientSocket)AR.AsyncState;
            
            int received;

            try
            {
                received = currentClientSocket.socket.EndReceive(AR);
            }
            catch (SocketException)
            {
                AddToChat("Client forcefully disconnected");
                // Don't shutdown because the socket may be disposed and its disconnected anyway.
                currentClientSocket.socket.Close();
                clientSockets.Remove(currentClientSocket);
                return;
            }

            byte[] recBuf = new byte[received];
            Array.Copy(currentClientSocket.buffer, recBuf, received);
            string text = Encoding.ASCII.GetString(recBuf);

            AddToChat( text );

            string[] incomingText = text.Split(" ");

            switch (incomingText[0].ToLower()) 
            {
                case "!commands":
                    byte[] data = Encoding.ASCII.GetBytes("Commands are !commands !user !who !about !whisper !exit !custom");
                    currentClientSocket.socket.Send(data);
                    AddToChat("Commands sent to client");
                    break;
                case "!username":
                    AddToChat("Change username request");
                    if (ValidateUsername(incomingText[1]))
                    {
                        currentClientSocket.username = incomingText[1];
                        SendToAll($"{currentClientSocket.username} has entered the chat!", currentClientSocket);
                    }
                    else
                    {
                        AddToChat("Username already exists, disconnecting client");
                        currentClientSocket.socket.Shutdown(SocketShutdown.Both);
                        currentClientSocket.socket.Close();
                        clientSockets.Remove(currentClientSocket);
                        AddToChat("Client disconnected");
                    }
                    break;
                case "!user":
                    AddToChat("Change username request");
                    if (ValidateUsername(incomingText[1]))
                    {                        
                        SendToAll($"{currentClientSocket.username} has changed their username to {incomingText[1]}", currentClientSocket);
                        currentClientSocket.username = incomingText[1];
                    }
                    else 
                    {
                        AddToChat("Username already in use, please choose another name");
                    }
                    break;
                case "!who":
                    SendBack("The current users connected to this server are:", currentClientSocket);
                    foreach (ClientSocket c in clientSockets) 
                    {                      
                        SendBack($" - {c.username}\r\n", currentClientSocket);
                    }
                        break;
                case "!about":
                    SendBack("Welcome to this ChatterBox service. This is a prototype chat program designed to test and learn .NET socket programming and add " +
                             "to the creator's portfolio. The creator of this program is James Murphy, a web developer and software engineering student at " +
                             "Torrens University. This program was created in November of 2024 to meet the Assessment 2 guidelines for the subject NDS203.", currentClientSocket);
                    break;
                case "!whisper":
                    ClientSocket clientTo = null;
                    if (currentClientSocket.username == incomingText[1]) 
                    {
                        SendBack("Sorry, you cannot send private messages to yourself", currentClientSocket);
                    }
                    else 
                    {
                        foreach (ClientSocket c in clientSockets)
                        {
                            if (c.username == incomingText[1])
                            {
                                clientTo = c;
                                SendToOne(string.Join(" ", incomingText.Skip(2)), currentClientSocket, clientTo);
                                SendBack(string.Join(" ", incomingText.Skip(2)), currentClientSocket, false);
                                currentClientSocket.socket.BeginReceive(currentClientSocket.buffer, 0, ClientSocket.BUFFER_SIZE, SocketFlags.None, ReceiveCallback, currentClientSocket);
                                return;
                            }
                            if (c.username == currentClientSocket.username)
                            {
                                continue;
                            }
                        }
                        SendBack("Sorry, it seems that this user is not connected to the server, please check the username and try again", currentClientSocket);
                    }
                    break;
                case "!exit":
                    // Always Shutdown before closing
                    currentClientSocket.socket.Shutdown(SocketShutdown.Both);
                    currentClientSocket.socket.Close();
                    clientSockets.Remove(currentClientSocket);
                    AddToChat("Client disconnected");
                    break;
                case "!custom":
                    break;
                default:
                    //normal message broadcast out to all clients
                    SendToAll(text, currentClientSocket, false);
                    break;
            }
            //we just received a message from this socket, better keep an ear out with another thread for the next one
            currentClientSocket.socket.BeginReceive(currentClientSocket.buffer, 0, ClientSocket.BUFFER_SIZE, SocketFlags.None, ReceiveCallback, currentClientSocket);
        }

        public void SendToAll(string str, ClientSocket from, bool systemMsg = true)
        {
            foreach (ClientSocket c in clientSockets)
            {
                if(from == null || !from.socket.Equals(c))
                {
                    if (systemMsg) 
                    {
                        byte[] data = Encoding.ASCII.GetBytes(str);
                        c.socket.Send(data);
                    }
                    else 
                    {
                        byte[] data = Encoding.ASCII.GetBytes($"[{c.username}]: {str}");
                        c.socket.Send(data);
                    }   
                }
            }
        }

        public void SendToOne(string str, ClientSocket clientFrom, ClientSocket clientTo)
        {
            if (clientFrom == null || !clientFrom.socket.Equals(clientTo))
            {
                byte[] data = Encoding.ASCII.GetBytes($"[{clientFrom.username}]: {str}");
                clientTo.socket.Send(data);
            }
        }

        public void SendBack(string str, ClientSocket client, bool systemMsg = true) 
        {
            if (systemMsg)
            {
                byte[] data = Encoding.ASCII.GetBytes(str);
                client.socket.Send(data);
            }
            else
            {
                byte[] data = Encoding.ASCII.GetBytes($"[{client.username}]: {str}");
                client.socket.Send(data);
            }
        }

        public bool ValidateUsername(string newUsername) 
        {
            for (int i = 0; i < clientSockets.Count; i++) 
            {
                if(clientSockets[i].username == newUsername) 
                {
                    return false;
                }
            }
            return true;
        }
    }
}
