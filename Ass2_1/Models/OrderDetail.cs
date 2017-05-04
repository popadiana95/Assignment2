using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture
{
    public class OrderDetail
    {
        public int idOrder { get; set; }
        public int idProduct { get; set; }
        public int quantity { get; set; }
        public float priceUnit { get; set; }
        public float price { get; set; }
    }
}
