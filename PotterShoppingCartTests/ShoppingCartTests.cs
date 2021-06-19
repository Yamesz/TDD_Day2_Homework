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
            bookList.Add(new Book
            {
                ISBN = 1,
                Name = "七龍珠1",
                Price = 100
            });
            var expected = 100d;
            var target = new ShoppingCart();

            //Act
            var actual = target.SubtotalGet(bookList);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 第一集買一本_第二集買一本_價格應為180()
        {
            //Arrange
            var bookList = new List<Book>(){
                new Book{
                    ISBN=1,
                    Name="七龍珠1",
                    Price=100
                },
                new Book{
                    ISBN=2,
                    Name="七龍珠2",
                    Price=100
                },
            };

            var expected = 180d;
            var target = new ShoppingCart();

            //Act
            var actual = target.SubtotalGet(bookList);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 一二三集各買一本_價格應為240()
        {
            //Arrange
            var bookList = new List<Book>(){
              new Book{
                    ISBN=1,
                    Name="七龍珠1",
                    Price=100
                },
                new Book{
                    ISBN=2,
                    Name="七龍珠2",
                    Price=100
                },
                new Book{
                    ISBN=3,
                    Name="七龍珠3",
                    Price=100
                },
            };

            var expected = 240d;
            var target = new ShoppingCart();

            //Act
            var actual = target.SubtotalGet(bookList);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 一二三四集各買一本_價格應為280()
        {
            //Arrange
            var bookList = new List<Book>(){
                new Book{
                    ISBN=1,
                    Name="七龍珠1",
                    Price=100
                },
                new Book{
                    ISBN=2,
                    Name="七龍珠2",
                    Price=100
                },
                new Book{
                    ISBN=3,
                    Name="七龍珠3",
                    Price=100
                },
                new Book{
                    ISBN=4,
                    Name="七龍珠4",
                    Price=100
                },
            };

            var expected = 280d;
            var target = new ShoppingCart();

            //Act
            var actual = target.SubtotalGet(bookList);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 一二三四五集各買了一本_價格應為350()
        {
            //Arrange
            var bookList = new List<Book>(){
                 new Book{
                    ISBN=1,
                    Name="七龍珠1",
                    Price=100
                },
                new Book{
                    ISBN=2,
                    Name="七龍珠2",
                    Price=100
                },
                new Book{
                    ISBN=3,
                    Name="七龍珠3",
                    Price=100
                },
                new Book{
                    ISBN=4,
                    Name="七龍珠4",
                    Price=100
                },
                new Book{
                    ISBN=5,
                    Name="七龍珠5",
                    Price=100
                },
            };

            var expected = 350d;
            var target = new ShoppingCart();

            //Act
            var actual = target.SubtotalGet(bookList);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 買鬼滅1到3_七龍珠1到5_價格應為950()
        {
            //Arrange
            var bookList = new List<Book>(){
                new Book{
                    ISBN=1,
                    Name="七龍珠1",
                    Price=100
                },
                new Book{
                    ISBN=2,
                    Name="七龍珠2",
                    Price=100
                },
               new Book{
                    ISBN=3,
                    Name="七龍珠3",
                    Price=100
                },
                  new Book{
                    ISBN=4,
                    Name="七龍珠4",
                    Price=100
                },
                   new Book{
                    ISBN=5,
                    Name="七龍珠5",
                    Price=100
                },
                     new Book{
                    ISBN=6,
                    Name="鬼滅之刃1",
                    Price=200
                },
                new Book{
                    ISBN=7,
                    Name="鬼滅之刃2",
                    Price=200
                },
                new Book{
                    ISBN=8,
                    Name="鬼滅之刃3",
                    Price=200
                },
            };

            var expected = 950d;
            var target = new ShoppingCart();

            //Act
            var actual = target.SubtotalGet(bookList);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 七龍珠1到3各2本_價格應為480()
        {
            //Arrange
            var bookList = new List<Book>(){
               new Book{
                    ISBN=1,
                    Name="七龍珠1",
                    Price=100
                },
                 new Book{
                    ISBN=1,
                    Name="七龍珠1",
                    Price=100
                },
                new Book{
                    ISBN=2,
                    Name="七龍珠2",
                    Price=100
                },
                  new Book{
                    ISBN=2,
                    Name="七龍珠2",
                    Price=100
                },
                new Book{
                    ISBN=3,
                    Name="七龍珠3",
                    Price=100
                },
               new Book{
                    ISBN=3,
                    Name="七龍珠3",
                    Price=100
                },
            };

            var expected = 480d;
            var target = new ShoppingCart();

            //Act
            var actual = target.SubtotalGet(bookList);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 七龍珠1X2_七龍珠2X2_七龍珠3X2_七龍珠4X3_七龍珠5X10_鬼滅1X1_價格應為1780()
        {
            //Arrange
            var bookList = new List<Book>(){
                 new Book{
                    ISBN=1,
                    Name="七龍珠1",
                    Price=100
                },
                 new Book{
                    ISBN=1,
                    Name="七龍珠1",
                    Price=100
                },
                new Book{
                    ISBN=2,
                    Name="七龍珠2",
                    Price=100
                },
                  new Book{
                    ISBN=2,
                    Name="七龍珠2",
                    Price=100
                },
                new Book{
                    ISBN=3,
                    Name="七龍珠3",
                    Price=100
                },
               new Book{
                    ISBN=3,
                    Name="七龍珠3",
                    Price=100
                },
               new Book{
                    ISBN=4,
                    Name="七龍珠4",
                    Price=100
                },
                  new Book{
                    ISBN=4,
                    Name="七龍珠4",
                    Price=100
                },
                new Book{
                    ISBN=4,
                    Name="七龍珠4",
                    Price=100
                },
                new Book{
                    ISBN=5,
                    Name="七龍珠5",
                    Price=100
                },
                new Book{
                    ISBN=5,
                    Name="七龍珠5",
                    Price=100
                },
                new Book{
                    ISBN=5,
                    Name="七龍珠5",
                    Price=100
                },
                new Book{
                    ISBN=5,
                    Name="七龍珠5",
                    Price=100
                },
                new Book{
                    ISBN=5,
                    Name="七龍珠5",
                    Price=100
                },
                new Book{
                    ISBN=5,
                    Name="七龍珠5",
                    Price=100
                },
                new Book{
                    ISBN=5,
                    Name="七龍珠5",
                    Price=100
                },
                new Book{
                    ISBN=5,
                    Name="七龍珠5",
                    Price=100
                },
                new Book{
                    ISBN=5,
                    Name="七龍珠5",
                    Price=100
                },
                new Book{
                    ISBN=5,
                    Name="七龍珠5",
                    Price=100
                },
                     new Book{
                    ISBN=6,
                    Name="鬼滅之刃1",
                    Price=200
                },
            };

            var expected = 1780d;
            var target = new ShoppingCart();

            //Act
            var actual = target.SubtotalGet(bookList);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
