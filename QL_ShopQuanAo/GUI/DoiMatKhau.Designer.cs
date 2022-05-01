namespace GUI
{
    partial class DoiMatKhau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoiMatKhau));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassCu = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.txtRePassMoi = new Custom.txtPassword();
            this.txtPassMoi = new Custom.txtPassword();
            this.butonQuanAo1 = new Custom.ButonQuanAo();
            this.butonQuanAo2 = new Custom.ButonQuanAo();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mật khẩu cũ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nhập lại mật khẩu mới";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(54, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mật khẩu mới";
            // 
            // txtPassCu
            // 
            this.txtPassCu.Location = new System.Drawing.Point(227, 43);
            this.txtPassCu.Name = "txtPassCu";
            this.txtPassCu.Size = new System.Drawing.Size(180, 20);
            this.txtPassCu.TabIndex = 5;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Yellow;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBox1.Image = ((System.Drawing.Image)(resources.GetObject("checkBox1.Image")));
            this.checkBox1.Location = new System.Drawing.Point(435, 34);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(45, 30);
            this.checkBox1.TabIndex = 122;
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.BackColor = System.Drawing.Color.Yellow;
            this.checkBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBox2.Image = ((System.Drawing.Image)(resources.GetObject("checkBox2.Image")));
            this.checkBox2.Location = new System.Drawing.Point(435, 91);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(45, 30);
            this.checkBox2.TabIndex = 123;
            this.checkBox2.UseVisualStyleBackColor = false;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.BackColor = System.Drawing.Color.Yellow;
            this.checkBox3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBox3.Image = ((System.Drawing.Image)(resources.GetObject("checkBox3.Image")));
            this.checkBox3.Location = new System.Drawing.Point(435, 146);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(45, 30);
            this.checkBox3.TabIndex = 124;
            this.checkBox3.UseVisualStyleBackColor = false;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // txtRePassMoi
            // 
            this.txtRePassMoi.Location = new System.Drawing.Point(227, 155);
            this.txtRePassMoi.Name = "txtRePassMoi";
            this.txtRePassMoi.Size = new System.Drawing.Size(180, 20);
            this.txtRePassMoi.TabIndex = 4;
            this.txtRePassMoi.UseSystemPasswordChar = true;
            // 
            // txtPassMoi
            // 
            this.txtPassMoi.Location = new System.Drawing.Point(227, 101);
            this.txtPassMoi.Name = "txtPassMoi";
            this.txtPassMoi.Size = new System.Drawing.Size(180, 20);
            this.txtPassMoi.TabIndex = 3;
            this.txtPassMoi.UseSystemPasswordChar = true;
            // 
            // butonQuanAo1
            // 
            this.butonQuanAo1.BackColor = System.Drawing.Color.Red;
            this.butonQuanAo1.BackgroundColor = System.Drawing.Color.Red;
            this.butonQuanAo1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.butonQuanAo1.BorderRadius = 20;
            this.butonQuanAo1.BorderSize = 0;
            this.butonQuanAo1.FlatAppearance.BorderSize = 0;
            this.butonQuanAo1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butonQuanAo1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butonQuanAo1.ForeColor = System.Drawing.Color.White;
            this.butonQuanAo1.Image = ((System.Drawing.Image)(resources.GetObject("butonQuanAo1.Image")));
            this.butonQuanAo1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butonQuanAo1.Location = new System.Drawing.Point(127, 216);
            this.butonQuanAo1.Name = "butonQuanAo1";
            this.butonQuanAo1.Size = new System.Drawing.Size(131, 39);
            this.butonQuanAo1.TabIndex = 125;
            this.butonQuanAo1.Text = "Đổi mật khẩu";
            this.butonQuanAo1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butonQuanAo1.TextColor = System.Drawing.Color.White;
            this.butonQuanAo1.UseVisualStyleBackColor = false;
            // 
            // butonQuanAo2
            // 
            this.butonQuanAo2.BackColor = System.Drawing.Color.Green;
            this.butonQuanAo2.BackgroundColor = System.Drawing.Color.Green;
            this.butonQuanAo2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.butonQuanAo2.BorderRadius = 20;
            this.butonQuanAo2.BorderSize = 0;
            this.butonQuanAo2.FlatAppearance.BorderSize = 0;
            this.butonQuanAo2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butonQuanAo2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butonQuanAo2.ForeColor = System.Drawing.Color.White;
            this.butonQuanAo2.Image = ((System.Drawing.Image)(resources.GetObject("butonQuanAo2.Image")));
            this.butonQuanAo2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butonQuanAo2.Location = new System.Drawing.Point(326, 216);
            this.butonQuanAo2.Name = "butonQuanAo2";
            this.butonQuanAo2.Size = new System.Drawing.Size(81, 39);
            this.butonQuanAo2.TabIndex = 126;
            this.butonQuanAo2.Text = "Thoát";
            this.butonQuanAo2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butonQuanAo2.TextColor = System.Drawing.Color.White;
            this.butonQuanAo2.UseVisualStyleBackColor = false;
            this.butonQuanAo2.Click += new System.EventHandler(this.butonQuanAo2_Click);
            // 
            // DoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(551, 317);
            this.Controls.Add(this.butonQuanAo2);
            this.Controls.Add(this.butonQuanAo1);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.txtPassCu);
            this.Controls.Add(this.txtRePassMoi);
            this.Controls.Add(this.txtPassMoi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DoiMatKhau";
            this.Text = "DoiMatKhau";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Custom.txtPassword txtPassMoi;
        private Custom.txtPassword txtRePassMoi;
        private System.Windows.Forms.TextBox txtPassCu;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private Custom.ButonQuanAo butonQuanAo1;
        private Custom.ButonQuanAo butonQuanAo2;
    }
}