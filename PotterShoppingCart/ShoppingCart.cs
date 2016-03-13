﻿using System;
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
            int thePhilosophersStoneCount = 0;
            int theChamberofSecretsCount = 0;
            int thePrisonerofAzkabanCount = 0;
            int theGobletofFireCount = 0;
             
            foreach (var item in bookList)
            {
                //算買哪些是活動書
                switch (item.ISBN)
                {
                    case 9573317249://哈利波特 : 神秘的魔法石 
                        thePhilosophersStoneCount++;
                        break;
                    case 9573317583://哈利波特 : 消失的密室
                        theChamberofSecretsCount++;
                        break;
                    case 9573318008://哈利波特 : 阿茲卡班的逃犯
                        thePrisonerofAzkabanCount++;
                        break;
                    case 9573318318://哈利波特 : 火盃的考驗
                        theGobletofFireCount++;
                        break;
                        
                }

                //原價
                result += item.Price;
            }

            //折扣條件
            if (thePhilosophersStoneCount > 0 
                && theChamberofSecretsCount > 0
                && thePrisonerofAzkabanCount == 0
                && theGobletofFireCount == 0)
            {
                result = (int)(result * 0.95);
            }
            else if(thePhilosophersStoneCount > 0 
                    && theChamberofSecretsCount > 0
                    && thePrisonerofAzkabanCount > 0
                    && theGobletofFireCount == 0)
            {
                result = (int)(result * 0.9);
            }
            else if(thePhilosophersStoneCount > 0 
                    && theChamberofSecretsCount > 0
                    && thePrisonerofAzkabanCount > 0
                    && theGobletofFireCount > 0)
            {
                result = (int)(result * 0.8);
            }

            return result;
        }
    }
}