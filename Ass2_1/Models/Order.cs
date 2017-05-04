using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture
{
    public class Order
    {
        public int idOrder { get; set; }
        public string customer { get; set; }
        public string address { get; set; }
        public DateTime deliveryDate { get; set; }
        public string status { get; set; }
        public float total{ get; set; }

       
        public string toString()
        {
            return "" + idOrder + " " + customer + " " + address + " " + deliveryDate + " " + status + " " + total + "/n";
        }
}
}
