using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SoftwareEvolution;

namespace BillTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void DiscountRegularLess2()
        {
            Goods cola = new RegularGoods("Cola");
            Item i1 = new Item(cola, 1, 65);
            Customer x = new Customer("test", 0);
            IPresenter p = new TXTPresenter();
            Bill b1 = new Bill(x, p);
            b1.addGoods(i1);
            string bill = b1.statement();
            string expected = "Счет для test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t1\t65\t0\t65\t3\nСумма счета составляет 65\nВы заработали 3 бонусных балов";
            Assert.AreEqual(expected, bill);
        }

        [Test]
        public void DiscountRegularMore2()
        {
            Goods cola = new RegularGoods("Cola");
            Item i1 = new Item(cola, 6, 65);
            Customer x = new Customer("test", 10);
            IPresenter p = new TXTPresenter();
            Bill b1 = new Bill(x, p);
            b1.addGoods(i1);
            string bill = b1.statement();
            string expected = "Счет для test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t6\t390\t21,7\t368,3\t19\nСумма счета составляет 368,3\nВы заработали 19 бонусных балов";
            Assert.AreEqual(expected, bill);
        }

        [Test]
        public void DiscountSaleLess3()
        {
            Goods twix = new SaleGoods("Twix");
            Item i1 = new Item(twix, 2, 38);
            Customer x = new Customer("test", 0);
            IPresenter p = new TXTPresenter();
            Bill b1 = new Bill(x, p);
            b1.addGoods(i1);
            string bill = b1.statement();
            string expected = "Счет для test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tTwix\t\t38\t2\t76\t0\t76\t0\nСумма счета составляет 76\nВы заработали 0 бонусных балов";
            Assert.AreEqual(expected, bill);
        }

        [Test]
        public void DiscountSaleMore3()
        {
            Goods twix = new SaleGoods("Twix");
            Item i1 = new Item(twix, 7, 38);
            Customer x = new Customer("test", 0);
            IPresenter p = new TXTPresenter();
            Bill b1 = new Bill(x, p);
            b1.addGoods(i1);
            string bill = b1.statement();
            string expected = "Счет для test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tTwix\t\t38\t7\t266\t2,66\t263,34\t2\nСумма счета составляет 263,34\nВы заработали 2 бонусных балов";
            Assert.AreEqual(expected, bill);
        }

        [Test]
        public void DiscountSpecialLess10()
        {
            Goods bread = new SpecialGoods("Bread");
            Item i1 = new Item(bread, 8, 23);
            Customer x = new Customer("test", 0);
            IPresenter p = new TXTPresenter();
            Bill b1 = new Bill(x, p);
            b1.addGoods(i1);
            string bill = b1.statement();
            string expected = "Счет для test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tBread\t\t23\t8\t184\t0\t184\t0\nСумма счета составляет 184\nВы заработали 0 бонусных балов";
            Assert.AreEqual(expected, bill);
        }

        [Test]
        public void DiscountSpecialMore10()
        {
            Goods bread = new SpecialGoods("Bread");
            Item i1 = new Item(bread, 13, 23);
            Customer x = new Customer("test", 0);
            IPresenter p = new TXTPresenter();
            Bill b1 = new Bill(x, p);
            b1.addGoods(i1);
            string bill = b1.statement();
            string expected = "Счет для test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tBread\t\t23\t13\t299\t1,495\t297,505\t0\nСумма счета составляет 297,505\nВы заработали 0 бонусных балов";
            Assert.AreEqual(expected, bill);
        }

        [Test]
        public void BonusRegular()
        {
            Goods bonaqua = new RegularGoods("BonAqua");
            Item i1 = new Item(bonaqua, 8, 40);
            Customer x = new Customer("test", 0);
            IPresenter p = new TXTPresenter();
            Bill b1 = new Bill(x, p);
            b1.addGoods(i1);
            string bill = b1.statement();
            string expected = "Счет для test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tBonAqua\t\t40\t8\t320\t9,6\t310,4\t16\nСумма счета составляет 310,4\nВы заработали 16 бонусных балов";
            Assert.AreEqual(expected, bill);
        }

        [Test]
        public void BonusSale()
        {
            Goods doshirak = new SaleGoods("Doshirak");
            Item i1 = new Item(doshirak, 20, 36);
            Customer x = new Customer("test", 0);
            IPresenter p = new TXTPresenter();
            Bill b1 = new Bill(x, p);
            b1.addGoods(i1);
            string bill = b1.statement();
            string expected = "Счет для test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tDoshirak\t\t36\t20\t720\t7,2\t712,8\t7\nСумма счета составляет 712,8\nВы заработали 7 бонусных балов";
            Assert.AreEqual(expected, bill);
        }

        [Test]
        public void BonusSpecial()
        {
            Goods lays = new SpecialGoods("Lays");
            Item i1 = new Item(lays, 2, 93);
            Customer x = new Customer("test", 0);
            IPresenter p = new TXTPresenter();
            Bill b1 = new Bill(x, p);
            b1.addGoods(i1);
            string bill = b1.statement();
            string expected = "Счет для test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tLays\t\t93\t2\t186\t0\t186\t0\nСумма счета составляет 186\nВы заработали 0 бонусных балов";
            Assert.AreEqual(expected, bill);
        }

        [Test]
        public void UseBonusRegularLess5()
        {
            Goods cola = new RegularGoods("Cola");
            Item i1 = new Item(cola, 1, 65);
            Customer x = new Customer("test", 20);
            IPresenter p = new TXTPresenter();
            Bill b1 = new Bill(x, p);
            b1.addGoods(i1);
            string bill = b1.statement();
            string expected = "Счет для test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t1\t65\t0\t65\t3\nСумма счета составляет 65\nВы заработали 3 бонусных балов";
            Assert.AreEqual(expected, bill);
        }

        [Test]
        public void UseBonusRegularMore5()
        {
            Goods cola = new RegularGoods("Cola");
            Item i1 = new Item(cola, 6, 65);
            Customer x = new Customer("test", 30);
            IPresenter p = new TXTPresenter();
            Bill b1 = new Bill(x, p);
            b1.addGoods(i1);
            string bill = b1.statement();
            string expected = "Счет для test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t6\t390\t41,7\t348,3\t19\nСумма счета составляет 348,3\nВы заработали 19 бонусных балов";
            Assert.AreEqual(expected, bill);
        }

        [Test]
        public void UseBonusSaleMore1()
        {
            Goods twix = new SaleGoods("Twix");
            Item i1 = new Item(twix, 7, 38);
            Customer x = new Customer("test", 0);
            IPresenter p = new TXTPresenter();
            Bill b1 = new Bill(x, p);
            b1.addGoods(i1);
            string bill = b1.statement();
            string expected = "Счет для test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tTwix\t\t38\t7\t266\t2,66\t263,34\t2\nСумма счета составляет 263,34\nВы заработали 2 бонусных балов";
            Assert.AreEqual(expected, bill);
        }

        [Test]
        public void UseBonusSpecial()
        {
            Goods bread = new SpecialGoods("Bread");
            Item i1 = new Item(bread, 10, 23);
            Customer x = new Customer("test", 0);
            IPresenter p = new TXTPresenter();
            Bill b1 = new Bill(x, p);
            b1.addGoods(i1);
            string bill = b1.statement();
            string expected = "Счет для test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tBread\t\t23\t10\t230\t0\t230\t0\nСумма счета составляет 230\nВы заработали 0 бонусных балов";
            Assert.AreEqual(expected, bill);
        }

        [Test]
        public void HTMLPresenterTest()
        {
            Goods bread = new SpecialGoods("Bread");
            Item i1 = new Item(bread, 10, 23);
            Customer x = new Customer("test", 0);
            IPresenter p = new HTMLPresenter();
            Bill b1 = new Bill(x, p);
            b1.addGoods(i1);
            string bill = b1.statement();
            string expected = "Счет для test\nНазвание\t|Цена\t|Кол-во |Стоимость\t|Скидка\t|Сумма\t|Бонус\nBread\t\t|23\t|10\t|230\t\t|0\t|230\t|0\nСумма счета составляет 230\nВы заработали 0 бонусных балов";
            Assert.AreEqual(expected, bill);
        }
    }
}
