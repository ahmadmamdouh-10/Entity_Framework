using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DbHelper
    {
        SqlConnection connection;

        public DbHelper()
        {
            connection = new SqlConnection("Data Source=.;Initial Catalog=Company_SD;Integrated Security=True");
        }

        public DataTable GetAllDepartments()
        {
            SqlCommand command = new SqlCommand("select Dnum, Dname from Departments");
            command.Connection = connection;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            return dataTable;
        }
    }
}
