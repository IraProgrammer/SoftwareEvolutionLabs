using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SoftwareEvolution
{
    // Класс, который представляет данные о товаре
    public class Goods
    {
        protected String _title;
        public Goods(String title)
        {
            _title = title;
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

        virtual public double GetDiscount(Item each)
        {
            return 0;
        }

        virtual public int GetBonus(Item each)
        {
            return 0;
        }
    }
}