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
        public Bill(Customer customer)
        {
            this._customer = customer;
            this._items = new List<Item>();
        }
        public void addGoods(Item arg)
        {
            _items.Add(arg);
        }

        public String GetHeader()
        {
            String result = "Счет для " + _customer.getName() + "\n";
            result += "\t" + "Название" + "\t" + "Цена" +
            "\t" + "Кол-во" + "Стоимость" + "\t" + "Скидка" +
            "\t" + "Сумма" + "\t" + "Бонус" + "\n";
            return result;
        }
        public String GetItemString(Item each, double discount, double bonus, double thisAmount)
        {
            //int usedBonus = GetUsedBonus(each);
            String result = "\t" + each.getGoods().getTitle() + "\t" +
                "\t" + each.getPrice() + "\t" + each.getQuantity() +
                "\t" + (each.GetSum()).ToString() +
                "\t" + discount.ToString() + "\t" + thisAmount.ToString() +
                "\t" + bonus.ToString() + "\n";
            return result;
        }
        public String GetFooter(double totalAmount, double totalBonus)
        {
            String result = "Сумма счета составляет " +
            totalAmount.ToString() + "\n";
            result += "Вы заработали " + totalBonus.ToString() + " бонусных балов";
            return result;
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
            String result = GetHeader();
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
                result += GetItemString(each, discount + usedBonus, bonus, thisAmount);
                totalAmount += thisAmount;
                totalBonus += bonus;
            }
            //добавить нижний колонтитул
            result += GetFooter(totalAmount, totalBonus);
            //Запомнить бонус клиента
            _customer.receiveBonus(totalBonus);

            return result;
        }
    }
}
