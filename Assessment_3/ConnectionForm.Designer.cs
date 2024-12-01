namespace Windows_Forms_CORE_CHAT_UGH
{
    partial class ConnectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionForm));
            connectionPanel = new System.Windows.Forms.Panel();
            errorLabel = new System.Windows.Forms.Label();
            portTextBox = new System.Windows.Forms.TextBox();
            serverIPTextBox = new System.Windows.Forms.TextBox();
            serverIPLabel = new System.Windows.Forms.Label();
            portLabel = new System.Windows.Forms.Label();
            joinButton = new System.Windows.Forms.Button();
            hostButton = new System.Windows.Forms.Button();
            connectionPanel.SuspendLayout();
            SuspendLayout();
            // 
            // connectionPanel
            // 
            connectionPanel.BackgroundImage = (System.Drawing.Image)resources.GetObject("connectionPanel.BackgroundImage");
            connectionPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            connectionPanel.Controls.Add(errorLabel);
            connectionPanel.Controls.Add(portTextBox);
            connectionPanel.Controls.Add(serverIPTextBox);
            connectionPanel.Controls.Add(serverIPLabel);
            connectionPanel.Controls.Add(portLabel);
            connectionPanel.Controls.Add(joinButton);
            connectionPanel.Controls.Add(hostButton);
            connectionPanel.Location = new System.Drawing.Point(0, 0);
            connectionPanel.Name = "connectionPanel";
            connectionPanel.Size = new System.Drawing.Size(479, 339);
            connectionPanel.TabIndex = 18;
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.BackColor = System.Drawing.Color.Transparent;
            errorLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            errorLabel.ForeColor = System.Drawing.Color.Yellow;
            errorLabel.Location = new System.Drawing.Point(30, 314);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new System.Drawing.Size(0, 15);
            errorLabel.TabIndex = 16;
            // 
            // portTextBox
            // 
            portTextBox.Location = new System.Drawing.Point(130, 221);
            portTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            portTextBox.Name = "portTextBox";
            portTextBox.Size = new System.Drawing.Size(110, 23);
            portTextBox.TabIndex = 1;
            portTextBox.Tag = "hosting";
            portTextBox.Text = "6666";
            // 
            // serverIPTextBox
            // 
            serverIPTextBox.Location = new System.Drawing.Point(256, 221);
            serverIPTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            serverIPTextBox.Name = "serverIPTextBox";
            serverIPTextBox.Size = new System.Drawing.Size(140, 23);
            serverIPTextBox.TabIndex = 5;
            serverIPTextBox.Text = "127.0.0.1";
            // 
            // serverIPLabel
            // 
            serverIPLabel.AutoSize = true;
            serverIPLabel.BackColor = System.Drawing.Color.Transparent;
            serverIPLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            serverIPLabel.ForeColor = System.Drawing.Color.White;
            serverIPLabel.Location = new System.Drawing.Point(256, 204);
            serverIPLabel.Name = "serverIPLabel";
            serverIPLabel.Size = new System.Drawing.Size(59, 15);
            serverIPLabel.TabIndex = 4;
            serverIPLabel.Text = "Server IP";
            // 
            // portLabel
            // 
            portLabel.AutoSize = true;
            portLabel.BackColor = System.Drawing.Color.Transparent;
            portLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            portLabel.ForeColor = System.Drawing.Color.White;
            portLabel.Location = new System.Drawing.Point(130, 204);
            portLabel.Name = "portLabel";
            portLabel.Size = new System.Drawing.Size(31, 15);
            portLabel.TabIndex = 0;
            portLabel.Tag = "hosting";
            portLabel.Text = "Port";
            // 
            // joinButton
            // 
            joinButton.BackColor = System.Drawing.Color.White;
            joinButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            joinButton.FlatAppearance.BorderSize = 0;
            joinButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(255, 192, 128);
            joinButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PeachPuff;
            joinButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            joinButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            joinButton.ForeColor = System.Drawing.Color.Blue;
            joinButton.Location = new System.Drawing.Point(256, 270);
            joinButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            joinButton.Name = "joinButton";
            joinButton.Size = new System.Drawing.Size(79, 39);
            joinButton.TabIndex = 9;
            joinButton.Tag = "hosting";
            joinButton.Text = "Join Server";
            joinButton.UseVisualStyleBackColor = false;
            joinButton.Click += JoinButton_Click;
            // 
            // hostButton
            // 
            hostButton.BackColor = System.Drawing.Color.White;
            hostButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            hostButton.FlatAppearance.BorderSize = 0;
            hostButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(255, 192, 128);
            hostButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PeachPuff;
            hostButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            hostButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            hostButton.ForeColor = System.Drawing.Color.Blue;
            hostButton.Location = new System.Drawing.Point(161, 270);
            hostButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            hostButton.Name = "hostButton";
            hostButton.Size = new System.Drawing.Size(79, 39);
            hostButton.TabIndex = 9;
            hostButton.Tag = "hosting";
            hostButton.Text = "Host Server";
            hostButton.UseVisualStyleBackColor = false;
            hostButton.Click += HostButton_Click;
            // 
            // ConnectionForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(478, 338);
            Controls.Add(connectionPanel);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "ConnectionForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "ChatterBox - Connect";
            connectionPanel.ResumeLayout(false);
            connectionPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel connectionPanel;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.TextBox serverIPTextBox;
        private System.Windows.Forms.Label serverIPLabel;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Button joinButton;
        private System.Windows.Forms.Button hostButton;
        private System.Windows.Forms.Label errorLabel;
    }
}