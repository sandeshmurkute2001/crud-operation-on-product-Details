using System.Data;
using System.Data.SqlClient;
namespace Company_Demo.Models
{
    public class Location
    {
        public SqlConnection conn {  get; set; }
        
        public Location()
        {
            string connStr = @"Data source=DESKTOP-5L0VG9B\Sandesh;Database=Omkar;Integrated Security=true";
            conn = new SqlConnection(connStr);
            conn.Open();
        }
        //public SqlConnection GetConnected()
        public SqlDataReader GetConnected()
        {
           // string StrQuery = "select * from Locn_mast";
            SqlCommand cmd = new SqlCommand("sp_show", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd.ExecuteReader();
            
        }
        public void DeleteLocation(string locndel)
        {
            SqlCommand cmd = new SqlCommand("sp_delete", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@del_code",locndel);
            cmd.ExecuteNonQuery();
        }
        public SqlDataReader showUpdate(string locnupd)
        {
            string strQuery="select * from locn_mast where locn_id="+locnupd+"";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            return cmd.ExecuteReader();
        }
        public void updateLocation(string locnid,string locndesc)
        {
            SqlCommand cmd = new SqlCommand("sp_update", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@locn_code", locnid);
            cmd.Parameters.AddWithValue("@locn_exp", locndesc);
            cmd.ExecuteNonQuery();

        }
        public void InsertLocation(string locnid,string locndesc)
        {
            SqlCommand cmd = new SqlCommand("sp_Insert",conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@locn_code", locnid);
            cmd.Parameters.AddWithValue("@locn_exp", locndesc);
            cmd.ExecuteNonQuery();

        }
    }
}
