using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture
{
   public class Product
    {
        public int idProduct { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string color { get; set; }
        public string size { get; set; }
        public float price { get; set; }
        public int stock { get; set; }
    }
}
