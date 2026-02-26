using Microsoft.Data.SqlClient;
using System.Data;

class SqlDataAdapterExample
{
    public static void Main()
    {
        string cs = "Server=THILUCKPC;Initial Catalog=TrainingDB;Integrated Security=True;TrustServerCertificate=True;Command Timeout=30";

        SelectData(cs);
        InsertData(cs);
        UpdateData(cs);
        DeleteData(cs);
        SelectData(cs);
    }

    static void SelectData(string cs)
    {
        Console.WriteLine("\n=== SELECT (Reading Data) ===");
        string sql = "SELECT EmployeeId, FullName, Department, Salary FROM dbo.Employees";
        DataSet ds = new DataSet();

        using (var con = new SqlConnection(cs))
        using (var cmd = new SqlCommand(sql, con))
        {
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
        }

        ds.WriteXml("TestData.xml");

        foreach (DataRow row in ds.Tables[0].Rows)
        {
            Console.WriteLine($"ID: {row["EmployeeId"]}, Name: {row["FullName"]}, Dept: {row["Department"]}, Salary: {row["Salary"]}");
        }
    }

    static void InsertData(string cs)
    {
        Console.WriteLine("\n=== INSERT (Adding New Record) ===");
        string sql = "SELECT EmployeeId, FullName, Department, Salary FROM dbo.Employees";
        DataSet ds = new DataSet();

        using (var con = new SqlConnection(cs))
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

            adapter.Fill(ds, "Employees");

            // Add new row to DataTable
            DataTable table = ds.Tables["Employees"];
            DataRow newRow = table.NewRow();
            newRow["FullName"] = "John Doe";
            newRow["Department"] = "IT";
            newRow["Salary"] = 60000;
            table.Rows.Add(newRow);

            // Update database
            int rows = adapter.Update(ds, "Employees");
            Console.WriteLine($"✅ {rows} row(s) inserted");
            SelectData(cs);
        }
    }

    static void UpdateData(string cs)
    {
        Console.WriteLine("\n=== UPDATE (Modifying Existing Record) ===");
        string sql = "SELECT EmployeeId, FullName, Department, Salary FROM dbo.Employees";
        DataSet ds = new DataSet();

        using (var con = new SqlConnection(cs))
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

            adapter.Fill(ds, "Employees");

            DataTable table = ds.Tables["Employees"];

            // Update first row (if exists)
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                Console.WriteLine($"Updating: {row["FullName"]} - Old Salary: {row["Salary"]}");
                row["Salary"] = Convert.ToDecimal(row["Salary"]) + 5000;
                Console.WriteLine($"New Salary: {row["Salary"]}");
            }

            // Update database
            int rows = adapter.Update(ds, "Employees");
            Console.WriteLine($"✅ {rows} row(s) updated");
        }
    }

    static void DeleteData(string cs)
    {
        Console.WriteLine("\n=== DELETE (Removing Record) ===");
        string sql = "SELECT EmployeeId, FullName, Department, Salary FROM dbo.Employees WHERE FullName = 'John Doe'";
        DataSet ds = new DataSet();

        using (var con = new SqlConnection(cs))
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

            adapter.Fill(ds, "Employees");

            DataTable table = ds.Tables["Employees"];

            // Delete all rows that match (John Doe)
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                Console.WriteLine($"Deleting: {row["FullName"]} from {row["Department"]}");
                row.Delete();
            }

            // Update database
            int rows = adapter.Update(ds, "Employees");
            Console.WriteLine($"✅ {rows} row(s) deleted");
        }
    }
}