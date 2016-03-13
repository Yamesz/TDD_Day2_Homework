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

		/// <summary>
		/// 取得購物車總價
		/// </summary>
		/// <param name="bookList"></param>
		/// <returns></returns>
		public int SubtotalGet(List<Book> bookList)
		{
			int nonPromotionSubtotal = 0;
			int promotionSubtotal = 0;

			//建立促銷書購買清單
			Dictionary<long,int> PromotionList = new Dictionary<long,int>();
			PromotionList.Add(9573317249,0);
			PromotionList.Add(9573317583,0);
			PromotionList.Add(9573318008,0);
			PromotionList.Add(9573318318,0);
			PromotionList.Add(9573319861,0);

			foreach (var item in bookList)
			{
				//算哪些是促銷書跟買幾本
				switch (item.ISBN)
				{
					case 9573317249://哈利波特 : 神秘的魔法石 
						PromotionList[9573317249]++;
						break;
					case 9573317583://哈利波特 : 消失的密室
						PromotionList[9573317583]++;
						break;
					case 9573318008://哈利波特 : 阿茲卡班的逃犯
						PromotionList[9573318008]++;
						break;
					case 9573318318://哈利波特 : 火盃的考驗
						PromotionList[9573318318]++;
						break;
					case 9573319861://哈利波特 : 鳳凰會的密令
						PromotionList[9573319861]++;
						break;
					default:
						//非促銷書小計
						nonPromotionSubtotal += item.Price;
						break;
				}
			}

			//取得促銷書小計
			promotionSubtotal = PromotionSubtotalGet(promotionSubtotal, PromotionList);

			//促銷書小計 + 非促銷書小計
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