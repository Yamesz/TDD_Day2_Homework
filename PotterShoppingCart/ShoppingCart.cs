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
        private List<long> PromotionList;
        private Dictionary<int, double> discountList;

        public ShoppingCart()
        {
            //建立促銷書購買清單
            PromotionList = new List<long>();
            PromotionList.Add(1);
            PromotionList.Add(2);
            PromotionList.Add(3);
            PromotionList.Add(4);
            PromotionList.Add(5);

            discountList = new Dictionary<int, double>();
            discountList.Add(1, 1);
            discountList.Add(2, 0.9);
            discountList.Add(3, 0.8);
            discountList.Add(4, 0.7);
        }
        /// <summary>
        /// 取得購物車總價
        /// </summary>
        /// <param name="bookList"></param>
        /// <returns></returns>
        public double SubtotalGet(List<Book> bookList)
        {
            double nonPromotionSubtotal = 0;
            double promotionSubtotal = 0;

            var groupBookList = bookList.GroupBy(x => x.ISBN)
                                        .Select(g => new BookCart{ 
                                            ISBN = g.Key, 
                                            Price = g.First().Price,
                                            Quantity = g.Count() 
                                        });
            //紅標書
            var promotionBookList = groupBookList.Where(x=>PromotionList.Contains(x.ISBN)).ToList();
            //非紅標書
            var nonPromotionBookList = groupBookList.Where(x=>!PromotionList.Contains(x.ISBN)).ToList();
            //非紅標書可直接算小計
            nonPromotionSubtotal = nonPromotionBookList.Sum(x=>x.Price * x.Quantity);
            //找出紅標書單本買最多的數量
            var maxBooksCount = promotionBookList.Max(x=>x.Quantity);
            //最大折扣的書本數量
            var maxDistcountQuantity = discountList.Max(x => x.Key);

            //取得紅標書小計
            for (int loop = 0; loop < maxBooksCount; loop++)
            {
                //找出剩餘數量大於0的有效紅標書
                var validList = promotionBookList.Where(x=>x.Quantity > 0 );
                //還沒折扣的總價
                var total = validList.Sum(x=>x.Price);
                //有效紅標書的總類數量
                var quantity = validList.Count();
                //若超過最折扣的數量 就只能是最大折扣
                if (quantity > maxDistcountQuantity) quantity = maxDistcountQuantity;
                double discount = this.discountList[quantity];
                //算出折扣後價錢
                promotionSubtotal += total * discount;
                //將每個已經折扣後書 給扣掉數量
                foreach (var book in validList)
                {
                    promotionBookList.Where(x=>x.ISBN == book.ISBN).First().Quantity--;
                }
                
            }
            //紅標書小計 + 非紅標書小計 
            return promotionSubtotal + nonPromotionSubtotal;
        }

        /// <summary>
        /// 取得促銷書小計
        /// </summary>
        /// <param name="promotionSubtotal"></param>
        /// <param name="PromotionList"></param>
        /// <returns></returns>
        private int PromotionSubtotalGet(int promotionSubtotal, Dictionary<long, int> PromotionList)
        {
            //取出還沒算錢的list
            var buyList = PromotionList.Where(x => x.Value > 0).ToDictionary(p => p.Key, p => p.Value);
            var discountLevel = buyList.Count();
            if (discountLevel > 1)
            {
                //還有折扣組合還沒計價
                promotionSubtotal += discountGroupPriceGet(discountLevel, promotionSubtotal, buyList);
            }
            else
            {
                //剩下的書 無法取得折扣
                promotionSubtotal += buyList.Sum(x => x.Value) * this._potterBookPrice;
            }
            return promotionSubtotal;
        }

        /// <summary>
        /// 取得折扣組合的價錢
        /// </summary>
        /// <param name="discountLevel"></param>
        /// <param name="promotionSubtotal"></param>
        /// <param name="buyList"></param>
        /// <returns></returns>
        private int discountGroupPriceGet(int discountLevel, int promotionSubtotal, Dictionary<long, int> buyList)
        {
            //取得同一本書的最小購買數量
            var minValue = buyList.Select(x => x.Value).Min();
            var shortCont = 0;

            //計算無法得到折扣的促銷書
            foreach (var item in buyList)
            {
                shortCont += item.Value - minValue;
            }

            //可以折扣的促銷書
            var discountCount = buyList.Sum(x => x.Value) - shortCont;


            //促銷書總價
            switch (discountLevel)
            {
                case 2:
                    promotionSubtotal = (int)(discountCount * this._potterBookPrice * 0.95);
                    break;
                case 3:
                    promotionSubtotal = (int)(discountCount * this._potterBookPrice * 0.9);
                    break;
                case 4:
                    promotionSubtotal = (int)(discountCount * this._potterBookPrice * 0.8);
                    break;
                case 5:
                    promotionSubtotal = (int)(discountCount * this._potterBookPrice * 0.75);
                    break;

            }

            //移除已經算好價錢的特價書
            for (int loop = 0; loop < buyList.Count; loop++)
            {
                var key = buyList.Keys.ElementAt(loop);
                buyList[key] = buyList[key] - minValue;
            }

            //再算總價
            promotionSubtotal = PromotionSubtotalGet(promotionSubtotal, buyList);

            return promotionSubtotal;
        }
    }
}