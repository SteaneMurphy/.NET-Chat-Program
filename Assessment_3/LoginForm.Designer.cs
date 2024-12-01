namespace Windows_Forms_CORE_CHAT_UGH
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            loginPanel = new System.Windows.Forms.Panel();
            backButton = new System.Windows.Forms.Button();
            passwordTextBox = new System.Windows.Forms.TextBox();
            usernameTextBox = new System.Windows.Forms.TextBox();
            passwordLabel = new System.Windows.Forms.Label();
            usernameLabel = new System.Windows.Forms.Label();
            loginButton = new System.Windows.Forms.Button();
            errorLabel = new System.Windows.Forms.Label();
            loginPanel.SuspendLayout();
            SuspendLayout();
            // 
            // loginPanel
            // 
            loginPanel.BackgroundImage = (System.Drawing.Image)resources.GetObject("loginPanel.BackgroundImage");
            loginPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            loginPanel.Controls.Add(errorLabel);
            loginPanel.Controls.Add(backButton);
            loginPanel.Controls.Add(passwordTextBox);
            loginPanel.Controls.Add(usernameTextBox);
            loginPanel.Controls.Add(passwordLabel);
            loginPanel.Controls.Add(usernameLabel);
            loginPanel.Controls.Add(loginButton);
            loginPanel.Location = new System.Drawing.Point(0, 0);
            loginPanel.Name = "loginPanel";
            loginPanel.Size = new System.Drawing.Size(479, 339);
            loginPanel.TabIndex = 20;
            // 
            // backButton
            // 
            backButton.BackColor = System.Drawing.SystemColors.Highlight;
            backButton.FlatAppearance.BorderSize = 0;
            backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            backButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            backButton.ForeColor = System.Drawing.Color.White;
            backButton.Location = new System.Drawing.Point(387, 287);
            backButton.Name = "backButton";
            backButton.Size = new System.Drawing.Size(79, 39);
            backButton.TabIndex = 22;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = false;
            backButton.Click += BackButton_Click;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new System.Drawing.Point(274, 237);
            passwordTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new System.Drawing.Size(140, 23);
            passwordTextBox.TabIndex = 21;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new System.Drawing.Point(82, 237);
            usernameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new System.Drawing.Size(140, 23);
            usernameTextBox.TabIndex = 20;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.BackColor = System.Drawing.Color.Transparent;
            passwordLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            passwordLabel.ForeColor = System.Drawing.Color.White;
            passwordLabel.Location = new System.Drawing.Point(274, 220);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new System.Drawing.Size(59, 15);
            passwordLabel.TabIndex = 19;
            passwordLabel.Text = "Password";
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.BackColor = System.Drawing.Color.Transparent;
            usernameLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            usernameLabel.ForeColor = System.Drawing.Color.White;
            usernameLabel.Location = new System.Drawing.Point(82, 220);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new System.Drawing.Size(64, 15);
            usernameLabel.TabIndex = 18;
            usernameLabel.Text = "Username";
            // 
            // loginButton
            // 
            loginButton.BackColor = System.Drawing.Color.White;
            loginButton.FlatAppearance.BorderSize = 0;
            loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            loginButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            loginButton.ForeColor = System.Drawing.Color.Blue;
            loginButton.Location = new System.Drawing.Point(212, 287);
            loginButton.Name = "loginButton";
            loginButton.Size = new System.Drawing.Size(79, 39);
            loginButton.TabIndex = 2;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += LoginButton_Click;
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.BackColor = System.Drawing.Color.Transparent;
            errorLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            errorLabel.ForeColor = System.Drawing.Color.Yellow;
            errorLabel.Location = new System.Drawing.Point(82, 191);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new System.Drawing.Size(0, 15);
            errorLabel.TabIndex = 23;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(478, 338);
            Controls.Add(loginPanel);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "LoginForm";
            Text = "Chatterbox - Login";
            loginPanel.ResumeLayout(false);
            loginPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel loginPanel;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label errorLabel;
    }
}