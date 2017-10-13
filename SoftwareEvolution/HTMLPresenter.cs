using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEvolution
{
    public class HTMLPresenter: IPresenter
    {
        public String GetHeader(string name)
        {
            String result = "Счет для " + name + "\n";
            result += "Название" + "\t" + "|Цена" +
            "\t" + "|Кол-во " + "|Стоимость" + "\t" + "|Скидка" +
            "\t" + "|Сумма" + "\t" + "|Бонус" + "\n";
            return result;
        }
        public String GetItemString(Item each, double discount, double bonus, double thisAmount)
        {
            String result = each.getGoods().getTitle() + "\t" +
                "\t|" + each.getPrice() + "\t|" + each.getQuantity() +
                "\t|" + (each.GetSum()).ToString() + "\t" +
                "\t|" + discount.ToString() + "\t|" + thisAmount.ToString() +
                "\t|" + bonus.ToString() + "\n";
            return result;
        }
        public String GetFooter(double totalAmount, double totalBonus)
        {
            String result = "Сумма счета составляет " +
            totalAmount.ToString() + "\n";
            result += "Вы заработали " + totalBonus.ToString() + " бонусных балов";
            return result;
        }
    }
}
