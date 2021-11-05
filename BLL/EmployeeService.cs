using DLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmployeeService
    {
        DbHelper dbHelper = new DbHelper();
        List<Employee> employees = new List<Employee>();


        public List<Employee> GetEmployeeDept10
        {
            get
            {
                foreach (DataRow row in dbHelper.GetAllEmployeeInDept10().Rows)
                {
                    employees.Add(new Employee
                    {
                        SSN = (int)row["SSN"],
                        Name = row["Fname"].ToString(),
                        Salary = (int)row["Salary"],
                        Dnum = (int)row["Dno"],

                    }
                    );
                }

                return employees;
            }
        }

        public List<Employee> GetEmployeeDept20
        {
            get
            {
                foreach (DataRow row in dbHelper.GetAllEmployeeInDept20().Rows)
                {
                    employees.Add(new Employee
                    {
                        SSN = (int)row["SSN"],
                        Name = row["Fname"].ToString(),
                        Salary = (int)row["Salary"],
                        Dnum = (int)row["Dno"],

                    }
                    );
                }

                return employees;
            }
        }

        public List<Employee> GetEmployeeDept30
        {
            get
            {
                foreach (DataRow row in dbHelper.GetAllEmployeeInDept30().Rows)
                {
                    employees.Add(new Employee
                    {
                        SSN = (int)row["SSN"],
                        Name = row["Fname"].ToString(),
                        Salary = (int)row["Salary"],
                        Dnum = (int)row["Dno"],

                    }
                    );
                }

                return employees;
            }
        }

        public void SetEmployee(Employee emp,string stype)
        {
            dbHelper.SetEmployee(emp,stype);
        }

    }
}
