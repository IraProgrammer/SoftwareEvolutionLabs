using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SoftwareEvolution
{
    public abstract class AbstractContentFile
    {
        abstract public void SetSource(TextReader sr);

        abstract public Customer GetCustomer();

        abstract public int GetGoodsCount();

        abstract public void GetNextGoods(Goods[] g);

        abstract public int GetItemsCount();

    //    abstract public void GetNextItem();

   /*     public void CreateBill()
        {
            SetSource();
            GetCustomer();
            GetGoodsCount();
            GetNextGoods();
            GetItemsCount();
            GetNextItem();
        }

    */
    }
}