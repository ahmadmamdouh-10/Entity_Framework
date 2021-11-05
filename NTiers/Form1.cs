using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NTiers
{
    public partial class Form1 : Form
    {
        Company_SDEntities context;


        public Form1()
        {


            InitializeComponent();
            context = new Company_SDEntities();
            var DeptQuery = context.Departments.Select(d => d.Dname).ToList();
            cmbDepartments.DataSource = DeptQuery;
            
        }

        private void btnchoose_Click(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;

            if (cmbDepartments.SelectedIndex == 0)
            {
                var EmpList1 = context.Employees.
                                       Select(emp => new {
                                           SSN = emp.SSN,
                                           FirstName = emp.Fname,
                                           LastName = emp.Lname,
                                           Salary = emp.Salary,
                                           DeptNum = emp.Dno })
                                       .Where(d=> d.DeptNum ==10).ToList();

                dataGridView1.DataSource = EmpList1;

            }
            else if (cmbDepartments.SelectedIndex == 1)
            {
                var EmpList2 = context.Employees.
                                       Select(emp => new {
                                           SSN = emp.SSN,
                                           FirstName = emp.Fname,
                                           LastName = emp.Lname,
                                           Salary = emp.Salary,
                                           DeptNum = emp.Dno
                                       })
                                       .Where(d => d.DeptNum == 20).ToList();

                dataGridView1.DataSource = EmpList2;

            }
            else
            {
                var EmpList3 = context.Employees.
                                       Select(emp => new {
                                           SSN = emp.SSN,
                                           FirstName = emp.Fname,
                                           LastName = emp.Lname,
                                           Salary = emp.Salary,
                                           DeptNum = emp.Dno
                                       })
                                       .Where(d => d.DeptNum == 30).ToList();

                dataGridView1.DataSource = EmpList3;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SSN.Value = (int)(dataGridView1.CurrentRow.Cells[0].Value);
            txtFname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtLName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            numericSalary.Value = (int)(dataGridView1.CurrentRow.Cells[3].Value);
            numericDeptNum.Value = (int)(dataGridView1.CurrentRow.Cells[4].Value);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            Employee emp = new Employee
            {
                SSN    = (int)SSN.Value,
                Fname  = txtFname.Text,
                Lname  = txtLName.Text,
                Salary = (int)numericSalary.Value,
                Dno    = (int)numericDeptNum.Value,
            };
            

            context.Employees.Add(emp);

            context.SaveChanges();

        }

        

        private void btnSave_Click(object sender, EventArgs e)
        {
            int i = (int)SSN.Value;
            Employee employee = context.Employees.First(emp => emp.SSN.Equals(i));

            employee.Fname  = txtFname.Text;
            employee.Lname  = txtLName.Text;
            employee.Salary =(int)numericSalary.Value;
            employee.Dno    = (int)numericDeptNum.Value;

            context.SaveChanges();
        }

     

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = (int)SSN.Value;
            Employee employee = context.Employees.First(emp => emp.SSN.Equals(i));

            context.Employees.Remove(employee);

            context.SaveChanges();

        }
    }
}
