namespace GUI
{
    partial class TienThua
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TienThua));
            this.lblTienThua = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDongY = new Custom.ButonQuanAo();
            this.SuspendLayout();
            // 
            // lblTienThua
            // 
            this.lblTienThua.AutoSize = true;
            this.lblTienThua.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienThua.ForeColor = System.Drawing.Color.Red;
            this.lblTienThua.Location = new System.Drawing.Point(121, 92);
            this.lblTienThua.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTienThua.Name = "lblTienThua";
            this.lblTienThua.Size = new System.Drawing.Size(70, 27);
            this.lblTienThua.TabIndex = 3;
            this.lblTienThua.Text = "label2";
            this.lblTienThua.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(76, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tiền trả khách";
            // 
            // btnDongY
            // 
            this.btnDongY.BackColor = System.Drawing.Color.Red;
            this.btnDongY.BackgroundColor = System.Drawing.Color.Red;
            this.btnDongY.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnDongY.BorderRadius = 20;
            this.btnDongY.BorderSize = 0;
            this.btnDongY.FlatAppearance.BorderSize = 0;
            this.btnDongY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDongY.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDongY.ForeColor = System.Drawing.Color.White;
            this.btnDongY.Image = ((System.Drawing.Image)(resources.GetObject("btnDongY.Image")));
            this.btnDongY.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDongY.Location = new System.Drawing.Point(109, 151);
            this.btnDongY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDongY.Name = "btnDongY";
            this.btnDongY.Size = new System.Drawing.Size(103, 60);
            this.btnDongY.TabIndex = 4;
            this.btnDongY.Text = "Đồng ý";
            this.btnDongY.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDongY.TextColor = System.Drawing.Color.White;
            this.btnDongY.UseVisualStyleBackColor = false;
            this.btnDongY.Click += new System.EventHandler(this.btnDongY_Click);
            // 
            // TienThua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 226);
            this.Controls.Add(this.btnDongY);
            this.Controls.Add(this.lblTienThua);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TienThua";
            this.Text = "TienThua";
            this.Load += new System.EventHandler(this.TienThua_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTienThua;
        private System.Windows.Forms.Label label1;
        private Custom.ButonQuanAo btnDongY;
    }
}