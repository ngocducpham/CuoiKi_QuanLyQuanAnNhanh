using CuoiKi_QuanLyQuanAnNhanh.Business;
using CuoiKi_QuanLyQuanAnNhanh.Control;
using DataAccess;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CuoiKi_QuanLyQuanAnNhanh
{
    public partial class frmMain : Form
    {
        private byte[] ImageByte;
        //private List<ItemFood> Foods;
        //private List<ItemTable> Tables;
        private ItemTable currentItemTable;
        private ItemFood currentItemFood;
        private string currentOrderID;
        private string selectedFoodName;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            SqlHelper.ConnectionString = "Data Source=.;Initial Catalog=QuanLyQuanAnNhanh;Integrated Security=True";
            if (!SqlHelper.TestConnection())
            {
                MessageBox.Show("Ket noi den database that bai");
                Application.Exit();
            }

            //Foods = new List<ItemFood>();
            //Tables = new List<ItemTable>();

            InitTabMonAn();
            InitOrderTab();
            InitTabBanAn();

            currentOrderID = HoaDon.LayMaHoaDon();
            hd_lbMaHoaDon.Text = "Mã Hóa Đơn: " + currentOrderID;
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitOrderTab();
            InitTabBanAn();
            InitTabMonAn();
        }

        #region Tab BanAn

        private void InitTabBanAn()
        {
            DataTable banAn = BanAn.Load();
            flpnTable.Controls.Clear();

            foreach (DataRow row in banAn.Rows)
            {
                Color color = Color.Silver;
                if (row[2].ToString() == "1")
                    color = Color.Yellow;

                ItemTable item = new ItemTable
                {
                    TableColor = color,
                    TableID = row[0].ToString(),
                    TableName = row[1].ToString()
                };

                item.ItemClick += Item_ItemClick;
                //Tables.Add(item);
                flpnTable.Controls.Add(item);
            }
        }

        private void Item_ItemClick(object sender, EventArgs e)
        {
            currentItemTable = (ItemTable)sender;
            dgvSoDoOrder.DataSource = null;
            dgvSoDoOrder.DataSource = MonAn.LayOrder(currentItemTable.TableID);
            sd_lbHeader.Text = "Danh Sách Món Ăn: ";
            ba_txtTenBan.Text = currentItemTable.TableName;
            ba_lbTongTien.Text = "Tổng Giá Tiền: " + BanAn.LayTienHoaDon(currentItemTable.TableID) + " VND";
        }

        private void ba_btnThanhToan_Click(object sender, EventArgs e)
        {
            BanAn.ThanhToan(currentItemTable.TableID);
            dgvSoDoOrder.DataSource = MonAn.LayOrder(currentItemTable.TableID);
            InitTabBanAn();
        }

        private void ba_btnThemBan_Click(object sender, EventArgs e)
        {
            BanAn.ThemBanAn(ba_txtTenBan.Text);
            InitTabBanAn();
        }

        private void ba_btnXoaBan_Click(object sender, EventArgs e)
        {
            BanAn.XoaBan(currentItemTable.TableID);
            InitTabBanAn();
        }

        private void ba_btnChinhSua_Click(object sender, EventArgs e)
        {
            currentOrderID = BanAn.LayMaHoaDon(currentItemTable.TableID);
            hd_dgvHoaDon.DataSource = HoaDon.LayMonAn(currentOrderID);
            tabControl.SelectedIndex = 0;
            hd_lbMaHoaDon.Text = "Mã Hóa Đơn: " + currentOrderID;
            hd_lbThongTinHoaDon.Text = "Hóa Đơn Cho: " + currentItemTable.TableName;

        }
        #endregion

        #region Tab MonAn
        private void InitTabMonAn()
        {
            DataTable orderTable = MonAn.Load();
            flpnMonAn.Controls.Clear();

            foreach (DataRow row in orderTable.Rows)
            {
                ItemFood itemFood = new ItemFood
                {
                    FoodID = row[0].ToString(),
                    FoodName = row[1].ToString(),
                    FoodPrice = row[2].ToString(),
                    FoodUnit = row[3].ToString(),
                    Images = (byte[])row[4]
                };
                itemFood.ItemClick += ItemFood_ItemClick;
                //Foods.Add(itemFood);
                flpnMonAn.Controls.Add(itemFood);
            }
        }

        private void ItemFood_ItemClick(object sender, EventArgs e)
        {
            ItemFood item = (ItemFood)sender;
            ma_txtTenMonAn.Text = item.FoodName;
            ma_txtDonGia.Text = item.FoodPrice;
            ma_cbxDonVi.Text = item.FoodUnit;
            ma_pbxHinhAnh.Image = Image.FromStream(new MemoryStream(item.Images));
            currentItemFood = item;
        }


        private void ma_btnThemHinh_Click(object sender, EventArgs e)
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
                    ImageByte = br.ReadBytes((int)fs.Length);
                    ma_pbxHinhAnh.Image = Image.FromStream(fs);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ma_btnCapNhat_Click(object sender, EventArgs e)
        {
            MonAn.Update(currentItemFood.FoodID, ma_txtTenMonAn.Text, ma_txtDonGia.Text, ma_cbxDonVi.Text, ImageByte);
            InitTabMonAn();
            InitOrderTab();
        }

        private void ma_btnThemMon_Click(object sender, EventArgs e)
        {
            MonAn.Add(ma_txtTenMonAn.Text, ma_txtDonGia.Text, ma_cbxDonVi.Text, ImageByte);
            InitTabMonAn();
            InitOrderTab();
        }

        private void ma_btnXoaMon_Click(object sender, EventArgs e)
        {
            MonAn.Delete(currentItemFood.FoodID);
            InitTabMonAn();
            InitOrderTab();
        }


        #endregion

        #region Tab HoaDon

        private void InitOrderTab()
        {
            DataTable orderTable = MonAn.Load();
            flpnOrder.Controls.Clear();

            foreach (DataRow row in orderTable.Rows)
            {
                ItemFood itemFood = new ItemFood
                {
                    FoodID = row[0].ToString(),
                    FoodName = row[1].ToString(),
                    FoodPrice = row[2].ToString(),
                    FoodUnit = row[3].ToString(),
                    Images = (byte[])row[4]
                };

                itemFood.ItemClick += ItemFood_ItemClick1;
                flpnOrder.Controls.Add(itemFood);
            }
        }

        private void ItemFood_ItemClick1(object sender, EventArgs e)
        {
            currentItemFood = (ItemFood)sender;

            string idban;
            idban = currentItemTable.TableID;

            HoaDon.ThemMon(currentOrderID, currentItemFood.FoodID, "100", idban);
            hd_dgvHoaDon.DataSource = HoaDon.LayMonAn(currentOrderID);

            hd_lbTongTien.Text = "Tổng tiền: " + HoaDon.TinhTienHoaDon(currentOrderID) + " VND";
        }

        private void hd_btnXoaMon_Click(object sender, EventArgs e)
        {
            HoaDon.XoaMon(currentOrderID, selectedFoodName, currentItemTable.TableID);
            hd_dgvHoaDon.DataSource = HoaDon.LayMonAn(currentOrderID);
            hd_lbTongTien.Text = "Tổng tiền: " + HoaDon.TinhTienHoaDon(currentOrderID) + " VND";
        }

        private void hd_dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedFoodName = hd_dgvHoaDon.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void hd_btnLuu_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 1;
        }

        private void hd_btnHuyBo_Click(object sender, EventArgs e)
        {
            HoaDon.XoaHoaDon(currentOrderID);
            tabControl.SelectedIndex = 1;
        }

        private void hd_btnThanhToan_Click(object sender, EventArgs e)
        {
            HoaDon.ThanhToan(currentOrderID);
            tabControl.SelectedIndex = 1;
        }

        private void hd_btnGiam_Click(object sender, EventArgs e)
        {
            HoaDon.GiamMonAn(currentOrderID, selectedFoodName, currentItemTable.TableID);
            hd_dgvHoaDon.DataSource = HoaDon.LayMonAn(currentOrderID);
            hd_lbTongTien.Text = "Tổng tiền: " + HoaDon.TinhTienHoaDon(currentOrderID) + " VND";
        }

        #endregion

        #region Tab NhanVien
        private void InitTabNhanVien()
        {

        }


        #endregion

    }
}
