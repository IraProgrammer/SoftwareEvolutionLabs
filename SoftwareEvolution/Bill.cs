using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SoftwareEvolution
{
    public class Bill
    {
        private List<Item> _items;
        private Customer _customer;
        private IPresenter _p;
        public Bill(Customer customer, IPresenter p)
        {
            this._customer = customer;
            this._items = new List<Item>();
            this._p = p;
        }
        public void addGoods(Item arg)
        {
            _items.Add(arg);
        }

        public int GetUsedBonus(Item each)
        {
            int usedBonus = 0;
            if ((each.getGoods().GetType() ==
              typeof(RegularGoods)) && each.getQuantity() > 5)
                usedBonus = _customer.useBonus((int)(each.GetSum() - each.GetBonus()));
            if ((each.getGoods().GetType() ==
              typeof(SpecialGoods)) && each.getQuantity() > 1)
                usedBonus = _customer.useBonus((int)(each.GetSum() - each.GetDiscount()));
            return usedBonus;
        }

        public String statement()
        {
            double totalAmount = 0;
            int totalBonus = 0;
            List<Item>.Enumerator items = _items.GetEnumerator();
            String result = _p.GetHeader(_customer.getName());
            while (items.MoveNext())
            {
                double thisAmount = 0;
                Item each = (Item)items.Current;
                //определить сумму для каждой строки

                double discount = each.GetDiscount();
                int bonus = each.GetBonus();
                int usedBonus = GetUsedBonus(each);
                thisAmount = each.GetSum() - discount - usedBonus;
                //показать результаты
                result += _p.GetItemString(each, discount + usedBonus, bonus, thisAmount);
                totalAmount += thisAmount;
                totalBonus += bonus;
            }
            //добавить нижний колонтитул
            result += _p.GetFooter(totalAmount, totalBonus);
            //Запомнить бонус клиента
            _customer.receiveBonus(totalBonus);

            return result;
        }
    }
}
