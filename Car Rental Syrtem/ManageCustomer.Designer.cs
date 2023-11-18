namespace creat_car_rental_system
{
    partial class ManageCustomer
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
            this.cmb_cusid = new System.Windows.Forms.ComboBox();
            this.txt_mobile = new System.Windows.Forms.TextBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.txt_address = new System.Windows.Forms.TextBox();
            this.txt_usrname = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmb_cusid
            // 
            this.cmb_cusid.FormattingEnabled = true;
            this.cmb_cusid.Location = new System.Drawing.Point(137, 142);
            this.cmb_cusid.Name = "cmb_cusid";
            this.cmb_cusid.Size = new System.Drawing.Size(224, 24);
            this.cmb_cusid.TabIndex = 0;
            // 
            // txt_mobile
            // 
            this.txt_mobile.Location = new System.Drawing.Point(137, 297);
            this.txt_mobile.Name = "txt_mobile";
            this.txt_mobile.Size = new System.Drawing.Size(224, 22);
            this.txt_mobile.TabIndex = 1;
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(137, 248);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(224, 22);
            this.txt_name.TabIndex = 2;
            // 
            // txt_address
            // 
            this.txt_address.Location = new System.Drawing.Point(515, 248);
            this.txt_address.Name = "txt_address";
            this.txt_address.Size = new System.Drawing.Size(224, 22);
            this.txt_address.TabIndex = 3;
            // 
            // txt_usrname
            // 
            this.txt_usrname.Location = new System.Drawing.Point(515, 297);
            this.txt_usrname.Name = "txt_usrname";
            this.txt_usrname.Size = new System.Drawing.Size(224, 22);
            this.txt_usrname.TabIndex = 4;
            // 
            // ManageCars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(1025, 616);
            this.Controls.Add(this.txt_usrname);
            this.Controls.Add(this.txt_address);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.txt_mobile);
            this.Controls.Add(this.cmb_cusid);
            this.Name = "ManageCars";
            this.Text = "ManageCars";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_cusid;
        private System.Windows.Forms.TextBox txt_mobile;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.TextBox txt_address;
        private System.Windows.Forms.TextBox txt_usrname;
    }
}