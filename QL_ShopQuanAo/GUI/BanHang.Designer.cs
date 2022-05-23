namespace GUI
{
    partial class BanHang
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
            this.txt_tongtien = new System.Windows.Forms.TextBox();
            this.txt_giamgia = new System.Windows.Forms.TextBox();
            this.txtThanhToan = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_tongtien
            // 
            this.txt_tongtien.Enabled = false;
            this.txt_tongtien.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txt_tongtien.Location = new System.Drawing.Point(1538, 868);
            this.txt_tongtien.Margin = new System.Windows.Forms.Padding(5);
            this.txt_tongtien.Multiline = true;
            this.txt_tongtien.Name = "txt_tongtien";
            this.txt_tongtien.Size = new System.Drawing.Size(240, 39);
            this.txt_tongtien.TabIndex = 81;
            this.txt_tongtien.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_giamgia
            // 
            this.txt_giamgia.Enabled = false;
            this.txt_giamgia.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_giamgia.Location = new System.Drawing.Point(1538, 928);
            this.txt_giamgia.Margin = new System.Windows.Forms.Padding(5);
            this.txt_giamgia.Multiline = true;
            this.txt_giamgia.Name = "txt_giamgia";
            this.txt_giamgia.Size = new System.Drawing.Size(240, 39);
            this.txt_giamgia.TabIndex = 83;
            this.txt_giamgia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtThanhToan
            // 
            this.txtThanhToan.Enabled = false;
            this.txtThanhToan.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtThanhToan.Location = new System.Drawing.Point(1538, 992);
            this.txtThanhToan.Margin = new System.Windows.Forms.Padding(5);
            this.txtThanhToan.Multiline = true;
            this.txtThanhToan.Name = "txtThanhToan";
            this.txtThanhToan.Size = new System.Drawing.Size(240, 39);
            this.txtThanhToan.TabIndex = 84;
            this.txtThanhToan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 327);
            this.Controls.Add(this.txtThanhToan);
            this.Controls.Add(this.txt_giamgia);
            this.Controls.Add(this.txt_tongtien);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BanHang";
            this.Text = "BanHang";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_tongtien;
        private System.Windows.Forms.TextBox txt_giamgia;
        private System.Windows.Forms.TextBox txtThanhToan;
    }
}