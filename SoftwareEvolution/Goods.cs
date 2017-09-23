using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SoftwareEvolution
{
    // Класс, который представляет данные о товаре
    public class Goods
    {
        public const int REGULAR = 0;
        public const int SALE = 1;
        public const int SPECIAL_OFFER = 2;
        private String _title;
        private int _priceCode;
        public Goods(String title, int priceCode)
        {
            _title = title;
            _priceCode = priceCode;
        }
        public int getPriceCode()
        {
            return _priceCode;
        }
        public void setPriceCode(int arg)
        {
            _priceCode = arg;
        }
        public String getTitle()
        {
            return _title;
        }

        public double GetSum(Item each)
        {
            double sum = each.getQuantity() * each.getPrice();
            return sum;
        }

        public double GetDiscount(Item each)
        {
            double discount = 0;
            switch (each.getGoods().getPriceCode())
            {
                case Goods.REGULAR:
                    if (each.getQuantity() > 2)
                        discount = GetSum(each) * 0.03; // 3%
                    break;
                case Goods.SPECIAL_OFFER:
                    if (each.getQuantity() > 10)
                        discount = GetSum(each) * 0.005; // 0.5%
                    break;
                case Goods.SALE:
                    if (each.getQuantity() > 3)
                        discount = GetSum(each) * 0.01; // 0.1%
                    break;
            }
            return discount;
        }

        public int GetBonus(Item each)
        {
            int bonus = 0;
            switch (each.getGoods().getPriceCode())
            {
                case Goods.REGULAR:
                    bonus = (int)(GetSum(each) * 0.05);
                    break;

                case Goods.SALE:
                    bonus = (int)(GetSum(each) * 0.01);
                    break;
            }

            return bonus;
        }
    }
}