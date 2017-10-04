using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEvolution
{
    public class RegularGoods: Goods
    {
        public double discount = 0;
        public int bonus = 0;

        public RegularGoods(String title) : base(title)
        { }


        override public double GetDiscount(Item each)
        {
            if (each.getQuantity() > 2)
                discount = GetSum(each) * 0.03; // 3%
            return discount;
        }

        override public int GetBonus(Item each)
        {
            bonus = (int)(GetSum(each) * 0.05);
            return bonus;
        }
    }
}
