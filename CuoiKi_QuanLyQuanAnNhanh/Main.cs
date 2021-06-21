using CuoiKi_QuanLyQuanAnNhanh.Business;
using CuoiKi_QuanLyQuanAnNhanh.Control;
using DataAccess;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace CuoiKi_QuanLyQuanAnNhanh
{
    public partial class frmMain : Form
    {
        private byte[] ImageByte;

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
            InitMonAnTab();
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
                    SetImage = (byte[])row[4]
                };

                flpnOrder.Controls.Add(itemFood);
            }
        }

        private void InitMonAnTab()
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
                    SetImage = (byte[])row[4]
                };

                flpnMonAn.Controls.Add(itemFood);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            InitOrderTab();
        }

        #region Tab MonAn

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
