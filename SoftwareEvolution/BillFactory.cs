using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEvolution
{
    public enum ProductID
    {
        RegularGoods,
        SaleGoods,
        SpecialGoods
    }
    public class BillFactory
    {
        // Паттерн "Фабричный метод"
        public Goods Create(ProductID id, string title)
        {

            if (id == ProductID.RegularGoods)
            {
                return new RegularGoods(title);
            }
            if (id == ProductID.SaleGoods)
            {
                return new SaleGoods(title);
            }
            if (id == ProductID.SpecialGoods)
            {
                return new SpecialGoods(title);
            }
            return null;
        }
    }
}