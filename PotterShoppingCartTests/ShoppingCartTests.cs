using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PotterShoppingCart;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace PotterShoppingCart.Tests
{
    [TestClass()]
    public class ShoppingCartTests
    {
        [TestMethod]
        public void 第一集買一本_其他都沒買_價格應為100()
        {
            //Arrange
            var bookList = new List<Book>();
            bookList.Add(new Book{
                ISBN=9573317249,
                Name="哈利波特 : 神秘的魔法石",
                Price=100
            });
            var expected = 100;
            var target = new ShoppingCart();
   
            //Act
            int actual = target.SubtotalGet(bookList);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
