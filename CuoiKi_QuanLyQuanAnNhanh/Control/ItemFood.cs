using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CuoiKi_QuanLyQuanAnNhanh.Control
{
    public partial class ItemFood : UserControl
    {
        public ItemFood()
        {
            InitializeComponent();
        }

        string foodPrice;
        public string FoodPrice
        {
            get => foodPrice;
            set
            {
                foodPrice = value;
                if ((int.Parse(foodPrice) / 1000) > 0)
                    lbFoodPrice.Text = (int.Parse(foodPrice) / 1000).ToString() + "K";
                else
                    lbFoodPrice.Text = foodPrice.ToString();
            }
        }

        private string foodUnit;
        public string FoodUnit 
        {
            get => foodUnit;
            set
            {
                foodUnit = value;
                lbFoodPrice.Text += " " + value;
            }
        }

        public string FoodName 
        {
            get => lbFoodName.Text;
            set => lbFoodName.Text = value;
        }

        public string FoodID { get; set; }

        private byte[] images;
        public byte[] Images 
        {
            get => images;
            set
            {
                images = value;
                pbx_FoodImage.Image = Image.FromStream(new MemoryStream(images));
            }
        }

        public void SetImageFromPath(string path)
        {
            pbx_FoodImage.Image = Image.FromFile(path);
        }

        public void SetImageFromByte(byte[] byteData)
        {
            MemoryStream data = new MemoryStream(byteData);
            pbx_FoodImage.Image = Image.FromStream(data);
        }

        public event EventHandler ItemClick;

        private void pbx_FoodImage_Click(object sender, EventArgs e)
        {
            if (this.ItemClick != null)
                this.ItemClick(this, e);
        }
    }
}
