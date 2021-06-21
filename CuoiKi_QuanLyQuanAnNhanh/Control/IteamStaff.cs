using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CuoiKi_QuanLyQuanAnNhanh.Control
{
    public partial class IteamStaff : UserControl
    {
        public IteamStaff()
        {
            InitializeComponent();
        }

        public string Ten
        {
            get => lbTen.Text;
            set => lbTen.Text = value;
        }

        public string ChucVu 
        {
            get => lbChucVu.Text;
            set => lbChucVu.Text = value;
        }

        private byte[] image;
        public byte[] SetImage
        {
            get => image;
            set
            {
                image = value;
                pbxAnh.Image = Image.FromStream(new MemoryStream(image));
            }
        }
    }
}
