using DLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DepartmentService
    {
        DbHelper dbHelper = new DbHelper();

        public List<Departement> GetDepartments()
        {
            List<Departement> departments = new List<Departement>();

            foreach (DataRow row in dbHelper.GetAllDepartments().Rows)
            {
                departments.Add(new Departement
                {
                    Dnum = (int)row["Dnum"],
                    Dname = row["Dname"].ToString(),
                }
                );
            }

            return departments;
        }

        //public void AddDepartment(Departement department)
        //{

        //}
    }
}
