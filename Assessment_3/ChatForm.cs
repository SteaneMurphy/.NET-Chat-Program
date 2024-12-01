using System;
using System.Drawing;
using System.Windows.Forms;
using Windows_Forms_CORE_CHAT_UGH;

namespace Windows_Forms_Chat
{
    /*
        This class is the form for the main chat program. It provides UI elements initialisation
        and functionality for event triggers like button clicks.
    */
    public partial class ChatForm : Form
    {
        //reference to instance of server and connected client
        TCPChatServer server = null;
        TCPChatClient client = null;
        TicTacToe ticTacToe = new TicTacToe();

        public ChatForm()
        {
            //initialise UI elements and colours
            InitializeComponent();
            BackColor = Color.FromArgb(0, 117, 231);
            ForeColor = Color.FromArgb(45, 118, 253);
            chatTextBox.BackColor = Color.FromArgb(246, 246, 246);
            chatTextBox.SelectionLength = 0;
            chatTextBox.SelectionStart = 0;
        }


        /*
            This function sends the text from the input text box to the server.
            It first checks if the event is being sent from a client or server instance
            and sends accordingly.

            As the server is the only instance allowed to promote or demote moderators, the
            check for this command at instance level is carried out here.
        */
        private void SendButton_Click(object sender, EventArgs e)
        {
            HandleInput();
        }

        private void typeTextBox_KeyDown(object sender, KeyEventArgs e) 
        {
            if(e.KeyCode == Keys.Enter) 
            {
                e.SuppressKeyPress = true;
                HandleInput();
            }
        }

        private void HandleInput() 
        {
            if (client != null && client.socket.Connected)
            {
                client.SendString(typeTextBox.Text);
            }
            else if (server != null)
            {
                //split out the command string and check for "!mod"
                string[] incomingText = typeTextBox.Text.Split(" ");
                if (incomingText[0] == "!mod")
                {
                    //if username matches provided username, change their mod status
                    foreach (ClientSocket clientSocket in server.clientSockets)
                    {
                        if (incomingText[1] == clientSocket.username)
                        {
                            clientSocket.mod = !clientSocket.mod;
                            server.AddToChat($"{clientSocket.username} moderator status: {clientSocket.mod}");
                        }
                    }
                    return;
                }
                //split out the command string and check for "!mods"
                //check each connected client to see if their moderator status is true
                //provide a list to the chatbox for all mods
                if (incomingText[0] == "!mods") 
                {
                    server.AddToChat("The following moderators are connected: ");
                    foreach (ClientSocket clientSocket in server.clientSockets) 
                    {
                        if (clientSocket.mod) 
                        {
                            server.AddToChat($" - {clientSocket.username}");
                        }
                    }
                    return;
                }
                //send to all clients
                server.SendToAll(typeTextBox.Text, null);
            }
            //not connected to a server
            else
            {
                chatTextBox.Text = "Message not sent - You are not connected to a server";
            }
            typeTextBox.Clear();
            typeTextBox.Focus();
        }

        /*
            When the input text box has focus, clear the default message
            and change the font colour.
        */
        private void TypeTextBox_Enter(object sender, EventArgs e)
        {
            if (typeTextBox.Text == " Type your message here...") 
            {
                typeTextBox.Clear();
                typeTextBox.ForeColor = Color.Black;
            }
        }

        /*
            When the input text box loses focus, check to see if a message is partially
            written, if the text box is empty, then show the default message and change
            the font colour.
        */
        private void TypeTextBox_Leave(object sender, EventArgs e) 
        {
            if (string.IsNullOrWhiteSpace(typeTextBox.Text))
            {
                typeTextBox.Text = " Type your message here...";
                typeTextBox.ForeColor = SystemColors.GradientActiveCaption;
            };
        }

        /*
            'chatTextBox' is private by default. Provides access to this UI
            element outside of this class.
        */
        public RichTextBox ChatTextBox
        {
            get { return chatTextBox; }
        }

        /*
            Updates both the client and server variables from outside this class.
        */
        public void UpdateClient(TCPChatClient _client) 
        {
            client = _client;
        }

        public void UpdateServer(TCPChatServer _server)
        {
            server = _server;
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {
            //On form loaded
            ticTacToe.buttons.Add(button1);
            ticTacToe.buttons.Add(button2);
            ticTacToe.buttons.Add(button3);
            ticTacToe.buttons.Add(button4);
            ticTacToe.buttons.Add(button5);
            ticTacToe.buttons.Add(button6);
            ticTacToe.buttons.Add(button7);
            ticTacToe.buttons.Add(button8);
            ticTacToe.buttons.Add(button9);
        }

        private void AttemptMove(int i)
        {
            if (ticTacToe.myTurn)
            {
                bool validMove = ticTacToe.SetTile(i, ticTacToe.playerTileType);
                if (validMove)
                {
                    //tell server about it
                    //ticTacToe.myTurn = false;//call this too when ready with server
                }
                //example, do something similar from server
                GameState gs = ticTacToe.GetGameState();
                if (gs == GameState.crossWins)
                {
                    ChatTextBox.AppendText("X wins!");
                    ChatTextBox.AppendText(Environment.NewLine);
                    ticTacToe.ResetBoard();
                }
                if (gs == GameState.naughtWins)
                {
                    ChatTextBox.AppendText("O wins!");
                    ChatTextBox.AppendText(Environment.NewLine);
                    ticTacToe.ResetBoard();
                }
                if (gs == GameState.draw)
                {
                    ChatTextBox.AppendText("Draw!");
                    ChatTextBox.AppendText(Environment.NewLine);
                    ticTacToe.ResetBoard();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AttemptMove(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AttemptMove(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AttemptMove(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AttemptMove(3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AttemptMove(4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AttemptMove(5);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AttemptMove(6);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AttemptMove(7);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AttemptMove(8);
        }
    }
}
