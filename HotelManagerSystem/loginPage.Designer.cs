namespace HotelManagerSystem
{
    partial class loginPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginPage));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.staffIDText = new System.Windows.Forms.TextBox();
            this.staffID = new System.Windows.Forms.Label();
            this.staffPassword = new System.Windows.Forms.Label();
            this.staffPasswordText = new System.Windows.Forms.TextBox();
            this.Login = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(323, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(142, 121);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Perpetua", 18.33962F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(259, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome to Hotel-706";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // staffIDText
            // 
            this.staffIDText.Location = new System.Drawing.Point(297, 245);
            this.staffIDText.Name = "staffIDText";
            this.staffIDText.Size = new System.Drawing.Size(188, 20);
            this.staffIDText.TabIndex = 2;
            this.staffIDText.TextChanged += new System.EventHandler(this.adminIDText_TextChanged);
            // 
            // staffID
            // 
            this.staffID.AutoSize = true;
            this.staffID.Font = new System.Drawing.Font("Perpetua", 10.86792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffID.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.staffID.Location = new System.Drawing.Point(295, 225);
            this.staffID.Name = "staffID";
            this.staffID.Size = new System.Drawing.Size(53, 18);
            this.staffID.TabIndex = 3;
            this.staffID.Text = "Staff ID";
            this.staffID.Click += new System.EventHandler(this.adminID_Click);
            // 
            // staffPassword
            // 
            this.staffPassword.AutoSize = true;
            this.staffPassword.Font = new System.Drawing.Font("Perpetua", 10.86792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffPassword.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.staffPassword.Location = new System.Drawing.Point(295, 273);
            this.staffPassword.Name = "staffPassword";
            this.staffPassword.Size = new System.Drawing.Size(63, 18);
            this.staffPassword.TabIndex = 5;
            this.staffPassword.Text = "Password";
            // 
            // staffPasswordText
            // 
            this.staffPasswordText.Location = new System.Drawing.Point(297, 293);
            this.staffPasswordText.Name = "staffPasswordText";
            this.staffPasswordText.Size = new System.Drawing.Size(189, 20);
            this.staffPasswordText.TabIndex = 4;
            this.staffPasswordText.TextChanged += new System.EventHandler(this.AdminPasswordText_TextChanged);
            // 
            // Login
            // 
            this.Login.Font = new System.Drawing.Font("Perpetua", 10.86792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login.Location = new System.Drawing.Point(341, 341);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(105, 29);
            this.Login.TabIndex = 6;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // loginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.staffPassword);
            this.Controls.Add(this.staffPasswordText);
            this.Controls.Add(this.staffID);
            this.Controls.Add(this.staffIDText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "loginPage";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.loginPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox staffIDText;
        private System.Windows.Forms.Label staffID;
        private System.Windows.Forms.Label staffPassword;
        private System.Windows.Forms.TextBox staffPasswordText;
        private System.Windows.Forms.Button Login;
    }
}

