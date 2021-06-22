using CuoiKi_QuanLyQuanAnNhanh.Business;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CuoiKi_QuanLyQuanAnNhanh
{
    public partial class frmThongTin : Form
    {
        string Ma, Ten, NgaySinh, SDT, GioiTinh, Luong, DiaChi, ChucVu, MatKhau, TaiKhoan;

        byte[] HinhAnh;

        public frmThongTin(string ma, string ten, string ngaysinh, string sdt, string gioitinh, string luong, byte[] hinhanh, string diachi, string chucvu, string taikhoan, string mk)
        {
            Ma = ma;
            Ten = ten;
            NgaySinh = ngaysinh;
            SDT = sdt;
            Luong = luong;
            HinhAnh = hinhanh;
            DiaChi = diachi;
            GioiTinh = gioitinh;
            TaiKhoan = taikhoan;
            ChucVu = chucvu;
            MatKhau = mk;
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            txtMaNV.Text = Ma;
            txtTen.Text = Ten;
            txtNgaySinh.Text = NgaySinh;
            txtSDT.Text = SDT;
            txtLuong.Text = Luong;
            txtDiaChi.Text = DiaChi;
            txtChucVu.Text = ChucVu;
            txtTaiKhoan.Text = TaiKhoan;
            txtMatKhau.Text = MatKhau;

            if (TaiKhoan == "")
            {
                btnCapNhatTK.Enabled = false;
                btnXoaTK.Enabled = false;
            }
            else
            {
                btnThemTK.Enabled = false;
            }

            if (GioiTinh == "Nam")
                rbtNam.Checked = true;
            else
                rbtNu.Checked = true;

            if (HinhAnh != null)
                pbxNhanVien.Image = Image.FromStream(new MemoryStream(HinhAnh));
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

        private void btnThemTK_Click(object sender, EventArgs e)
        {
            NhanVien.ThemTK(txtTaiKhoan.Text, txtMatKhau.Text, txtChucVu.Text, txtMaNV.Text);
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            string gioitinh = rbtNam.Checked ? "Nam" : "Nữ";
            NhanVien.Update(txtMaNV.Text, txtTen.Text, txtNgaySinh.Text, txtSDT.Text, gioitinh, txtLuong.Text, HinhAnh, txtDiaChi.Text);
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            NhanVien.XoaNV(txtMaNV.Text);
            this.Close();
        }
    }
}
