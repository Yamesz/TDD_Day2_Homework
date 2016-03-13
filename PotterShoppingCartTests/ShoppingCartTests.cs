﻿using System;
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
                ISBN = 9573317249,
                Name = "哈利波特 : 神秘的魔法石",
                Price = 100
            });
            var expected = 100;
            var target = new ShoppingCart();

            //Act
            int actual = target.SubtotalGet(bookList);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 第一集買一本_第二集買一本_價格應為190()
        {
            //Arrange
            var bookList = new List<Book>(){
                new Book{
                    ISBN=9573317249,
                    Name="哈利波特 : 神秘的魔法石",
                    Price=100
                },
                new Book{
                    ISBN=9573317583,
                    Name="哈利波特 : 消失的密室",
                    Price=100
                }           
            };

            var expected = 190;
            var target = new ShoppingCart();

            //Act
            int actual = target.SubtotalGet(bookList);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 一二三集各買一本_價格應為270()
        {
            //Arrange
            var bookList = new List<Book>(){
                new Book{
                    ISBN=9573317249,
                    Name="哈利波特 : 神秘的魔法石",
                    Price=100
                },
                new Book{
                    ISBN=9573317583,
                    Name="哈利波特 : 消失的密室",
                    Price=100
                },
                new Book{
                    ISBN=9573318008,
                    Name="哈利波特 : 阿茲卡班的逃犯",
                    Price=100
                }          
            };

            var expected = 270;
            var target = new ShoppingCart();

            //Act
            int actual = target.SubtotalGet(bookList);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 一二三四集各買一本_價格應為320()
        {
            //Arrange
            var bookList = new List<Book>(){
                new Book{
                    ISBN=9573317249,
                    Name="哈利波特 : 神秘的魔法石",
                    Price=100
                },
                new Book{
                    ISBN=9573317583,
                    Name="哈利波特 : 消失的密室",
                    Price=100
                },
                new Book{
                    ISBN=9573318008,
                    Name="哈利波特 : 阿茲卡班的逃犯",
                    Price=100
                },
                new Book{
                    ISBN=9573318318,
                    Name="哈利波特 : 火盃的考驗",
                    Price=100
                }          
            };

            var expected = 320;
            var target = new ShoppingCart();

            //Act
            int actual = target.SubtotalGet(bookList);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 一二三四五集各買了一本_價格應為375()
        {
            //Arrange
            var bookList = new List<Book>(){
                new Book{
                    ISBN=9573317249,
                    Name="哈利波特 : 神秘的魔法石",
                    Price=100
                },
                new Book{
                    ISBN=9573317583,
                    Name="哈利波特 : 消失的密室",
                    Price=100
                },
                new Book{
                    ISBN=9573318008,
                    Name="哈利波特 : 阿茲卡班的逃犯",
                    Price=100
                },
                new Book{
                    ISBN=9573318318,
                    Name="哈利波特 : 火盃的考驗",
                    Price=100
                },
                new Book{
                    ISBN=9573319861,
                    Name="哈利波特 : 鳳凰會的密令",
                    Price=100
                }         
            };

            var expected = 375;
            var target = new ShoppingCart();

            //Act
            int actual = target.SubtotalGet(bookList);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 一二集各買一本_第三集買兩本_價格應為270加100為370()
        {
            //Arrange
            var bookList = new List<Book>(){
                new Book{
                    ISBN=9573317249,
                    Name="哈利波特 : 神秘的魔法石",
                    Price=100
                },
                new Book{
                    ISBN=9573317583,
                    Name="哈利波特 : 消失的密室",
                    Price=100
                },
                new Book{
                    ISBN=9573318008,
                    Name="哈利波特 : 阿茲卡班的逃犯",
                    Price=100
                },
                new Book{
                    ISBN=9573318008,
                    Name="哈利波特 : 阿茲卡班的逃犯",
                    Price=100
                }          
            };

            var expected = 370;
            var target = new ShoppingCart();

            //Act
            int actual = target.SubtotalGet(bookList);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 第一集買一本_第二三集各買兩本_價格應為270加190為460()
        {
            //Arrange
            var bookList = new List<Book>(){
                new Book{
                    ISBN=9573317249,
                    Name="哈利波特 : 神秘的魔法石",
                    Price=100
                },
                new Book{
                    ISBN=9573317583,
                    Name="哈利波特 : 消失的密室",
                    Price=100
                },
                new Book{
                    ISBN=9573317583,
                    Name="哈利波特 : 消失的密室",
                    Price=100
                },
                new Book{
                    ISBN=9573318008,
                    Name="哈利波特 : 阿茲卡班的逃犯",
                    Price=100
                },
                new Book{
                    ISBN=9573318008,
                    Name="哈利波特 : 阿茲卡班的逃犯",
                    Price=100
                }          
            };

            var expected = 460;
            var target = new ShoppingCart();

            //Act
            int actual = target.SubtotalGet(bookList);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
