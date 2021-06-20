using System.Drawing;
using System.Windows.Forms;

namespace CuoiKi_QuanLyQuanAnNhanh.Control
{
    public partial class ItemTable : UserControl
    {
        public ItemTable()
        {
            InitializeComponent();
        }

        public Color TableColor
        {
            get => lbTable.BackColor;
            set => lbTable.BackColor = value;
        }

        public string TableName
        {
            get => lbTable.Text;
            set => lbTable.Text = value;
        }
    }
}
