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
            typeTextBox = new System.Windows.Forms.TextBox();
            sendButton = new System.Windows.Forms.Button();
            panel1 = new System.Windows.Forms.Panel();
            chatTextBox = new System.Windows.Forms.RichTextBox();
            button5 = new System.Windows.Forms.Button();
            button6 = new System.Windows.Forms.Button();
            button4 = new System.Windows.Forms.Button();
            button7 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            button8 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            button9 = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // typeTextBox
            // 
            typeTextBox.BackColor = System.Drawing.SystemColors.Window;
            typeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            typeTextBox.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            typeTextBox.Location = new System.Drawing.Point(-1, 275);
            typeTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            typeTextBox.Name = "typeTextBox";
            typeTextBox.Size = new System.Drawing.Size(580, 23);
            typeTextBox.TabIndex = 7;
            typeTextBox.Text = " Type your message here...";
            typeTextBox.Enter += TypeTextBox_Enter;
            typeTextBox.KeyDown += typeTextBox_KeyDown;
            typeTextBox.Leave += TypeTextBox_Leave;
            // 
            // sendButton
            // 
            sendButton.BackColor = System.Drawing.SystemColors.Highlight;
            sendButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            sendButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            sendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            sendButton.ForeColor = System.Drawing.Color.White;
            sendButton.Location = new System.Drawing.Point(578, 275);
            sendButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            sendButton.Name = "sendButton";
            sendButton.Size = new System.Drawing.Size(86, 23);
            sendButton.TabIndex = 11;
            sendButton.Text = "Send";
            sendButton.UseVisualStyleBackColor = false;
            sendButton.Click += SendButton_Click;
            // 
            // panel1
            // 
            panel1.Location = new System.Drawing.Point(-1, -4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(232, 284);
            panel1.TabIndex = 16;
            // 
            // chatTextBox
            // 
            chatTextBox.BackColor = System.Drawing.SystemColors.Control;
            chatTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            chatTextBox.Location = new System.Drawing.Point(230, 0);
            chatTextBox.Name = "chatTextBox";
            chatTextBox.ReadOnly = true;
            chatTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            chatTextBox.Size = new System.Drawing.Size(434, 280);
            chatTextBox.TabIndex = 17;
            chatTextBox.Text = "";
            // 
            // button5
            // 
            button5.BackColor = System.Drawing.SystemColors.Highlight;
            button5.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button5.ForeColor = System.Drawing.SystemColors.ControlText;
            button5.Location = new System.Drawing.Point(760, 83);
            button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(82, 74);
            button5.TabIndex = 22;
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.BackColor = System.Drawing.SystemColors.Highlight;
            button6.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button6.ForeColor = System.Drawing.SystemColors.ControlText;
            button6.Location = new System.Drawing.Point(848, 83);
            button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            button6.Name = "button6";
            button6.Size = new System.Drawing.Size(82, 74);
            button6.TabIndex = 23;
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button4
            // 
            button4.BackColor = System.Drawing.SystemColors.Highlight;
            button4.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button4.ForeColor = System.Drawing.SystemColors.ControlText;
            button4.Location = new System.Drawing.Point(672, 83);
            button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(82, 74);
            button4.TabIndex = 21;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button7
            // 
            button7.BackColor = System.Drawing.SystemColors.Highlight;
            button7.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button7.ForeColor = System.Drawing.SystemColors.ControlText;
            button7.Location = new System.Drawing.Point(672, 161);
            button7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            button7.Name = "button7";
            button7.Size = new System.Drawing.Size(82, 74);
            button7.TabIndex = 24;
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // button3
            // 
            button3.BackColor = System.Drawing.SystemColors.Highlight;
            button3.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button3.ForeColor = System.Drawing.SystemColors.ControlText;
            button3.Location = new System.Drawing.Point(848, 5);
            button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(82, 74);
            button3.TabIndex = 20;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button8
            // 
            button8.BackColor = System.Drawing.SystemColors.Highlight;
            button8.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button8.ForeColor = System.Drawing.SystemColors.ControlText;
            button8.Location = new System.Drawing.Point(760, 161);
            button8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            button8.Name = "button8";
            button8.Size = new System.Drawing.Size(82, 74);
            button8.TabIndex = 25;
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // button2
            // 
            button2.BackColor = System.Drawing.SystemColors.Highlight;
            button2.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button2.ForeColor = System.Drawing.SystemColors.ControlText;
            button2.Location = new System.Drawing.Point(760, 5);
            button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(82, 74);
            button2.TabIndex = 19;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button9
            // 
            button9.BackColor = System.Drawing.SystemColors.Highlight;
            button9.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button9.ForeColor = System.Drawing.SystemColors.ControlText;
            button9.Location = new System.Drawing.Point(848, 161);
            button9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            button9.Name = "button9";
            button9.Size = new System.Drawing.Size(82, 74);
            button9.TabIndex = 26;
            button9.UseVisualStyleBackColor = false;
            button9.Click += button9_Click;
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.SystemColors.Highlight;
            button1.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button1.ForeColor = System.Drawing.SystemColors.ControlText;
            button1.Location = new System.Drawing.Point(672, 5);
            button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(82, 74);
            button1.TabIndex = 18;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // ChatForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(933, 298);
            Controls.Add(button1);
            Controls.Add(sendButton);
            Controls.Add(button5);
            Controls.Add(button9);
            Controls.Add(typeTextBox);
            Controls.Add(button6);
            Controls.Add(chatTextBox);
            Controls.Add(button2);
            Controls.Add(panel1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button8);
            Controls.Add(button7);
            ForeColor = System.Drawing.SystemColors.ActiveCaption;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "ChatForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "ChatterBox";
            Load += ChatForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TextBox typeTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox chatTextBox;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button1;
    }
}

