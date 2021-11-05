using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
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

        public DataTable GetAllEmployeeInDept10()
        {
            SqlCommand command = new SqlCommand("select e.SSN, e.Fname, e.Salary, e.Dno from Employee e, Departments d where d.Dnum = e.Dno and d.Dnum = 10");
            command.Connection = connection;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            return dataTable;
        }

        public DataTable GetAllEmployeeInDept20()
        {
            SqlCommand command = new SqlCommand("select e.SSN, e.Fname, e.Salary, e.Dno from Employee e, Departments d where d.Dnum = e.Dno and d.Dnum = 20");
            command.Connection = connection;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            return dataTable;
        }

        public DataTable GetAllEmployeeInDept30()
        {
            SqlCommand command = new SqlCommand("select e.SSN, e.Fname, e.Salary, e.Dno from Employee e, Departments d where d.Dnum = e.Dno and d.Dnum = 30");
            command.Connection = connection;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            return dataTable;
        }

        public void SetEmployee(Employee emp, string StatementType)
        {
            if (StatementType == "Insert")
            {
                StatementType = "Insert";
                SqlCommand cmd = new SqlCommand("Masterinsertupdatedelete", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SSN", emp.SSN);
                cmd.Parameters.AddWithValue("@Fname", emp.Name);
                cmd.Parameters.AddWithValue("@Salary", emp.Salary);
                cmd.Parameters.AddWithValue("@Dno", emp.Dnum);
                cmd.Parameters.AddWithValue("@StatementType", StatementType);

                connection.Open();

                cmd.ExecuteNonQuery();

                connection.Close();

            } else if(StatementType == "Update")
            {
                StatementType = "Update";
                SqlCommand cmd = new SqlCommand("Masterinsertupdatedelete", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Fname", emp.Name);
                cmd.Parameters.AddWithValue("@Salary", emp.Salary);
                cmd.Parameters.AddWithValue("@SSN", emp.SSN);
                cmd.Parameters.AddWithValue("@StatementType", StatementType);

                connection.Open();

                cmd.ExecuteNonQuery();

                connection.Close();

            }else
            {
                StatementType = "Delete";
                SqlCommand cmd = new SqlCommand("Masterinsertupdatedelete", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SSN", emp.SSN);
                cmd.Parameters.AddWithValue("@Fname", emp.Name);
                cmd.Parameters.AddWithValue("@Salary", emp.Salary);
                cmd.Parameters.AddWithValue("@Dno", emp.Dnum);
                cmd.Parameters.AddWithValue("@StatementType", StatementType);

                connection.Open();

                cmd.ExecuteNonQuery();

                connection.Close();
            }
            
           

        }
    }
}
