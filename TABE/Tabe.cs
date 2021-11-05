using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TABE
{
    public class Tabe
    {

        public decimal SSN { set; get; }
        public string Name { set; get; }

        public decimal Salary { set; get; }

        public decimal Dnum { set; get; }

        static Employee emp; 


        public void setEmployee(Employee _emp)
        {
            Employee emp2 = new Employee();

            emp2.SSN = _emp.SSN;
            emp2.Name = _emp.Name;
            emp2.Salary = _emp.Salary;
            emp2.Dnum = _emp.Dnum;

            emp = emp2;

        }
        

        
    }
}
