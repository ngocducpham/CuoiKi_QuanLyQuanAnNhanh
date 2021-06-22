using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CuoiKi_QuanLyQuanAnNhanh.Business;

namespace CuoiKi_QuanLyQuanAnNhanh
{
    public partial class frmTaoNV : Form
    {
        byte[] HinhAnh;
        public frmTaoNV()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string gioitinh = rbtNam.Checked ? "Nam" : "Nữ";
            NhanVien.Them(txtMaNV.Text, txtTen.Text, txtNgaySinh.Text, txtSDT.Text, gioitinh, txtLuong.Text, HinhAnh, txtDiaChi.Text);
        }

        private void btnThemTK_Click(object sender, EventArgs e)
        {
            NhanVien.ThemTK(txtTaiKhoan.Text, txtMatKhau.Text, txtChucVu.Text, txtMaNV.Text);
        }

        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog
                {
                    Filter = "JPG Files (.*jpg)|*.jpg|PNG Files (*.png)|*.png",
                    Title = "Chon Hinh",
                    DefaultExt = "jpeg",
                    RestoreDirectory = true,
                    CheckPathExists = true,
                };

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    HinhAnh = br.ReadBytes((int)fs.Length);
                    pbxNhanVien.Image = Image.FromStream(fs);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
