using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Furniture
{
    public class EmployeeDBManager
    {
        private string connString;

        public EmployeeDBManager()
        {
            connString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        }
        public IList<Employee> RetrieveEmployees()
        {
            IList<Employee> emplList = new List<Employee>();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM employee";

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Employee empl = new Employee();
                        empl.idEmployee = reader.GetInt32("idEmployee");
                        empl.name = reader.GetString("name");
                        empl.title = reader.GetString("title");
                        emplList.Add(empl);
                    }
                }
                conn.Close();
            }

            return emplList;
        }
        public IList<EmployeeActivity> RetrieveEmployeeActivity(int idEmpl, DateTime startDate, DateTime endDate)
        {
            IList<EmployeeActivity> emplList = new List<EmployeeActivity>();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                int ys = startDate.Year;
                int ye = endDate.Year;

                int ms = startDate.Month;
                int me = endDate.Month;

                int zs = startDate.Day;
                int ze = endDate.Day;

                string de = "'" + ye + "-" + me + "-" + ze + "'";
                string ds = "'" + ys + "-" + ms + "-" + zs + "'";
                
                Console.Write(ds + " " + de+"\n");
                string statement = "SELECT * FROM emplactivity WHERE idEmployee = " + idEmpl + " AND operationDate  > " + ds + " AND operationDate <  "+ de +" ;"; 

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        EmployeeActivity empl = new EmployeeActivity();
                        empl.idEmployee = reader.GetInt32("idEmployee");
                        empl.data = reader.GetDateTime("operationDate");
                        empl.description = reader.GetString("description");
                        emplList.Add(empl);
                        
                    }
                }
                conn.Close();
            }

            return emplList;
        }
        public string generateReport(IList<EmployeeActivity> emplAct)
        {
            string lines = "Employee activity" + emplAct[0].idEmployee + "\r\n";
            for (int i = 0; i < emplAct.Count(); i++)
                lines += emplAct[i].toString()+"\r\n";
            // Write the string to a file.
            System.IO.StreamWriter file = new System.IO.StreamWriter("Report.txt");
            file.WriteLine(lines);
            file.Close();
            return "See report";
        }
        public void AddEmployee(Employee empl)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddEmployee";

                cmd.Parameters.Add(new MySqlParameter("idEmpl", empl.idEmployee));
                cmd.Parameters.Add(new MySqlParameter("name", empl.name));
                cmd.Parameters.Add(new MySqlParameter("title", empl.title));

                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        public void UpdateEmployee(Employee empl)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateEmployee";

                cmd.Parameters.Add(new MySqlParameter("idEmpl", empl.idEmployee));
                cmd.Parameters.Add(new MySqlParameter("name", empl.name));
                cmd.Parameters.Add(new MySqlParameter("title", empl.title));

                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        public void DeleteEmployee(Employee empl)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteEmployee";

                cmd.Parameters.Add(new MySqlParameter("idEmpl", empl.idEmployee));

                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }
    }
}
