using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEvolution
{
    public class YAMLFile : AbstractContentFile
    {
        BillFactory billfactory = new BillFactory();
        TextReader sr;
        Customer customer;
        string line;
        string[] result;
        string name;
        int bonus;
        int itemsCount;

        override public void SetSource(TextReader sr)
        {
            this.sr = sr;
            GetNextLine();
            name = result[1].Trim();
        }

        public void Readbonus()
        {
            GetNextLine();
            bonus = Convert.ToInt32(result[1].Trim());
        }

        override public Customer GetCustomer()
        {
            customer = new Customer(name, bonus);
            return customer;
        }

        override public int GetGoodsCount()
        {
            GetNextLine();
            int goodsCount = Convert.ToInt32(result[1].Trim());
            return goodsCount;
        }

        override public void GetNextGoods(Goods[] g)
        {
            for (int i = 0; i < g.Length; i++)
            {
                // Пропустить комментарии
                do
                {
                    line = sr.ReadLine();
                } while (line.StartsWith("#"));
                result = line.Split(':');
                result = result[1].Trim().Split();
                string type = result[1].Trim();


                switch (type)
                {
                    case "REG":
                        g[i] = billfactory.Create(ProductID.RegularGoods, result[0]);
                        break;
                    case "SAL":
                        g[i] = billfactory.Create(ProductID.SaleGoods, result[0]);
                        break;
                    case "SPO":
                        g[i] = billfactory.Create(ProductID.SpecialGoods, result[0]);
                        break;
                }
            }
        }

        override public int GetItemsCount()
        {
            do
            {
                line = sr.ReadLine();
            } while (line.StartsWith("#"));
            result = line.Split(':');
            itemsCount = Convert.ToInt32(result[1].Trim());
            return itemsCount;
        }

        public void SetParameterItems(Bill b, Goods[] g)
        {
            for (int i = 0; i < itemsCount; i++)
            {
                // Пропустить комментарии
                do
                {
                    line = sr.ReadLine();
                } while (line.StartsWith("#"));
                result = line.Split(':');
                result = result[1].Trim().Split();
                int gid = Convert.ToInt32(result[0].Trim());

                double price = Convert.ToDouble(result[1].Trim());

                int qty = Convert.ToInt32(result[2].Trim());

                b.addGoods(new Item(g[gid - 1], qty, price));
            }
        }

        public void GetNextLine()
        {
            line = sr.ReadLine();
            result = line.Split(':');
        }

        public string CreateBill(StreamReader sr, IPresenter p)
        {
            SetSource(sr);
            Readbonus();
            GetCustomer();
            Bill b = new Bill(GetCustomer(), p);
            Goods[] g = new Goods[GetGoodsCount()];
            GetNextGoods(g);
            GetItemsCount();
            SetParameterItems(b, g);
            return b.statement();
        }
    }
}