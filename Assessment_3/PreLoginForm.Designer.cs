namespace Windows_Forms_CORE_CHAT_UGH
{
    partial class PreLoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreLoginForm));
            loginButton = new System.Windows.Forms.Button();
            registerButton = new System.Windows.Forms.Button();
            loginPanel = new System.Windows.Forms.Panel();
            subheadingLabel = new System.Windows.Forms.Label();
            backButton = new System.Windows.Forms.Button();
            loginPanel.SuspendLayout();
            SuspendLayout();
            // 
            // loginButton
            // 
            loginButton.BackColor = System.Drawing.Color.White;
            loginButton.FlatAppearance.BorderSize = 0;
            loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            loginButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            loginButton.ForeColor = System.Drawing.Color.Blue;
            loginButton.Location = new System.Drawing.Point(257, 239);
            loginButton.Name = "loginButton";
            loginButton.Size = new System.Drawing.Size(79, 39);
            loginButton.TabIndex = 2;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += LoginButton_Click;
            // 
            // registerButton
            // 
            registerButton.BackColor = System.Drawing.Color.White;
            registerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            registerButton.FlatAppearance.BorderSize = 0;
            registerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            registerButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            registerButton.ForeColor = System.Drawing.Color.Blue;
            registerButton.Location = new System.Drawing.Point(133, 239);
            registerButton.Name = "registerButton";
            registerButton.Size = new System.Drawing.Size(79, 39);
            registerButton.TabIndex = 1;
            registerButton.Text = "Register";
            registerButton.UseVisualStyleBackColor = false;
            registerButton.Click += RegisterButton_Click;
            // 
            // loginPanel
            // 
            loginPanel.BackgroundImage = (System.Drawing.Image)resources.GetObject("loginPanel.BackgroundImage");
            loginPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            loginPanel.Controls.Add(backButton);
            loginPanel.Controls.Add(subheadingLabel);
            loginPanel.Controls.Add(registerButton);
            loginPanel.Controls.Add(loginButton);
            loginPanel.Location = new System.Drawing.Point(0, 0);
            loginPanel.Name = "loginPanel";
            loginPanel.Size = new System.Drawing.Size(479, 339);
            loginPanel.TabIndex = 19;
            // 
            // subheadingLabel
            // 
            subheadingLabel.AutoSize = true;
            subheadingLabel.BackColor = System.Drawing.Color.Transparent;
            subheadingLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            subheadingLabel.ForeColor = System.Drawing.Color.White;
            subheadingLabel.Location = new System.Drawing.Point(8, 198);
            subheadingLabel.Name = "subheadingLabel";
            subheadingLabel.Size = new System.Drawing.Size(468, 15);
            subheadingLabel.TabIndex = 20;
            subheadingLabel.Text = "You are connected to the server. Please login or register a new account to continue";
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
            // PreLoginForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(478, 338);
            Controls.Add(loginPanel);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "PreLoginForm";
            Text = "Chatterbox - Connected";
            loginPanel.ResumeLayout(false);
            loginPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Panel loginPanel;
        private System.Windows.Forms.Label subheadingLabel;
        private System.Windows.Forms.Button backButton;
    }
}