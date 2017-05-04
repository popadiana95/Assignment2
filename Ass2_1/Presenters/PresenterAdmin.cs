using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture
{
    class PresenterAdmin
    {
        public EmployeeDBManager edbm;
        public FormAdmin FormA;
        public PresenterAdmin()
        {
            this.edbm = new EmployeeDBManager();
            FormA = new FormAdmin();
            FormA.buttonView.Click += new System.EventHandler(setDataGrid);
            FormA.c.Click += new System.EventHandler(addEmployee);
            FormA.button1.Click += new System.EventHandler(updateEmployee);
            FormA.button2.Click += new System.EventHandler(deleteEmployee);
            FormA.Show();
        }

        public void setDataGrid(object sender, EventArgs e)
        {
            FormA.dataGridViewEmployees.DataSource = edbm.RetrieveEmployees();
        }

        public void addEmployee(object sender, EventArgs e)
        {
            Employee empl = FormA.RetriveEmployeeInformation();
            edbm.AddEmployee(empl);
        }

        public void updateEmployee(object sender, EventArgs e)
        {
            Employee empl = FormA.RetriveEmployeeInformation();
            edbm.UpdateEmployee(empl);
        }
        public void deleteEmployee(object sender, EventArgs e)
        {
            Employee empl = FormA.RetriveEmployeeInformation();
            edbm.DeleteEmployee(empl);
        }
    }
}
