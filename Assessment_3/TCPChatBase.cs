using System;
using System.Drawing;
using System.Windows.Forms;

namespace Windows_Forms_Chat
{

    public class TCPChatBase
    {
        public RichTextBox chatTextBox;
        public int port;
        public void SetChat(string str)
        {
            chatTextBox.Invoke((Action)delegate
            {
                chatTextBox.Text = str;
                chatTextBox.AppendText(Environment.NewLine);
            });
        }

        /*
            This function is used to render text onto each each instance's chatbox display.
            The 'Invoke' function allows for access and modification of the chatbox outside
            of its parent thread ('ChatForm').
        */
        public void AddToChat(string str)
        {
            if (chatTextBox.IsHandleCreated) 
            {
                chatTextBox.Invoke((Action)delegate
                {
                    chatTextBox.AppendText(str);
                    chatTextBox.AppendText(Environment.NewLine);
                });
            }    
        }
    }
}
