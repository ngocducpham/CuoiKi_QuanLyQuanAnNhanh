
namespace CuoiKi_QuanLyQuanAnNhanh.Control
{
    partial class ItemFood
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
            this.pbx_FoodImage = new System.Windows.Forms.PictureBox();
            this.lbFoodName = new System.Windows.Forms.Label();
            this.lbFoodPrice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_FoodImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbx_FoodImage
            // 
            this.pbx_FoodImage.InitialImage = null;
            this.pbx_FoodImage.Location = new System.Drawing.Point(0, 0);
            this.pbx_FoodImage.Name = "pbx_FoodImage";
            this.pbx_FoodImage.Size = new System.Drawing.Size(150, 116);
            this.pbx_FoodImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx_FoodImage.TabIndex = 0;
            this.pbx_FoodImage.TabStop = false;
            this.pbx_FoodImage.Click += new System.EventHandler(this.pbx_FoodImage_Click);
            // 
            // lbFoodName
            // 
            this.lbFoodName.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFoodName.Location = new System.Drawing.Point(0, 119);
            this.lbFoodName.Name = "lbFoodName";
            this.lbFoodName.Size = new System.Drawing.Size(151, 44);
            this.lbFoodName.TabIndex = 1;
            this.lbFoodName.Text = "label1ddddddddddddddddddddddd";
            this.lbFoodName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbFoodPrice
            // 
            this.lbFoodPrice.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbFoodPrice.ForeColor = System.Drawing.Color.White;
            this.lbFoodPrice.Location = new System.Drawing.Point(77, 0);
            this.lbFoodPrice.Name = "lbFoodPrice";
            this.lbFoodPrice.Size = new System.Drawing.Size(74, 30);
            this.lbFoodPrice.TabIndex = 1;
            this.lbFoodPrice.Text = "label1";
            this.lbFoodPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ItemFood
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lbFoodPrice);
            this.Controls.Add(this.lbFoodName);
            this.Controls.Add(this.pbx_FoodImage);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ItemFood";
            this.Size = new System.Drawing.Size(148, 172);
            ((System.ComponentModel.ISupportInitialize)(this.pbx_FoodImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbx_FoodImage;
        private System.Windows.Forms.Label lbFoodName;
        private System.Windows.Forms.Label lbFoodPrice;
    }
}
