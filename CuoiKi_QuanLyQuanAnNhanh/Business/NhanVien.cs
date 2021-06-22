using DataAccess;
using System.Data;
using System.Data.SqlClient;

namespace CuoiKi_QuanLyQuanAnNhanh.Business
{
    public class NhanVien
    {
        public static DataTable Load()
        {
            return SqlHelper.Execute("dbo.sp_LoadNhanVien", CommandType.StoredProcedure, null);
        }

        //sp_UpdateNhanVien @manhanvien INT, @hoten NVARCHAR(100), @ngaysinh DATETIME, @sodienthoai VARCHAR(50)
        //, @gioitinh NVARCHAR(5), @luong INT,@diachi NVARCHAR(200), @hinhanh varbinary(MAX)
        public static bool Update(string ma, string ten, string ngaysinh, string sdt, string gioitinh, string luong, byte[] hinhanh, string diachi)
        {
            SqlParameter pa1 = new SqlParameter("@manhanvien", SqlDbType.Int);
            pa1.Value = ma;

            SqlParameter pa2 = new SqlParameter("@hoten", SqlDbType.NVarChar);
            pa2.Value = ten;

            SqlParameter pa3 = new SqlParameter("@ngaysinh", SqlDbType.DateTime);
            pa3.Value = ngaysinh;

            SqlParameter pa4 = new SqlParameter("@sodienthoai", SqlDbType.VarChar);
            pa4.Value = sdt;

            SqlParameter pa5 = new SqlParameter("@gioitinh", SqlDbType.NVarChar);
            pa5.Value = gioitinh;

            SqlParameter pa6 = new SqlParameter("@luong", SqlDbType.Int);
            pa6.Value = luong;

            SqlParameter pa7 = new SqlParameter("@diachi", SqlDbType.NVarChar);
            pa7.Value = diachi;

            SqlParameter pa8 = new SqlParameter("@hinhanh", SqlDbType.VarBinary);
            pa8.Value = hinhanh;

            return SqlHelper.ExecuteNonQuery("dbo.sp_UpdateNhanVien", CommandType.StoredProcedure, pa1, pa2, pa3, pa4, pa5, pa6, pa7, pa8);
        }

        //sp_LayTaiKhoanChucVu @manhanvien INT
        public static DataTable LayTaiKhoanChucVu(string maNV)
        {
            SqlParameter pa = new SqlParameter("@manhanvien", SqlDbType.Int);
            pa.Value = maNV;

            return SqlHelper.Execute("dbo.sp_LayTaiKhoanChucVu", CommandType.StoredProcedure, pa);
        }

        //sp_InsertAccount @userID VARCHAR(50), @pass nVARCHAR(50), @role VARCHAR(50), @manhanvien int
        public static bool ThemTK(string user, string pass, string role, string manv)
        {
            SqlParameter pa1 = new SqlParameter("@userID", SqlDbType.VarChar);
            pa1.Value = user;

            SqlParameter pa2 = new SqlParameter("@pass", SqlDbType.NVarChar);
            pa2.Value = pass;

            SqlParameter pa3 = new SqlParameter("@role", SqlDbType.VarChar);
            pa3.Value = role;

            SqlParameter pa4 = new SqlParameter("@manhanvien", SqlDbType.Int);
            pa4.Value = manv;

            return SqlHelper.ExecuteNonQuery("dbo.sp_InsertAccount", CommandType.StoredProcedure, pa1, pa2, pa3, pa4);
        }

        // sp_DeleteNhanVien @manhanvien VARCHAR(50)
        public static bool XoaNV(string manv)
        {
            SqlParameter pa1 = new SqlParameter("@manhanvien", SqlDbType.VarChar);
            pa1.Value = manv;

            return SqlHelper.ExecuteNonQuery("dbo.sp_DeleteNhanVien", CommandType.StoredProcedure, pa1);
        }

        //sp_InsertNhanVien @manhanvien INT, @hoten NVARCHAR(100), @ngaysinh DATETIME, @sodienthoai VARCHAR(50), @gioitinh NVARCHAR(5), @luong INT,@diachi NVARCHAR(200), @hinhanh varbinary(MAX)
        public static bool Them(string ma, string ten, string ngaysinh, string sdt, string gioitinh, string luong, byte[] hinhanh, string diachi)
        {
            SqlParameter pa1 = new SqlParameter("@manhanvien", SqlDbType.Int);
            pa1.Value = ma;

            SqlParameter pa2 = new SqlParameter("@hoten", SqlDbType.NVarChar);
            pa2.Value = ten;

            SqlParameter pa3 = new SqlParameter("@ngaysinh", SqlDbType.DateTime);
            pa3.Value = ngaysinh;

            SqlParameter pa4 = new SqlParameter("@sodienthoai", SqlDbType.VarChar);
            pa4.Value = sdt;

            SqlParameter pa5 = new SqlParameter("@gioitinh", SqlDbType.NVarChar);
            pa5.Value = gioitinh;

            SqlParameter pa6 = new SqlParameter("@luong", SqlDbType.Int);
            pa6.Value = luong;

            SqlParameter pa7 = new SqlParameter("@diachi", SqlDbType.NVarChar);
            pa7.Value = diachi;

            SqlParameter pa8 = new SqlParameter("@hinhanh", SqlDbType.VarBinary);
            pa8.Value = hinhanh;

            return SqlHelper.ExecuteNonQuery("dbo.sp_InsertNhanVien", CommandType.StoredProcedure, pa1, pa2, pa3, pa4, pa5, pa6, pa7, pa8);

        }
    }
}
