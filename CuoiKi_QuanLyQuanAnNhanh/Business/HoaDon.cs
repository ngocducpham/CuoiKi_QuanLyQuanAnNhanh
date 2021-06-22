using DataAccess;
using System.Data;
using System.Data.SqlClient;

namespace CuoiKi_QuanLyQuanAnNhanh.Business
{
    public class HoaDon
    {
        //[sp_ThanhToanHoaDon] @mahoadon VARCHAR(50)
        public static bool ThanhToan(string maHD)
        {
            SqlParameter pa = new SqlParameter("@mahoadon", SqlDbType.Int);
            pa.Value = maHD;

            return SqlHelper.ExecuteNonQuery("dbo.sp_ThanhToanHoaDon", CommandType.StoredProcedure, pa);
        }

        public static string LayMaHoaDon()
        {
            SqlParameter re2 = new SqlParameter("@res", SqlDbType.Int);
            re2.Direction = ParameterDirection.ReturnValue;

            SqlHelper.ExecuteNonQuery("dbo.fn_HoaDonTiepTheo", CommandType.StoredProcedure, re2);
            return ((int)re2.Value).ToString();
        }

        // sp_InsertChiTietHoaDon @mahoadon INT, @mamonan INT, @manhanvien INT, @idban INT
        public static bool ThemMon(string maHD, string maMA, string maNV, string idBan)
        {
            SqlParameter p1 = new SqlParameter("@mahoadon", SqlDbType.Int);
            p1.Value = maHD;

            SqlParameter p2 = new SqlParameter("@mamonan", SqlDbType.Int);
            p2.Value = maMA;

            SqlParameter p3 = new SqlParameter("@manhanvien", SqlDbType.Int);
            p3.Value = maNV;

            SqlParameter p4 = new SqlParameter("@idban", SqlDbType.Int);
            p4.Value = idBan;

            return SqlHelper.ExecuteNonQuery("dbo.sp_InsertChiTietHoaDon", CommandType.StoredProcedure, p1, p2, p3, p4);
        }

        //sp_LayMonAnTrongOrder @mahoadon INT
        public static DataTable LayMonAn(string maHD)
        {
            SqlParameter p1 = new SqlParameter("@mahoadon", SqlDbType.Int);
            p1.Value = maHD;

            return SqlHelper.Execute("dbo.sp_LayMonAnTrongOrder", CommandType.StoredProcedure, p1);
        }

        //sp_XoaMonKhoiHoaDon @mahd INT, @tenmon NVARCHAR(100), @idban INT
        public static bool XoaMon(string maHD, string tenMon, string idBan)
        {
            SqlParameter p1 = new SqlParameter("@mahd", SqlDbType.Int);
            p1.Value = maHD;

            SqlParameter p2 = new SqlParameter("@tenmon", SqlDbType.VarChar);
            p2.Value = tenMon;

            SqlParameter p3 = new SqlParameter("@idban", SqlDbType.Int);
            p3.Value = idBan;

            return SqlHelper.ExecuteNonQuery("dbo.sp_XoaMonKhoiHoaDon", CommandType.StoredProcedure, p1, p2, p3);
        }

        //sp_DeleteHoaDon @mahoadon INT
        public static bool XoaHoaDon(string maHD)
        {
            SqlParameter p1 = new SqlParameter("@mahoadon", SqlDbType.Int);
            p1.Value = maHD;

            return SqlHelper.ExecuteNonQuery("dbo.sp_DeleteHoaDon", CommandType.StoredProcedure, p1);
        }

        //sp_TangSoLuongMonAn @mahoadon INT, @mamonan INT
        public static bool TangMonAn(string maHD, string maMA)
        {
            SqlParameter p1 = new SqlParameter("@mahoadon", SqlDbType.Int);
            p1.Value = maHD;

            SqlParameter p2 = new SqlParameter("@mamonan", SqlDbType.Int);
            p2.Value = maMA;

            return SqlHelper.ExecuteNonQuery("dbo.sp_TangSoLuongMonAn", CommandType.StoredProcedure, p1, p2);
        }

        //sp_GiamSoLuongMonAn @mahoadon INT, @tenmon VARCHAR(50), @idban INT
        public static bool GiamMonAn(string maHD, string tenMon, string idBan)
        {
            SqlParameter p1 = new SqlParameter("@mahoadon", SqlDbType.Int);
            p1.Value = maHD;

            SqlParameter p2 = new SqlParameter("@tenmon", SqlDbType.VarChar);
            p2.Value = tenMon;

            SqlParameter p3 = new SqlParameter("@idban", SqlDbType.Int);
            p3.Value = idBan;

            return SqlHelper.ExecuteNonQuery("dbo.sp_GiamSoLuongMonAn", CommandType.StoredProcedure, p1, p2, p3);
        }

        //fn_TinhTienHoaDon (@mahoadon VARCHAR(10))
        //sp_UpdateTien @mahoadon INT, @tien FLOAT
        public static string TinhTienHoaDon(string maHD)
        {
            SqlParameter p1 = new SqlParameter("@mahoadon", SqlDbType.VarChar);
            p1.Value = maHD;

            SqlParameter res = new SqlParameter("@res", SqlDbType.Float);
            res.Direction = ParameterDirection.ReturnValue;

            SqlHelper.ExecuteNonQuery("dbo.fn_TinhTienHoaDon", CommandType.StoredProcedure, p1, res);

            SqlParameter p2 = new SqlParameter("@mahoadon", SqlDbType.VarChar);
            p2.Value = maHD;

            SqlParameter p3 = new SqlParameter("@tien", SqlDbType.Float);
            p3.Value = res.Value;

            SqlHelper.ExecuteNonQuery("dbo.sp_UpdateTien", CommandType.StoredProcedure, p2, p3);

            return ((double)res.Value).ToString();
        }
    }
}
