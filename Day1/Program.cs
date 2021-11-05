using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=Company_SD;Integrated Security=True");
            SqlCommand command = new SqlCommand();// "select * from Employee", connection);
            command.Connection = connection;
            command.CommandText = "select Dnum, Dname  from Departments";

            #region Connected Mode
            //connection.Open();

            //SqlDataReader reader = command.ExecuteReader();

            //while (reader.Read())
            //{
            //    int id = (int)reader[0];
            //    string name = reader["Name"].ToString();

            //    Console.WriteLine($"ID:{id} \t Name:{name}");
            //}

            //connection.Close(); 
            #endregion

            #region Disconnected mode
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                int id = (int)row["Dnum"];
                string name = row["Dname"].ToString();

                Console.WriteLine($"ID:{id} \t Name:{name}");
            }
            Console.ReadLine();
            #endregion

            #region Execute scalar
            //command.CommandText = "select count(*) from Employee";
            //connection.Open();
            //int employeesCount = (int)command.ExecuteScalar();
            //connection.Close(); 
            #endregion

            #region Execute NonQuery
            //command.CommandText = "delete Employee where ID  = 82";
            //connection.Open();
            //int rowsAffectedCount = command.ExecuteNonQuery();
            //connection.Close(); 
            #endregion
        }
    }
}
