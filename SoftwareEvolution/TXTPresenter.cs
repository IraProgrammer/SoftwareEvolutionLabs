using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEvolution
{
    public class TXTPresenter: IPresenter
    {
        public String GetHeader(string name)
        {
            String result = "Счет для " + name + "\n";
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
    }
}
