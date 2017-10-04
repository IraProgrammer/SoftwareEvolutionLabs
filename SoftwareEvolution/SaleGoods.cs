using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEvolution
{
    public class SaleGoods: Goods
    {
        public double discount = 0;
        public int bonus = 0;

        public SaleGoods(String title) : base(title)
        { }

        

        override public double GetDiscount(Item each)
        {
            if (each.getQuantity() > 3)
                discount = GetSum(each) * 0.01; // 0.1%
            return discount;
        }

        override public int GetBonus(Item each)
        {
            bonus = (int)(GetSum(each) * 0.01);
            return bonus;
        }

    }
}
