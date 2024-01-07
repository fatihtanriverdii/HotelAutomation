namespace HotelManagerSystem
{
    partial class managerLoginPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(managerLoginPage));
            this.Login = new System.Windows.Forms.Button();
            this.adminPassword = new System.Windows.Forms.Label();
            this.adminPasswordText = new System.Windows.Forms.TextBox();
            this.adminID = new System.Windows.Forms.Label();
            this.adminIDText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Login
            // 
            this.Login.Font = new System.Drawing.Font("Perpetua", 10.86792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login.Location = new System.Drawing.Point(347, 356);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(105, 29);
            this.Login.TabIndex = 13;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // adminPassword
            // 
            this.adminPassword.AutoSize = true;
            this.adminPassword.Font = new System.Drawing.Font("Perpetua", 10.86792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminPassword.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.adminPassword.Location = new System.Drawing.Point(301, 290);
            this.adminPassword.Name = "adminPassword";
            this.adminPassword.Size = new System.Drawing.Size(63, 18);
            this.adminPassword.TabIndex = 12;
            this.adminPassword.Text = "Password";
            // 
            // adminPasswordText
            // 
            this.adminPasswordText.Location = new System.Drawing.Point(303, 308);
            this.adminPasswordText.Name = "adminPasswordText";
            this.adminPasswordText.Size = new System.Drawing.Size(189, 20);
            this.adminPasswordText.TabIndex = 11;
            this.adminPasswordText.TextChanged += new System.EventHandler(this.adminPasswordText_TextChanged);
            // 
            // adminID
            // 
            this.adminID.AutoSize = true;
            this.adminID.Font = new System.Drawing.Font("Perpetua", 10.86792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminID.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.adminID.Location = new System.Drawing.Point(301, 242);
            this.adminID.Name = "adminID";
            this.adminID.Size = new System.Drawing.Size(78, 18);
            this.adminID.TabIndex = 10;
            this.adminID.Text = "Manager ID";
            // 
            // adminIDText
            // 
            this.adminIDText.Location = new System.Drawing.Point(303, 260);
            this.adminIDText.Name = "adminIDText";
            this.adminIDText.Size = new System.Drawing.Size(188, 20);
            this.adminIDText.TabIndex = 9;
            this.adminIDText.TextChanged += new System.EventHandler(this.adminIDText_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Perpetua", 18.33962F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(333, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 31);
            this.label1.TabIndex = 8;
            this.label1.Text = "Welcome!";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(329, 65);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(142, 121);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Perpetua", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(12, 12);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 14;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // managerLoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.adminPassword);
            this.Controls.Add(this.adminPasswordText);
            this.Controls.Add(this.adminID);
            this.Controls.Add(this.adminIDText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "managerLoginPage";
            this.Text = "managerLoginPage";
            this.Load += new System.EventHandler(this.managerLoginPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.Label adminPassword;
        private System.Windows.Forms.TextBox adminPasswordText;
        private System.Windows.Forms.Label adminID;
        private System.Windows.Forms.TextBox adminIDText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button backButton;
    }
}