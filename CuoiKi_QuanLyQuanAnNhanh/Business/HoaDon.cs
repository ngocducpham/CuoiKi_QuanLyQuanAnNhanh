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
            SqlParameter pa = new SqlParameter("@mahoadon", SqlDbType.VarChar);
            pa.Value = maHD;

            return SqlHelper.ExecuteNonQuery("dbo.sp_ThanhToanHoaDon", CommandType.StoredProcedure, pa);
        }
    }
}
