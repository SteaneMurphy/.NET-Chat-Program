using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;


//https://www.youtube.com/watch?v=xgLRe7QV6QI&ab_channel=HazardEditHazardEdit
namespace Windows_Forms_Chat
{
    public partial class ChatForm : Form
    {
        TicTacToe ticTacToe = new TicTacToe();
        TCPChatServer server = null;
        TCPChatClient client = null;

        public ChatForm()
        {
            InitializeComponent();
            BackColor = Color.FromArgb(0, 117, 231);
            ForeColor = Color.FromArgb(45, 118, 253);
            chatTextBox.BackColor = Color.FromArgb(246, 246, 246);
            chatTextBox.SelectionLength = 0;
            chatTextBox.SelectionStart = 0;
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (client != null && client.socket.Connected)
            {
                client.SendString(typeTextBox.Text);
            }
            else if (server != null) 
            {
                string[] incomingText = typeTextBox.Text.Split(" ");
                if (incomingText[0] == "!mod") 
                {
                    foreach (ClientSocket c in server.clientSockets) 
                    {
                        if (incomingText[1] == c.username) 
                        {
                            if (c.mod) 
                            {
                                c.mod = false;
                            }
                            else 
                            {
                                c.mod = true;
                            }
                        }
                    }
                }

                server.SendToAll(typeTextBox.Text, null);
            }
            else 
            {
                chatTextBox.Text = "Message not sent - You are not connected to a server";
            }
        }

        private void TypeTextBox_Enter(object sender, EventArgs e)
        {
            if (typeTextBox.Text == " Type your message here...") 
            {
                typeTextBox.Clear();
                typeTextBox.ForeColor = Color.Black;
            }
        }

        private void TypeTextBox_Leave(object sender, EventArgs e) 
        {
            if (string.IsNullOrWhiteSpace(typeTextBox.Text))
            {
                typeTextBox.Text = " Type your message here...";
                typeTextBox.ForeColor = SystemColors.GradientActiveCaption;
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //On form loaded
            //ticTacToe.buttons.Add(button1);
            //ticTacToe.buttons.Add(button2);
            //ticTacToe.buttons.Add(button3);
            //ticTacToe.buttons.Add(button4);
            //ticTacToe.buttons.Add(button5);
            //ticTacToe.buttons.Add(button6);
            //ticTacToe.buttons.Add(button7);
            //ticTacToe.buttons.Add(button8);
            //ticTacToe.buttons.Add(button9);
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
                    chatTextBox.AppendText("X wins!");
                    chatTextBox.AppendText(Environment.NewLine);
                    ticTacToe.ResetBoard();
                }
                if (gs == GameState.naughtWins)
                {
                    chatTextBox.AppendText(") wins!");
                    chatTextBox.AppendText(Environment.NewLine);
                    ticTacToe.ResetBoard();
                }
                if (gs == GameState.draw)
                {
                    chatTextBox.AppendText("Draw!");
                    chatTextBox.AppendText(Environment.NewLine);
                    ticTacToe.ResetBoard();
                }
            }
        }

        public TextBox ChatTextBox
        {
            get { return chatTextBox; }
        }

        public void UpdateClient(TCPChatClient _client) 
        {
            client = _client;
        }

        public void UpdateServer(TCPChatServer _server)
        {
            server = _server;
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
