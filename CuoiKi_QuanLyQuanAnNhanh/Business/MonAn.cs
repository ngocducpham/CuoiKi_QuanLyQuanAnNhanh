using DataAccess;
using System.Data;
using System.Data.SqlClient;

namespace CuoiKi_QuanLyQuanAnNhanh.Business
{
    public class MonAn
    {
        public static DataTable Load()
        {
            return SqlHelper.Execute("dbo.sp_LoadMonAn", CommandType.StoredProcedure, null);
        }

        public static byte[] DataImage(string id)
        {
            return (byte[])SqlHelper.ExecuteScalar($"Use TestPic \n SELECT PicData FROM PicStore WHERE PicID = {id}", CommandType.Text, null);
        }

        //sp_UpdateMonAn @mamonan INT, @tenmonan VARCHAR(100), @dongia FLOAT, @donvitinh VARCHAR(10), @hinhanh varbinary(MAX)
        public static bool Update(string maMonAn, string tenMonAn, string donGia, string donVi, byte[] hinhAnh)
        {
            SqlParameter p1 = new SqlParameter("@mamonan", SqlDbType.Int);
            p1.Value = maMonAn;

            SqlParameter p2 = new SqlParameter("@tenmonan", SqlDbType.VarChar);
            p2.Value = tenMonAn;

            SqlParameter p3 = new SqlParameter("@dongia", SqlDbType.Float);
            p3.Value = donGia;

            SqlParameter p4 = new SqlParameter("@donvitinh", SqlDbType.VarChar);
            p4.Value = donVi;

            SqlParameter p5 = new SqlParameter("@hinhanh", SqlDbType.VarBinary);
            p5.Value = hinhAnh;

            return SqlHelper.ExecuteNonQuery("dbo.sp_UpdateMonAn", CommandType.StoredProcedure, p1, p2, p3, p4, p5);
        }

        //sp_InsertMonAn @tenmonan NVARCHAR(100), @dongia FLOAT, @donvitinh VARCHAR(10), @hinhanh varbinary(MAX)
        public static bool Add(string tenMonAn, string donGia, string donVi, byte[] hinhAnh)
        {
            SqlParameter p2 = new SqlParameter("@tenmonan", SqlDbType.VarChar);
            p2.Value = tenMonAn;

            SqlParameter p3 = new SqlParameter("@dongia", SqlDbType.Float);
            p3.Value = donGia;

            SqlParameter p4 = new SqlParameter("@donvitinh", SqlDbType.VarChar);
            p4.Value = donVi;

            SqlParameter p5 = new SqlParameter("@hinhanh", SqlDbType.VarBinary);
            p5.Value = hinhAnh;

            return SqlHelper.ExecuteNonQuery("dbo.sp_InsertMonAn", CommandType.StoredProcedure, p2, p3, p4, p5);
        }

        // sp_LayOrderTheoBan @idban INT
        public static DataTable LayOrder(string idBan)
        {
            SqlParameter pa = new SqlParameter("@idban", SqlDbType.Int);
            pa.Value = idBan;

            return SqlHelper.Execute("dbo.sp_LayOrderTheoBan", CommandType.StoredProcedure, pa);
        }

        //sp_DeleteMonAn @mamonan
        public static bool Delete(string maMonAn)
        {
            SqlParameter p1 = new SqlParameter("@mamonan", SqlDbType.Int);
            p1.Value = maMonAn;

            return SqlHelper.ExecuteNonQuery("dbo.sp_DeleteMonAn", CommandType.StoredProcedure, p1);
        }
    }
}
