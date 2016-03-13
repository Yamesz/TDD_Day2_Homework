using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterShoppingCart
{
    public class ShoppingCart
    {
        //每一本都是賣100元
        private int _potterBookPrice = 100;
        public int SubtotalGet(List<Book> bookList)
        {
            int thePhilosophersStoneCount = 0;
            int theChamberofSecretsCount = 0;
            int thePrisonerofAzkabanCount = 0;
            int theGobletofFireCount = 0;
            int theOrderofthePhoenixCount = 0;
            int discountLevel = 0;
            int nonPromotionSubtotal = 0;
            int promotionSubtotal = 0;
            foreach (var item in bookList)
            {
                //算哪些是促銷書
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
                    case 9573319861://哈利波特 : 鳳凰會的密令
                        theOrderofthePhoenixCount++;
                        break;
                    default://非促銷書
                        nonPromotionSubtotal += item.Price;
                        break;
                }
            }
            //建立促銷書購買清單
            List<int> PromotionList = new List<int>();
            PromotionList.Add(thePhilosophersStoneCount);
            PromotionList.Add(theChamberofSecretsCount);
            PromotionList.Add(thePrisonerofAzkabanCount);
            PromotionList.Add(theGobletofFireCount);
            PromotionList.Add(theOrderofthePhoenixCount);

            //取得這次有買的促銷書
            var buyList = PromotionList.Where(x => x > 0).ToList();
            discountLevel = buyList.Count();
            if (discountLevel < 2)
            {
                //沒有達到促銷條件
                //促銷書的總價 + 非促銷書的總價
                return PromotionList.Sum() * this._potterBookPrice + nonPromotionSubtotal;
            }

            //取得同一本書的最小購買數量
            var minValue = buyList.Min();
            var shortCont = 0;

            //計算無法得到折扣的促銷書
            foreach (var item in buyList)
            {
                shortCont += item - minValue;
            }

            //可以折扣的促銷書
            var discountCount = buyList.Sum() - shortCont;
            //沒有折扣的促銷書
            var nonDiscountCount = bookList.Count - discountCount;

            //促銷書總價
            switch (discountLevel)
            {
                case 2:
                    promotionSubtotal = (int)(discountCount * this._potterBookPrice * 0.95)
                                        + nonDiscountCount * this._potterBookPrice;
                    break;
                case 3:
                    promotionSubtotal = (int)(discountCount * this._potterBookPrice * 0.9)
                                        + nonDiscountCount * this._potterBookPrice;
                    break;
                case 4:
                    promotionSubtotal = (int)(discountCount * this._potterBookPrice * 0.8)
                                        + nonDiscountCount * this._potterBookPrice;
                    break;
                case 5:
                    promotionSubtotal = (int)(discountCount * this._potterBookPrice * 0.75)
                                        + nonDiscountCount * this._potterBookPrice;
                    break;

            }
            //促銷書的總價 + 非促銷書的總價
            return promotionSubtotal + nonPromotionSubtotal;
        }
    }
}