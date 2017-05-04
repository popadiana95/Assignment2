using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture
{
    public class EmployeeActivity
    {
        public int idEmployee { get; set; }
        public DateTime data { get; set; }
        public string description { get; set; }
        public string toString()
        {
            return  "Data:" + data +"  "+ description;
        }
    }
}
