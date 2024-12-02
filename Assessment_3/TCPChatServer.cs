using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Linq;
using Windows_Forms_CORE_CHAT_UGH;

namespace Windows_Forms_Chat
{
    public class TCPChatServer : TCPChatBase
    {
        /*
            These variables are server specific. A reference to the current instance of the server's socket as well
            as a list of all connected clients.
        */
        public Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public List<ClientSocket> clientSockets = new List<ClientSocket>();
        DatabaseManagement db = new DatabaseManagement();
        Validation validation;

        /*
            This function creates a new instance of 'TCPChatServer' which is the server the clients are connected to.
            The function checks for a valid port (between 0 and 65535) and that a chat text box exists.

            Exceptions: as we are only testing whether a port is within range, this general exception returns an
            invalid port message.
        */
        public static TCPChatServer createInstance(int port, RichTextBox chatTextBox, Label errorLabel)
        {
            TCPChatServer tcp = null;
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

            return tcp;
        }

        /*
            This function is called once when a new server instance is created. It initialises the form, binds the
            socket to the provided port number and begins listening for any incoming connections with the 'Listen' and
            'BeginAccept' socket functions. 'BeginAccept' opens a new thread that awaits a TCP socket connection.
        */
        public void SetupServer()
        {
            chatTextBox.Clear();
            chatTextBox.Text += "Setting up server...\r\n";
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, port));
            serverSocket.Listen(0);
            serverSocket.BeginAccept(AcceptCallback, this);
            chatTextBox.Text += "Server setup complete\r\n";
            db.InitialiseDatabase(db.GetURI());
            validation = new Validation(db);
        }

        /*
            This function iterates through all connected clients and gracefully disconnects each client.
            A graceful disconnection procedure requires the sockets on both the server and client to no longer
            send anymore information, this is acheived with the 'Shutdown' function. Once information has ceased
            the socket is closed and the 'Close' function is called on the server itself, to close its 'serverSocket' down.
            Finally, the client is notified of the disconnection, and a message appears on the server's client for any administrators.
        */
        public void CloseAllSockets()
        {
            foreach (ClientSocket clientSocket in clientSockets)
            {
                AddToChat($"Closing connection to {clientSocket.username}");
                SendBack("Server is closing your connection to the server", clientSocket);
                clientSocket.socket.Shutdown(SocketShutdown.Both);
                clientSocket.socket.Close();
            }
            clientSockets.Clear();
            AddToChat("Server socket is shutting down");
            serverSocket.Close();
        }

        /*
            This function is awaiting connections to the server. The server assigns this connection to a new
            client socket and closes the async operation (BeginAccept) with 'EndAccept'. Once the new socket
            has been connected, a new thread 'BeginReceive' is created to listen for data being sent from this
            new connection.

            At the end of the function 'BeginAccept' is called again to listen for and allow new client socket
            connections. These would start new threads.

            Exceptions: the client may close their chat program before the connection completes in which case the
            joiningSocket will be null. The 'ObjectDisposed' exception catches this and exits the async operation.
        */
        public void AcceptCallback(IAsyncResult AR)
        {
            Socket joiningSocket;

            try
            {
                joiningSocket = serverSocket.EndAccept(AR);
            }
            catch (ObjectDisposedException)
            {
                return;
            }

            ClientSocket newClientSocket = new ClientSocket();
            newClientSocket.socket = joiningSocket;
            clientSockets.Add(newClientSocket);
            joiningSocket.BeginReceive(newClientSocket.buffer, 0, ClientSocket.BUFFER_SIZE, SocketFlags.None, ReceiveCallback, newClientSocket);
            AddToChat("Client connected, waiting for request...\r\n");

            serverSocket.BeginAccept(AcceptCallback, null);
        }

        /*
            This function listens for data from a socket connection thread.
        */
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
            catch (Exception ex) 
            {
                AddToChat("Client no longer connected");
                return;
            }

            byte[] recBuf = new byte[received];
            Array.Copy(currentClientSocket.buffer, recBuf, received);
            string text = Encoding.ASCII.GetString(recBuf);

            AddToChat($"[{currentClientSocket.username}]: {text}");

            string[] incomingText = text.Split(" ");
            switch (incomingText[0].ToLower())
            {
                /*
                    This commands sends a message back to the requesting client. The message is a list of available commands
                    a user can perform in the chat server.
                */
                case "!commands":
                    SendBack("Commands are !commands !user !who !about !whisper !exit !away !back", currentClientSocket);
                    AddToChat("Commands sent to client");
                    break;

                /*
                    This command either sets a username when a client first connects or changes a connected client's username
                    once they are connected. The function provides username validation to ensure that no two usernames can exist
                    on the server at the same time.
                    
                    If a client tries to connect using an existing username, they are gracefully disconnected.
                */
                case "!user":
                    if (currentClientSocket.username == null)
                    {
                        AddToChat("New username validation");
                        if (ValidateUsername(incomingText[1]))
                        {
                            currentClientSocket.username = incomingText[1];
                            SendToAll($"{currentClientSocket.username} has entered the chat!", currentClientSocket);
                        }
                        else
                        {
                            AddToChat("Username already exists, disconnecting client");
                            SendBack("Username already exists, disconnecting from server", currentClientSocket);
                            currentClientSocket.socket.Shutdown(SocketShutdown.Both);
                            currentClientSocket.socket.Close();
                            clientSockets.Remove(currentClientSocket);
                            AddToChat("Client disconnected");
                            return;
                        }
                    }
                    else 
                    {
                        AddToChat("Change username request");
                        if (ValidateUsername(incomingText[1]))
                        {                           
                            SendToAll($"{currentClientSocket.username} has changed their username to {incomingText[1]}", currentClientSocket);
                            currentClientSocket.username = incomingText[1];
                        }
                        else
                        {
                            AddToChat("Username request failed");
                            SendBack("Username already in use, please choose another name", currentClientSocket);
                        }
                    }
                    break;  
                /*
                    This command sends a message back to the requesting client. The message is a list of all connected client usernames.
                    The 'clientSockets' list is iterated through and each client.username is printed to the chatbox.
                */
                case "!who":
                    AddToChat("Sending client list of connected users");
                    SendBack("The current users connected to this server are:", currentClientSocket);
                    foreach (ClientSocket c in clientSockets)
                    {
                        SendBack($" - {c.username}\r\n", currentClientSocket);
                    }
                    break;

                /*
                    This command sends a message back to the requesting client. The message provides insight into the server and program.
                */
                case "!about":
                    AddToChat("Sending client information about this server");
                    SendBack("Welcome to this ChatterBox service. This is a prototype chat program designed to test and learn .NET socket programming and add " +
                             "to the creator's portfolio. The creator of this program is James Murphy, a web developer and software engineering student at " +
                             "Torrens University. This program was created in November of 2024 to meet the Assessment 2 guidelines for the subject NDS203.", currentClientSocket);
                    break;
                /*
                    This command allows a client to send a private message to another client.
                    The command checks that the user is not sending a message to themselves, and then iterates through the list
                    of connected client usernames to find a match.

                    If a match is found, both clients have the message delivered to their chatbox, with correct name tags.
                    The message is sliced into seperate words, the command word removed and the remaining message joined back up
                    for sending. The function also checks if the user is away or not, if the user is away, the receiving client sends back
                    an away message to the original sender.

                    When a message is successfully sent, due to returning out of the function, the socket's 'BeginReceive' function needs to be called again
                    so that client communincation can continue.
                */
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
                            try
                            {
                                if (c.username == incomingText[1])
                                {
                                    clientTo = c;
                                    SendToOne(string.Join(" ", incomingText.Skip(2)), currentClientSocket, clientTo);
                                    SendBack(string.Join(" ", incomingText.Skip(2)), currentClientSocket, false);
                                    if (c.away)
                                    {
                                        SendBackAway($"{c.awayMessage}", currentClientSocket, c);
                                    }
                                    currentClientSocket.socket.BeginReceive(currentClientSocket.buffer, 0, ClientSocket.BUFFER_SIZE, SocketFlags.None, ReceiveCallback, currentClientSocket);
                                    return;
                                }
                                if (c.username == currentClientSocket.username)
                                {
                                    continue;
                                }
                            }
                            catch (Exception) 
                            {
                            
                            }   
                        }
                        SendBack("Sorry, it seems that this user is not connected to the server, please check the username and try again", currentClientSocket);
                    }
                    break;
                /*
                    This command allows a user to gracefully exit the chat program and disconnect the socket.
                */
                case "!exit":
                    currentClientSocket.socket.Shutdown(SocketShutdown.Both);
                    currentClientSocket.socket.Close();
                    clientSockets.Remove(currentClientSocket);
                    AddToChat("Client disconnected");
                    break;
                /*
                    This command allows a user to set a custom away message and set their state to away.
                    Whilst in this state, any private messages will be automatically responded to with an
                    away message.
                */
                case "!away":
                    SendBack("Your away message has been set to: ", currentClientSocket);
                    SendBack($"{string.Join(" ", incomingText.Skip(1))}", currentClientSocket);
                    currentClientSocket.away = true;
                    currentClientSocket.awayMessage = string.Join(" ", incomingText.Skip(1));
                    break;
                /*
                    This command removes a client's away state and removes their away message.
                */
                case "!back":
                    SendBack("Your away message has been cleared, welcome back!", currentClientSocket);
                    currentClientSocket.away = false;
                    currentClientSocket.awayMessage = "";
                    break;
                /*
                    This command can only be used by a client that has the 'mod' state. This command will kick
                    whatever client has been provided to the command via username.

                    The command takes the provided username and iterates over the list of existing client username. When
                    a match is found, that client's connection is shutdown and closed gracefully.
                */
                case "!kick":
                    if (currentClientSocket.mod) 
                    {
                        foreach (ClientSocket c in clientSockets)
                        {
                            if (incomingText[1] == c.username)
                            {
                                AddToChat($"{c.username} has been removed from the channel");
                                SendToAll($"{c.username} has been removed from the channel", currentClientSocket);
                                try 
                                {
                                    c.socket.Shutdown(SocketShutdown.Both);
                                    c.socket.Close();
                                }
                                catch (SocketException ex)
                                {
                                    AddToChat($"Error closing socket: {ex.Message}");
                                }
                                clientSockets.Remove(c);
                                break;
                            }
                        }
                    }
                    else 
                    {
                        SendBack("Only moderators can kick another user", currentClientSocket);
                    }
                    break;

                case "!login":
                    (bool valid, string errorMessage) = validation.ValidateLogin(incomingText[1], incomingText[2]);
                    if (valid)
                    {
                        SendBack("!login valid", currentClientSocket);
                        currentClientSocket.username = incomingText[1];
                        SendToAll($"{currentClientSocket.username} has entered the chat!", currentClientSocket);
                        currentClientSocket.stateLogin = false;
                        currentClientSocket.stateChatting = true;
                    }
                    else 
                    {
                        SendBack($"!login {errorMessage}", currentClientSocket);
                    }
                    break;
                case "!register":
                    (bool registrationValid, 
                     string usernameError, 
                     string passwordError, 
                     string emailError) = validation.ValidateRegistration(incomingText[1], incomingText[2], incomingText[3], incomingText[4]);

                    if (registrationValid) 
                    {
                        db.AddEntry(incomingText[1], incomingText[2], incomingText[3]);
                        SendBack("!regvalid", currentClientSocket);
                        currentClientSocket.username = incomingText[1];
                        SendToAll($"{currentClientSocket.username} has entered the chat!", currentClientSocket);
                        currentClientSocket.stateLogin = false;
                        currentClientSocket.stateChatting = true;
                    }
                    else 
                    {
                        SendBack($"!regError {usernameError} {passwordError} {emailError}", currentClientSocket);
                    }
                    Console.WriteLine($"regValid: {registrationValid}, userErr: {usernameError}, passErr: {passwordError}, emailErr: {emailError}");
                    break;
                /*
                    If no command is detected, whatever text was sent to the server is broadcast to all connected clients.
                */
                default:
                    SendToAll(text, currentClientSocket, false);
                    break;
            }
            //this line keeps the thread open and allows for further communication between this client and the server.
            currentClientSocket.socket.BeginReceive(currentClientSocket.buffer, 0, ClientSocket.BUFFER_SIZE, SocketFlags.None, ReceiveCallback, currentClientSocket);
        }

        /*
            This function sends a message to each connected client's chatbox. The option is given
            to send to all as a server system message (without a name) or with the sending client's
            username.

            The function uses the 'GetBytes' function to convert the given string into a byte array.
            This array is then send over the socket and received by each client. On the client end,
            the byte array is turned back into a string and rendered on the relevant chatbox.
        */
        public void SendToAll(string str, ClientSocket from, bool systemMsg = true)
        {
            foreach (ClientSocket c in clientSockets)
            {
                if (from == null || !from.socket.Equals(c))
                {
                    if (systemMsg)
                    {
                        byte[] data = Encoding.ASCII.GetBytes(str);
                        c.socket.Send(data);
                    }
                    else
                    {
                        byte[] data = Encoding.ASCII.GetBytes($"[{from.username}]: {str}");
                        c.socket.Send(data);
                    }
                }
            }
        }

        /*
            This function sends from one client to another client. This functionality is used for
            the private messaging feature.

            The string to be sent is converted into a byte array using the 'GetBytes' function and sent
            to the 'clientTo' client socket.
        */
        public void SendToOne(string str, ClientSocket clientFrom, ClientSocket clientTo)
        {
            if (clientFrom == null || !clientFrom.socket.Equals(clientTo))
            {
                byte[] data = Encoding.ASCII.GetBytes($"[{clientFrom.username}]: {str}");
                clientTo.socket.Send(data);
            }
        }

        /*
            This function sends a message from the server straight back to the originating client.
            It is useful for one-way communication and system messages to one client only.
        */
        public void SendBack(string str, ClientSocket client, bool systemMsg = true, ClientSocket clientFrom = null)
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

        /*
            This function deals with sending the away message to the originating client.
        */
        public void SendBackAway(string str, ClientSocket client, ClientSocket clientFrom) 
        {
            byte[] data = Encoding.ASCII.GetBytes($"[{clientFrom.username} - Away]: {str}");
            client.socket.Send(data);
        }

        /*
            This function validates a given username.
            It iterates through each connected client and compares
            the proposed username against their usernames.
            If a match is found, the function returns back false.
        */
        public bool ValidateUsername(string newUsername)
        {
            for (int i = 0; i < clientSockets.Count; i++)
            {
                if (clientSockets[i].username == newUsername)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
