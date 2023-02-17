using System;
using System.Data.SqlClient;
using System.Data;
using System.IO;
namespace ExportToCsv
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=model;Integrated Security=True";
            string query = "SELECT * FROM stud_details";
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            using (StreamWriter writer = new StreamWriter("C:\\exported_data.csv"))
            {
                foreach (DataRow row in dt.Rows)
                {
                    string line = "";
                    foreach (DataColumn col in dt.Columns)
                    {
                        line += row[col].ToString() + ",";
                    }
                    line = line.TrimEnd(',');
                    writer.WriteLine(line);
                }
            }
        }
    }
}