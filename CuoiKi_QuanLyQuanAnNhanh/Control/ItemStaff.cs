using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CuoiKi_QuanLyQuanAnNhanh.Control
{
    public partial class ItemStaff : UserControl
    {
        public ItemStaff()
        {
            InitializeComponent();
        }

        public string MaNhanVien { get; set; }

        public string GioiTinh { get; set; }

        public string SoDienThoai { get; set; }

        public string DiaChi { get; set; }

        public string ChucVu 
        {
            get => lbChucVu.Text;
            set => lbChucVu.Text = value;
        }

        public string TaiKhoan { get; set; }

        public string MatKhau { get; set; }

        public string Luong { get; set; }

        public string NgaySinh { get; set; }

        public string Ten
        {
            get => lbTen.Text;
            set => lbTen.Text = value;
        }

        private byte[] image;
        public byte[] HinhAnh
        {
            get => image;
            set
            {
                image = value;
                if(image != null)
                    pbxAnh.Image = Image.FromStream(new MemoryStream(image));
            }
        }

        public event EventHandler ItemClick;

        private void pbxAnh_Click(object sender, System.EventArgs e)
        {
            if(ItemClick != null)
                this.ItemClick(this, e);
        }
    }
}
