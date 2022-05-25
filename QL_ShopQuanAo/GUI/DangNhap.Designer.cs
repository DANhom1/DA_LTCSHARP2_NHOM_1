namespace GUI
{
    partial class DangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangNhap));
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.butonQuanAo1 = new Custom.ButonQuanAo();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.SystemColors.Info;
            this.checkBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.checkBox1.Image = ((System.Drawing.Image)(resources.GetObject("checkBox1.Image")));
            this.checkBox1.Location = new System.Drawing.Point(499, 220);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(48, 30);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(239, 100);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(243, 42);
            this.label3.TabIndex = 14;
            this.label3.Text = "ĐĂNG NHẬP";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(277, 218);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(197, 35);
            this.txtPassword.TabIndex = 18;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(277, 164);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(197, 35);
            this.txtUsername.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(113, 220);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 26);
            this.label2.TabIndex = 17;
            this.label2.Text = "Mật khẩu:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(108, 164);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 26);
            this.label1.TabIndex = 15;
            this.label1.Text = "Tài khoản:";
            // 
            // butonQuanAo1
            // 
            this.butonQuanAo1.BackColor = System.Drawing.Color.Fuchsia;
            this.butonQuanAo1.BackgroundColor = System.Drawing.Color.Fuchsia;
            this.butonQuanAo1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.butonQuanAo1.BorderRadius = 20;
            this.butonQuanAo1.BorderSize = 0;
            this.butonQuanAo1.FlatAppearance.BorderSize = 0;
            this.butonQuanAo1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butonQuanAo1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butonQuanAo1.ForeColor = System.Drawing.Color.White;
            this.butonQuanAo1.Image = ((System.Drawing.Image)(resources.GetObject("butonQuanAo1.Image")));
            this.butonQuanAo1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butonQuanAo1.Location = new System.Drawing.Point(301, 276);
            this.butonQuanAo1.Margin = new System.Windows.Forms.Padding(4);
            this.butonQuanAo1.Name = "butonQuanAo1";
            this.butonQuanAo1.Size = new System.Drawing.Size(149, 54);
            this.butonQuanAo1.TabIndex = 20;
            this.butonQuanAo1.Text = "Đăng nhập";
            this.butonQuanAo1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butonQuanAo1.TextColor = System.Drawing.Color.White;
            this.butonQuanAo1.UseVisualStyleBackColor = false;
            this.butonQuanAo1.Click += new System.EventHandler(this.butonQuanAo1_Click);
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(671, 410);
            this.Controls.Add(this.butonQuanAo1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DangNhap";
            this.Text = "DangNhap";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Custom.ButonQuanAo butonQuanAo1;
    }
}