using System.Drawing;
using System.Windows.Forms;

namespace CuoiKi_QuanLyQuanAnNhanh.Control
{
    public partial class ItemFood : UserControl
    {
        public ItemFood()
        {
            InitializeComponent();
        }

        public string FoodPrice
        {
            get => lbFoodPrice.Text;
            set => lbFoodPrice.Text = value;
        }

        public string FoodName 
        {
            get => lbFoodName.Text;
            set => lbFoodName.Text = value;
        }

        public void SetImage(string path)
        {
            pbx_FoodImage.Image = Image.FromFile(path);
        }
    }
}
