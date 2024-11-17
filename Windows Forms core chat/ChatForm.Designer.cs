namespace Windows_Forms_Chat
{
    partial class ChatForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatForm));
            chatTextBox = new System.Windows.Forms.TextBox();
            typeTextBox = new System.Windows.Forms.TextBox();
            sendButton = new System.Windows.Forms.Button();
            panel1 = new System.Windows.Forms.Panel();
            SuspendLayout();
            // 
            // chatTextBox
            // 
            chatTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            chatTextBox.Location = new System.Drawing.Point(230, 0);
            chatTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            chatTextBox.Multiline = true;
            chatTextBox.Name = "chatTextBox";
            chatTextBox.ReadOnly = true;
            chatTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            chatTextBox.Size = new System.Drawing.Size(908, 608);
            chatTextBox.TabIndex = 6;
            chatTextBox.Text = "\r\n";
            // 
            // typeTextBox
            // 
            typeTextBox.BackColor = System.Drawing.SystemColors.Window;
            typeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            typeTextBox.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            typeTextBox.Location = new System.Drawing.Point(230, 607);
            typeTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            typeTextBox.Name = "typeTextBox";
            typeTextBox.Size = new System.Drawing.Size(832, 23);
            typeTextBox.TabIndex = 7;
            typeTextBox.Text = " Type your message here...";
            typeTextBox.Enter += TypeTextBox_Enter;
            typeTextBox.Leave += TypeTextBox_Leave;
            // 
            // sendButton
            // 
            sendButton.BackColor = System.Drawing.SystemColors.Highlight;
            sendButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            sendButton.FlatAppearance.BorderSize = 0;
            sendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            sendButton.ForeColor = System.Drawing.Color.White;
            sendButton.Location = new System.Drawing.Point(1059, 607);
            sendButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            sendButton.Name = "sendButton";
            sendButton.Size = new System.Drawing.Size(79, 23);
            sendButton.TabIndex = 11;
            sendButton.Text = "Send";
            sendButton.UseVisualStyleBackColor = false;
            sendButton.Click += SendButton_Click;
            // 
            // panel1
            // 
            panel1.Location = new System.Drawing.Point(-1, -4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(232, 634);
            panel1.TabIndex = 16;
            // 
            // ChatForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(1137, 630);
            Controls.Add(sendButton);
            Controls.Add(typeTextBox);
            Controls.Add(chatTextBox);
            Controls.Add(panel1);
            ForeColor = System.Drawing.SystemColors.ActiveCaption;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "ChatForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "ChatterBox";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TextBox chatTextBox;
        private System.Windows.Forms.TextBox typeTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Panel panel1;
    }
}

