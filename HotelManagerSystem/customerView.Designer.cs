namespace HotelManagerSystem
{
    partial class customerView
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
            this.backButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.identityNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cSurname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.telNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.checkInDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.checkOutDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.guests = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.roomNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.totalPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(12, 11);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(59, 23);
            this.backButton.TabIndex = 5;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(343, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "CUSTOMERS";
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.identityNumber,
            this.cName,
            this.cSurname,
            this.telNumber,
            this.email,
            this.checkInDate,
            this.checkOutDate,
            this.guests,
            this.roomNumber,
            this.totalPrice});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 66);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(873, 420);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // identityNumber
            // 
            this.identityNumber.Text = "Identity Number";
            this.identityNumber.Width = 87;
            // 
            // cName
            // 
            this.cName.Text = "Name";
            this.cName.Width = 64;
            // 
            // cSurname
            // 
            this.cSurname.Text = "Surname";
            this.cSurname.Width = 74;
            // 
            // telNumber
            // 
            this.telNumber.Text = "Phone Number";
            this.telNumber.Width = 127;
            // 
            // email
            // 
            this.email.Text = "email";
            this.email.Width = 116;
            // 
            // checkInDate
            // 
            this.checkInDate.Text = "Check In Date";
            this.checkInDate.Width = 107;
            // 
            // checkOutDate
            // 
            this.checkOutDate.Text = "Check Out Date";
            this.checkOutDate.Width = 106;
            // 
            // guests
            // 
            this.guests.Text = "Guests";
            this.guests.Width = 52;
            // 
            // roomNumber
            // 
            this.roomNumber.Text = "RoomNumber";
            this.roomNumber.Width = 87;
            // 
            // totalPrice
            // 
            this.totalPrice.Text = "Total Price";
            this.totalPrice.Width = 74;
            // 
            // customerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 507);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Name = "customerView";
            this.Text = "customerView";
            this.Load += new System.EventHandler(this.customerView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader identityNumber;
        private System.Windows.Forms.ColumnHeader cName;
        private System.Windows.Forms.ColumnHeader cSurname;
        private System.Windows.Forms.ColumnHeader telNumber;
        private System.Windows.Forms.ColumnHeader email;
        private System.Windows.Forms.ColumnHeader checkInDate;
        private System.Windows.Forms.ColumnHeader checkOutDate;
        private System.Windows.Forms.ColumnHeader guests;
        private System.Windows.Forms.ColumnHeader roomNumber;
        private System.Windows.Forms.ColumnHeader totalPrice;
    }
}