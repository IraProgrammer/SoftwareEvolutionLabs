using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEvolution
{
    public class SpecialGoods: Goods

    {
        public double discount = 0;
        public int bonus = 0;

        public SpecialGoods(String title) : base(title)
        { }

        override public double GetDiscount(Item each)
        {
            if (each.getQuantity() > 10)
                discount = GetSum(each) * 0.005; // 0.5%
            return discount;
        }

        override public int GetBonus(Item each)
        {
            return 0;
        }

    }
}
