using DataAccess;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CuoiKi_QuanLyQuanAnNhanh.Business
{
    public class BanAn
    {
        public static DataTable Load()
        {
            return SqlHelper.Execute("dbo.sp_LoadBanAn", CommandType.StoredProcedure, null);
        }      

        //sp_InsertBanAn @tenBan NVARCHAR(10)
        public static bool ThemBanAn(string tenBan)
        {
            SqlParameter pa = new SqlParameter("@tenBan", SqlDbType.VarChar);
            pa.Value = tenBan;

            return SqlHelper.ExecuteNonQuery("dbo.sp_InsertBanAn", CommandType.StoredProcedure, pa);
        }

        //sp_DeleteBanAn @idBan INT
        public static bool XoaBan(string idBan)
        {
            Console.WriteLine(idBan);
            SqlParameter pa = new SqlParameter("@idBan", SqlDbType.Int);
            pa.Value = idBan;

            return SqlHelper.ExecuteNonQuery("dbo.sp_DeleteBanAn", CommandType.StoredProcedure, pa);
        }

        //fn_LayMaHoaDonTheoBan (@idban int)
        public static string LayMaHoaDon(string idBan)
        {
            SqlParameter pa = new SqlParameter("@idban", SqlDbType.Int);
            pa.Value = idBan;

            SqlParameter re = new SqlParameter("@res", SqlDbType.Int);
            re.Direction = ParameterDirection.ReturnValue;

            SqlHelper.ExecuteNonQuery("dbo.fn_LayMaHoaDonTheoBan", CommandType.StoredProcedure, pa, re);

            try
            {
                return ((int)re.Value).ToString();
            }
            catch
            {
                SqlParameter re2 = new SqlParameter("@res", SqlDbType.Int);
                re2.Direction = ParameterDirection.ReturnValue;

                SqlHelper.ExecuteNonQuery("dbo.fn_HoaDonTiepTheo", CommandType.StoredProcedure, re2);
                return ((int)re2.Value).ToString();
            }
        }

        public static bool ThanhToan(string idBan)
        {
            string maHD = LayMaHoaDon(idBan);
            SqlParameter pa = new SqlParameter("@mahoadon", SqlDbType.Int);
            pa.Value = maHD;

            return SqlHelper.ExecuteNonQuery("dbo.sp_ThanhToanHoaDon", CommandType.StoredProcedure, pa);
        }

        //sp_LayTienHoaDon (@mahoadon INT)
        public static string LayTienHoaDon(string idBan)
        {
            string maHD = LayMaHoaDon(idBan);
            SqlParameter pa = new SqlParameter("@mahoadon", SqlDbType.Int);
            pa.Value = maHD;

            SqlParameter res = new SqlParameter("@res", SqlDbType.Float);
            res.Direction = ParameterDirection.ReturnValue;

            SqlHelper.ExecuteNonQuery("dbo.sp_LayTienHoaDon", CommandType.StoredProcedure, pa, res);

            try
            {
                return ((double)res.Value).ToString();
            }
            catch
            {
                return "0";
            }
        }
    }
}
