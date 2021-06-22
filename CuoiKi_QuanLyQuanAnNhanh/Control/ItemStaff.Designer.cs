
namespace CuoiKi_QuanLyQuanAnNhanh.Control
{
    partial class ItemStaff
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
            this.pbxAnh = new System.Windows.Forms.PictureBox();
            this.lbTen = new System.Windows.Forms.Label();
            this.lbChucVu = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAnh)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxAnh
            // 
            this.pbxAnh.Location = new System.Drawing.Point(0, 0);
            this.pbxAnh.Name = "pbxAnh";
            this.pbxAnh.Size = new System.Drawing.Size(229, 184);
            this.pbxAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxAnh.TabIndex = 0;
            this.pbxAnh.TabStop = false;
            this.pbxAnh.Click += new System.EventHandler(this.pbxAnh_Click);
            // 
            // lbTen
            // 
            this.lbTen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTen.Location = new System.Drawing.Point(3, 187);
            this.lbTen.Name = "lbTen";
            this.lbTen.Size = new System.Drawing.Size(224, 27);
            this.lbTen.TabIndex = 1;
            this.lbTen.Text = "Ten: Pham Ngoc Duc";
            this.lbTen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbChucVu
            // 
            this.lbChucVu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChucVu.Location = new System.Drawing.Point(0, 214);
            this.lbChucVu.Name = "lbChucVu";
            this.lbChucVu.Size = new System.Drawing.Size(230, 27);
            this.lbChucVu.TabIndex = 1;
            this.lbChucVu.Text = "Nhan Vien";
            this.lbChucVu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ItemStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lbChucVu);
            this.Controls.Add(this.lbTen);
            this.Controls.Add(this.pbxAnh);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ItemStaff";
            this.Size = new System.Drawing.Size(228, 249);
            ((System.ComponentModel.ISupportInitialize)(this.pbxAnh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxAnh;
        private System.Windows.Forms.Label lbTen;
        private System.Windows.Forms.Label lbChucVu;
    }
}
