namespace Windows_Forms_CORE_CHAT_UGH
{
    partial class RegistrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
            registrationPanel = new System.Windows.Forms.Panel();
            usernameErrorLabel = new System.Windows.Forms.Label();
            backButton = new System.Windows.Forms.Button();
            reenterPasswordTextBox = new System.Windows.Forms.TextBox();
            passwordTextBox = new System.Windows.Forms.TextBox();
            emailTextBox = new System.Windows.Forms.TextBox();
            usernameTextBox = new System.Windows.Forms.TextBox();
            reenterPasswordLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            passwordLabel = new System.Windows.Forms.Label();
            usernameLabel = new System.Windows.Forms.Label();
            createAccountButton = new System.Windows.Forms.Button();
            passwordErrorLabel = new System.Windows.Forms.Label();
            emailErrorLabel = new System.Windows.Forms.Label();
            registrationPanel.SuspendLayout();
            SuspendLayout();
            // 
            // registrationPanel
            // 
            registrationPanel.BackgroundImage = (System.Drawing.Image)resources.GetObject("registrationPanel.BackgroundImage");
            registrationPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            registrationPanel.Controls.Add(emailErrorLabel);
            registrationPanel.Controls.Add(passwordErrorLabel);
            registrationPanel.Controls.Add(usernameErrorLabel);
            registrationPanel.Controls.Add(backButton);
            registrationPanel.Controls.Add(reenterPasswordTextBox);
            registrationPanel.Controls.Add(passwordTextBox);
            registrationPanel.Controls.Add(emailTextBox);
            registrationPanel.Controls.Add(usernameTextBox);
            registrationPanel.Controls.Add(reenterPasswordLabel);
            registrationPanel.Controls.Add(emailLabel);
            registrationPanel.Controls.Add(passwordLabel);
            registrationPanel.Controls.Add(usernameLabel);
            registrationPanel.Controls.Add(createAccountButton);
            registrationPanel.Location = new System.Drawing.Point(0, 0);
            registrationPanel.Name = "registrationPanel";
            registrationPanel.Size = new System.Drawing.Size(479, 339);
            registrationPanel.TabIndex = 20;
            // 
            // usernameErrorLabel
            // 
            usernameErrorLabel.AutoSize = true;
            usernameErrorLabel.BackColor = System.Drawing.Color.Transparent;
            usernameErrorLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            usernameErrorLabel.ForeColor = System.Drawing.Color.Yellow;
            usernameErrorLabel.Location = new System.Drawing.Point(92, 170);
            usernameErrorLabel.Name = "usernameErrorLabel";
            usernameErrorLabel.Size = new System.Drawing.Size(0, 15);
            usernameErrorLabel.TabIndex = 24;
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
            backButton.TabIndex = 23;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = false;
            backButton.Click += BackButton_Click;
            // 
            // reenterPasswordTextBox
            // 
            reenterPasswordTextBox.Location = new System.Drawing.Point(275, 247);
            reenterPasswordTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            reenterPasswordTextBox.Name = "reenterPasswordTextBox";
            reenterPasswordTextBox.Size = new System.Drawing.Size(140, 23);
            reenterPasswordTextBox.TabIndex = 18;
            reenterPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new System.Drawing.Point(275, 202);
            passwordTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new System.Drawing.Size(140, 23);
            passwordTextBox.TabIndex = 17;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new System.Drawing.Point(83, 247);
            emailTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new System.Drawing.Size(140, 23);
            emailTextBox.TabIndex = 16;
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new System.Drawing.Point(83, 202);
            usernameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new System.Drawing.Size(140, 23);
            usernameTextBox.TabIndex = 15;
            // 
            // reenterPasswordLabel
            // 
            reenterPasswordLabel.AutoSize = true;
            reenterPasswordLabel.BackColor = System.Drawing.Color.Transparent;
            reenterPasswordLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            reenterPasswordLabel.ForeColor = System.Drawing.Color.White;
            reenterPasswordLabel.Location = new System.Drawing.Point(275, 230);
            reenterPasswordLabel.Name = "reenterPasswordLabel";
            reenterPasswordLabel.Size = new System.Drawing.Size(113, 15);
            reenterPasswordLabel.TabIndex = 5;
            reenterPasswordLabel.Text = "Re-enter Password";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.BackColor = System.Drawing.Color.Transparent;
            emailLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            emailLabel.ForeColor = System.Drawing.Color.White;
            emailLabel.Location = new System.Drawing.Point(83, 230);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(36, 15);
            emailLabel.TabIndex = 4;
            emailLabel.Text = "Email";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.BackColor = System.Drawing.Color.Transparent;
            passwordLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            passwordLabel.ForeColor = System.Drawing.Color.White;
            passwordLabel.Location = new System.Drawing.Point(275, 185);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new System.Drawing.Size(59, 15);
            passwordLabel.TabIndex = 3;
            passwordLabel.Text = "Password";
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.BackColor = System.Drawing.Color.Transparent;
            usernameLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            usernameLabel.ForeColor = System.Drawing.Color.White;
            usernameLabel.Location = new System.Drawing.Point(83, 185);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new System.Drawing.Size(64, 15);
            usernameLabel.TabIndex = 2;
            usernameLabel.Text = "Username";
            // 
            // createAccountButton
            // 
            createAccountButton.BackColor = System.Drawing.Color.White;
            createAccountButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            createAccountButton.FlatAppearance.BorderSize = 0;
            createAccountButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            createAccountButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            createAccountButton.ForeColor = System.Drawing.Color.Blue;
            createAccountButton.Location = new System.Drawing.Point(206, 287);
            createAccountButton.Name = "createAccountButton";
            createAccountButton.Size = new System.Drawing.Size(79, 39);
            createAccountButton.TabIndex = 1;
            createAccountButton.Text = "Create Account";
            createAccountButton.UseVisualStyleBackColor = false;
            createAccountButton.Click += CreateAccountButton_Click;
            // 
            // passwordErrorLabel
            // 
            passwordErrorLabel.AutoSize = true;
            passwordErrorLabel.BackColor = System.Drawing.Color.Transparent;
            passwordErrorLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            passwordErrorLabel.ForeColor = System.Drawing.Color.Yellow;
            passwordErrorLabel.Location = new System.Drawing.Point(275, 170);
            passwordErrorLabel.Name = "passwordErrorLabel";
            passwordErrorLabel.Size = new System.Drawing.Size(0, 15);
            passwordErrorLabel.TabIndex = 25;
            // 
            // emailErrorLabel
            // 
            emailErrorLabel.AutoSize = true;
            emailErrorLabel.BackColor = System.Drawing.Color.Transparent;
            emailErrorLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            emailErrorLabel.ForeColor = System.Drawing.Color.Yellow;
            emailErrorLabel.Location = new System.Drawing.Point(92, 272);
            emailErrorLabel.Name = "emailErrorLabel";
            emailErrorLabel.Size = new System.Drawing.Size(0, 15);
            emailErrorLabel.TabIndex = 26;
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(478, 338);
            Controls.Add(registrationPanel);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "RegistrationForm";
            Text = "Chatterbox - Registration";
            registrationPanel.ResumeLayout(false);
            registrationPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel registrationPanel;
        private System.Windows.Forms.Button createAccountButton;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label reenterPasswordLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox reenterPasswordTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label usernameErrorLabel;
        private System.Windows.Forms.Label emailErrorLabel;
        private System.Windows.Forms.Label passwordErrorLabel;
    }
}