using CuoiKi_QuanLyQuanAnNhanh.Business;
using CuoiKi_QuanLyQuanAnNhanh.Control;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CuoiKi_QuanLyQuanAnNhanh
{
    public partial class frmMain : Form
    {
        private byte[] ImageByte;
        private List<ItemFood> Foods;
        private List<ItemTable> Tables;
        private ItemTable currentItemTable;
        private string MaHoaDonHienTai;

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

            Foods = new List<ItemFood>();
            Tables = new List<ItemTable>();

            InitTabMonAn();
            InitOrderTab();
            InitTabSoDo();
        }

        private void InitOrderTab()
        {
            DataTable orderTable = MonAn.Load();

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
                Foods.Add(itemFood);
                flpnOrder.Controls.Add(itemFood);
            }
        }

        #region Tab BanAn

        private void InitTabSoDo()
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
                Tables.Add(item);
                flpnTable.Controls.Add(item);
            }
        }

        private void Item_ItemClick(object sender, EventArgs e)
        {
            currentItemTable = (ItemTable)sender;       
            dgvSoDoOrder.DataSource = null;
            dgvSoDoOrder.DataSource = MonAn.LayOrder(currentItemTable.TableID);
            sd_lbHeader.Text = "Danh Sách Order: " + currentItemTable.TableName + " - ID: " + currentItemTable.TableID;
            ba_txtTenBan.Text = currentItemTable.TableName;
        }

        private void ba_btnThanhToan_Click(object sender, EventArgs e)
        {
            BanAn.ThanhToan(currentItemTable.TableID);
            dgvSoDoOrder.DataSource = MonAn.LayOrder(currentItemTable.TableID);
            InitTabSoDo();
        }

        private void ba_btnThemBan_Click(object sender, EventArgs e)
        {
            BanAn.ThemBanAn(ba_txtTenBan.Text);
            InitTabSoDo();
        }

        private void ba_btnXoaBan_Click(object sender, EventArgs e)
        {
            BanAn.XoaBan(currentItemTable.TableID);
            InitTabSoDo();
        }

        private void ba_btnChinhSua_Click(object sender, EventArgs e)
        {
            
            tabControl.SelectedIndex = 0;
            string MaHoaDonHienTai = BanAn.LayMaHoaDon(currentItemTable.TableID);
            hd_lbMaHoaDon.Text = "Mã Hóa Đơn: " + MaHoaDonHienTai;
            hd_lbBanAn.Text = currentItemTable.TableName;
        }
        #endregion

        #region Tab MonAn
        private void InitTabMonAn()
        {
            DataTable orderTable = MonAn.Load();

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
                Foods.Add(itemFood);
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

                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    ImageByte = br.ReadBytes((int)fs.Length);
                    ma_pbxHinhAnh.Image = Image.FromStream(fs);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ma_btnCapNhat_Click(object sender, EventArgs e)
        {
            MonAn.Update("12", "Pepsi", "1", "USD", ImageByte);
        }




        #endregion

    }
}
