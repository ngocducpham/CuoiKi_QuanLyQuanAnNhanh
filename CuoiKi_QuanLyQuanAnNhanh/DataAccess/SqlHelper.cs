using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class SqlHelper
    {
        public static string ConnectionString { get; set; }

        public static bool TestConnection()
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    cnn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        ///  Exec trả về cột 1 hàng 1 ví dụ: Select count(columm) chỉ trả về 1 kết quả thì method này dùng kết quả đó trả về
        /// </summary>
        /// <param name="query">Update Select Delete</param>
        /// <param name="commandType">StoredProcedure, Text, TableDirect</param>
        /// <param name="parameter">Tham số của query</param>
        /// <returns>Trả về cột 1 hàng 1</returns>
        public static object ExecuteScalar(string query, CommandType commandType, params SqlParameter[] parameter)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // command type: StoredProcedure, Text, TableDirect
                    // Ví dụ: nếu chỉ có sử dụng procedure thì CommandType.StoredProcedure, query thông thường thì CommandText
                    command.CommandType = commandType;
                    if (parameter != null)
                        command.Parameters.AddRange(parameter);
                    connection.Open();
                    return command.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// Thực hiện query cơ bản Update Select Delete,.. có tham số và trả về số hàng bị ảnh hưởng
        /// </summary>
        /// <param name="connectionString">Connection string</param>
        /// <param name="query">Update Select Delete</param>
        /// <param name="commandType">StoredProcedure, Text, TableDirect</param>
        /// <param name="parameter">Tham số của query</param>
        /// <returns>Trả về true nếu có hàng bị ảnh hưởng, ngược lại false</returns>
        public static bool ExecuteNonQuery(string query, CommandType commandType, params SqlParameter[] parameter)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = commandType;
                    if (parameter != null)
                        cmd.Parameters.AddRange(parameter);
                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                        return true;
                    return false;
                }
            }
        }

        /// <summary>
        /// Thực hiện query cơ bản Update Select Delete,.. có params trong query sau đó đưa data vào DataTable
        /// </summary>
        /// <param name="connectionString">Connection string</param>
        /// <param name="commandText">Update Select Delete</param>
        /// <param name="parameter">Tham số của query</param>
        /// <returns>Dữ liệu trả về là 1 bảng</returns>
        public static DataTable Execute(string commandText, CommandType commandType, params SqlParameter[] parameter)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    if (parameter != null)
                        cmd.Parameters.AddRange(parameter);
                    cmd.CommandType = commandType;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable data = new DataTable();
                        adapter.Fill(data);
                        return data;
                    }
                }
            }
        }

    }
}
