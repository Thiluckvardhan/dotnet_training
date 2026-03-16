using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static System.Net.WebRequestMethods;
namespace CRUD_Connected_Disconnected.Day42Disconnected
{
    internal class Linq_On_Disconnected
    {

        public static void Main()
        {
            string cs = "Server=THILUCKPC;Initial Catalog=TrainingDB;Integrated Security=True;TrustServerCertificate=True;Command Timeout=30";
            DataTable students = new DataTable();

            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand("SELECT StudentId, FullName, City, Marks, IsActive FROM Students", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                con.Open();
                da.Fill(students); // ✅ Data copied into memory
            }
            var rows = students.AsEnumerable(); // ✅ now LINQ can run

            // Example: list active students names

            //var activeNames = rows
            //    .Where(r => r.Field<bool>("IsActive") == true)
            //    .Select(r => r.Field<string>("FullName"))
            //    .ToList();
            //activeNames.ForEach(Console.WriteLine);

            //14) LINQ: Where + Select(Filter + Projection)
            var toppers = students.AsEnumerable().Where(r => r.Field<int>("Marks") >= 80)
                .Select(r => new
                {
                   Id = r.Field<int>("StudentId"),
                   Name = r.Field<string>("FullName"),
                   Marks = r.Field<int>("Marks")
                   }).ToList();

            foreach (var s in toppers)
                Console.WriteLine($"{s.Id} | {s.Name} | {s.Marks}");
        }
    }
}
