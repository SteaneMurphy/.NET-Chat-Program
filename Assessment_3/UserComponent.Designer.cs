namespace Windows_Forms_CORE_CHAT_UGH
{
    partial class UserComponent
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserComponent));
            pictureBox1 = new System.Windows.Forms.PictureBox();
            usernameLabel = new System.Windows.Forms.Label();
            modLabel = new System.Windows.Forms.Label();
            awayLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(32, 34);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new System.Drawing.Point(41, 3);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new System.Drawing.Size(38, 15);
            usernameLabel.TabIndex = 1;
            usernameLabel.Text = "label1";
            // 
            // modLabel
            // 
            modLabel.AutoSize = true;
            modLabel.Location = new System.Drawing.Point(41, 22);
            modLabel.Name = "modLabel";
            modLabel.Size = new System.Drawing.Size(38, 15);
            modLabel.TabIndex = 2;
            modLabel.Text = "label2";
            // 
            // awayLabel
            // 
            awayLabel.AutoSize = true;
            awayLabel.Location = new System.Drawing.Point(191, 3);
            awayLabel.Name = "awayLabel";
            awayLabel.Size = new System.Drawing.Size(38, 15);
            awayLabel.TabIndex = 3;
            awayLabel.Text = "label1";
            // 
            // UserComponent
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(awayLabel);
            Controls.Add(modLabel);
            Controls.Add(usernameLabel);
            Controls.Add(pictureBox1);
            Name = "UserComponent";
            Size = new System.Drawing.Size(232, 40);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label modLabel;
        private System.Windows.Forms.Label awayLabel;
    }
}
