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
using CuoiKi_QuanLyQuanAnNhanh.Control;

namespace CuoiKi_QuanLyQuanAnNhanh
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            ItemFood ifd = new ItemFood();
            ifd.FoodName = "Ga Ran";
            ifd.FoodPrice = "150K VND";
            ifd.SetImage(@"D:\Programing\C# project\LT Windown\CuoiKi_QuanLyQuanAnNhanh\CuoiKi_QuanLyQuanAnNhanh\Picture\garan.jpg");
            flpnFood.Controls.Add(ifd);

            ItemFood ifd2 = new ItemFood();
            ifd2.FoodName = "Khoai Tay Chien";
            ifd2.FoodPrice = "1.5 USD";
            ifd2.SetImage(@"D:\Programing\C# project\LT Windown\CuoiKi_QuanLyQuanAnNhanh\CuoiKi_QuanLyQuanAnNhanh\Picture\khoaitaychien.jpg");

            ItemTable it1 = new ItemTable();
            it1.TableName = "1";
            it1.TableColor = Color.SandyBrown;

            ItemTable it2 = new ItemTable();
            it2.TableName = "2";
            it2.TableColor = Color.Silver;

            flpnTable.Controls.Add(it1);
            flpnTable.Controls.Add(it2);
            flpnMonAn.Controls.Add(ifd2);

        }
    }
}
