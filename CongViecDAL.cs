using System;
using System.Data.SqlClient;
using System.Data;
namespace BT_nhom_C_
{
    internal class CongViecDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public CongViecDAL()
        {
            dc = new DataConnection();
        }

        public DataTable getAllCongViec()
        {
            string sql = @"SELECT * FROM tblCongViec";
            SqlConnection con = dc.getConnection();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public bool insertCongViec(tblCongViec cv)
        {
            string sql = "INSERT INTO tblCongViec(MaCV, HoTen, CongViec, NgayThem, NgayNop, GhiChu, TrangThai, UuTien) VALUES(@MaCV,@HoTen,@CongViec,@NgayThem,@NgayNop,@GhiChu,@TrangThai,@UuTien)";
            SqlConnection con = dc.getConnection();

            try
            {

                cmd = new SqlCommand(sql, con);
                con.Open();
                //cmd.Parameters.Add("@ID", SqlDbType.Int).Value = cv.ID;
                cmd.Parameters.Add("@MaCV", SqlDbType.NVarChar).Value = cv.MaCV;
                cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = cv.HoTen;
                cmd.Parameters.Add("@CongViec", SqlDbType.NVarChar).Value = cv.CongViec;
                cmd.Parameters.Add("@NgayThem", SqlDbType.NVarChar).Value = cv.NgayThem;
                cmd.Parameters.Add("@NgayNop", SqlDbType.NVarChar).Value = cv.NgayNop;
                cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar).Value = cv.GhiChu;
                cmd.Parameters.Add("@TrangThai", SqlDbType.Bit).Value = cv.TrangThai;
                cmd.Parameters.Add("@UuTien", SqlDbType.Bit).Value = cv.UuTien;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool updateCongViec(tblCongViec cv)
        {
            string sql = "UPDATE tblCongViec SET MaCV=@MaCV, HoTen=@HoTen, CongViec=@CongViec, NgayThem=@NgayThem, NgayNop=@NgayNop, GhiChu=@GhiChu, TrangThai=@TrangThai, UuTien=@UuTien WHERE ID = @ID";
            SqlConnection con = dc.getConnection();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = cv.ID;
                cmd.Parameters.Add("@MaCV", SqlDbType.NVarChar).Value = cv.MaCV;
                cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = cv.HoTen;
                cmd.Parameters.Add("@CongViec", SqlDbType.NVarChar).Value = cv.CongViec;
                cmd.Parameters.Add("@NgayThem", SqlDbType.NVarChar).Value = cv.NgayThem;
                cmd.Parameters.Add("@NgayNop", SqlDbType.NVarChar).Value = cv.NgayNop;
                cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar).Value = cv.GhiChu;
                cmd.Parameters.Add("@TrangThai", SqlDbType.Bit).Value = cv.TrangThai;
                cmd.Parameters.Add("@UuTien", SqlDbType.Bit).Value = cv.UuTien;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool deleteCongViec(tblCongViec cv)
        {
            string sql = "DELETE tblCongViec WHERE MaCV = @MaCV";
            SqlConnection con = dc.getConnection();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaCV", SqlDbType.NVarChar).Value = cv.MaCV;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public DataTable findCongViec(string cv)
        {
            string sql = "SELECT * FROM tblCongViec WHERE HoTen like N'%" + cv + "%' OR CongViec like N'%" + cv + "%' OR GhiChu like N'%" + cv + "%' OR NgayThem like N'%"+cv+ "%' OR NgayNop like N'%"+cv+ "%' OR MaCV like N'%"+cv+"%'";
            SqlConnection con = dc.getConnection();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

    }
}
