using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterShoppingCart
{
     public class Book
    {
        public int Price { get; set; }
        public long ISBN { get; set; }
        public string Name { get; set; }
    }

     public class BookCart
    {
        public int Price { get; set; }
        public long ISBN { get; set; }
        public int Quantity { get; set; }
    }
}
