using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterShoppingCart
{
    public class ShoppingCart
    {
        public int SubtotalGet(List<Book> bookList)
        {
            int result = 0;

            foreach (var item in bookList)
            {
                result +=item.Price;
            }

            return result;
        }
    }
}
