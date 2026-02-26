using Microsoft.Data.SqlClient;
using System.Data;

public class Program
{
    static void Main()
    {

        Draft();

        //string cs = "Data Source=DESKTOP-UHSE201\\SQLEXPRESS;Initial Catalog=CapGDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;";
        //string sql = "SELECT ID,DEPTNAME FROM DEPT";

        //using (var con = new SqlConnection(cs))
        //using (var cmd = new SqlCommand(sql, con))
        //{
        //    con.Open();

        //    using (var reader = cmd.ExecuteReader())
        //    {
        //        while (reader.Read())
        //        {
        //            int id = reader.GetInt32(0);
        //            string name = reader.GetString(1);


        //            Console.WriteLine($"{id} | {name}  ");
        //        }
        //    }
        //}
    }


    public static void Draft()
    {
        string cs = "Data Source=DESKTOP-UHSE201\\SQLEXPRESS;Initial Catalog=CapGDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;";
        string sql = "SELECT ID,DEPTNAME FROM DEPT; SELECT top 1 * from DEPT;SELECT top 2 * from DEPT";
        DataSet ds = new DataSet();
        using (var con = new SqlConnection(cs))
        using (var cmd = new SqlCommand(sql, con))
        {
            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.InsertCommand = GetInsertCommand(con);

            adapter.Fill(ds);

        }
        ds.WriteXml("TestData");
    }

    private static SqlCommand GetInsertCommand(SqlConnection con)
    {
        SqlCommand sqlCommand = new SqlCommand("INSERT INTO DEPT (ID, DEPTNAME) VALUES (@ID, @DEPTNAME)", con);
        sqlCommand.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");
        sqlCommand.Parameters.Add("@DEPTNAME", SqlDbType.VarChar, 50, "DEPTNAME");
        return sqlCommand;

    }

    private static void GetRecord(string cs, string dept, out SqlConnection con, out SqlCommand cmd)
    {
        string sql = @"SELECT EmployeeId, FullName, Salary
               FROM dbo.Employees
               WHERE Department = @dept
               ORDER BY Salary DESC";
        con = new SqlConnection(cs);
        cmd = new SqlCommand(sql, con);

        // ✅ Add parameter
        cmd.Parameters.AddWithValue("@dept", dept);
    }
}