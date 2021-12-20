using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lib;

namespace UnitTest1
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void CreateWithDoubleArgRight()
        {
            Money a = new Money(55.66);

            Assert.AreEqual(a.Rubles, 55);
            Assert.AreEqual(a.Kopeks, 66);
        }

        [TestMethod]
        public void CreateWithDoubleArgLessZero()
        {
            Money a = new Money(-55.66);

            Assert.AreEqual(a.Rubles, 0);
            Assert.AreEqual(a.Kopeks, 0);
        }


        [TestMethod]
        public void GetRubles()
        {
            Money a = new Money(10, 0);

            Assert.AreEqual(a.Rubles, 10);
            
        }

        [TestMethod]
        public void SetRublesRight()
        {
            Money a = new Money();
            a.Rubles = 50;

            Assert.AreEqual(a.Rubles, 50);
        }

        [TestMethod]
        public void SetRublesWrong()
        {
            Money a = new Money();
            a.Rubles = -25;

            // присвоится 0
            Assert.AreEqual(a.Rubles, 0);
        }

        [TestMethod]
        public void GetKopeks()
        {
            Money a = new Money(10, 20);

            Assert.AreEqual(a.Kopeks, 20);
        }

        [TestMethod]
        public void SetKopeksRight()
        {
            Money a = new Money();

            a.Kopeks = 20;

            Assert.AreEqual(a.Kopeks, 20);
        }

        [TestMethod]
        public void SetKopeksLessZero()
        {
            Money a = new Money();

            a.Kopeks = -20;

            Assert.AreEqual(a.Kopeks, 0);
        }

        [TestMethod]
        public void SetKopeksMore100()
        {
            Money a = new Money();
            a.Kopeks = 250;

            Assert.AreEqual(a.Rubles, 2);
            Assert.AreEqual(a.Kopeks, 50);
        }

        [TestMethod]
        public void CreateMoneyWithoutArgs()
        {
            Money a = new Money();

            Assert.AreEqual(a.Rubles, 0);
            Assert.AreEqual(a.Kopeks, 0);
        }


        [TestMethod]
        public void CreateMoneyWithArgsRublesLessZero()
        {
            Money a = new Money(-15, 0);

            Assert.AreEqual(a.Rubles, 0);

        }

        [TestMethod]
        public void CreateMoneyWithArgsRublesRight()
        {
            Money a = new Money(60, 0);

            Assert.AreEqual(a.Rubles, 60);
        }

        [TestMethod]
        public void CreateMoneyWithArgsKopeksLessZero()
        {
            Money a = new Money(0, -20);
            Assert.AreEqual(a.Kopeks, 0);
        }

        [TestMethod]
        public void CreateMoneyWithArgsKopeksRight()
        {
            Money a = new Money(0, 66);
            Assert.AreEqual(a.Kopeks, 66);
        }

        [TestMethod]
        public void CreateMoneyWithArgsKopeksMore100()
        {
            Money a = new Money(0, 555);
            Assert.AreEqual(a.Rubles, 5);
            Assert.AreEqual(a.Kopeks, 55);
        }

        [TestMethod]
        public void CreateMoneyWithArgsRublesLessZeroandKopeksLessZero()
        {
            Money a = new Money(-50, -100);
            Assert.AreEqual(a.Rubles, 0);
            Assert.AreEqual(a.Kopeks, 0);
        }

        [TestMethod]
        public void CreateMoneyWithArgsRublesLessZeroandKopeksRight()
        {
            Money a = new Money(-50, 66);
            Assert.AreEqual(a.Rubles, 0);
            Assert.AreEqual(a.Kopeks, 66);
        }

        [TestMethod]
        public void CreateMoneyWithArgsRublesLessZeroandKopeksMore100()
        {
            Money a = new Money(-50, 444);
            Assert.AreEqual(a.Rubles, 4);
            Assert.AreEqual(a.Kopeks, 44);
        }

        [TestMethod]
        public void CreateMoneyWithArgsRublesRightandKopeksLessZero()
        {
            Money a = new Money(20, -100);
            Assert.AreEqual(a.Rubles, 20);
            Assert.AreEqual(a.Kopeks, 0);
        }

        [TestMethod]
        public void CreateMoneyWithArgsRublesRightandKopeksRight()
        {
            Money a = new Money(20, 60);
            Assert.AreEqual(a.Rubles, 20);
            Assert.AreEqual(a.Kopeks, 60);
        }

        [TestMethod]
        public void CreateMoneyWithArgsRublesRightandKopeksMore100()
        {
            Money a = new Money(20, 666);
            Assert.AreEqual(a.Rubles, 26);
            Assert.AreEqual(a.Kopeks, 66);
        }

        [TestMethod]
        public void MoneyMinusWrongInt()
        {
            Money a = new Money(100, 55);

            Money b = a - (-5);

            Assert.AreEqual(a.Rubles, 100);
            Assert.AreEqual(a.Kopeks, 60);
        }

        [TestMethod]
        public void MoneyMinusRightIntLessMoney()
        {
            Money a = new Money(100, 55);

            Money b = a - 60;

            Assert.AreEqual(a.Rubles, 99);
            Assert.AreEqual(a.Kopeks, 95);
        }

        [TestMethod]
        public void MoneyMinusRightIntMoreMoney()
        {
            Money a = new Money(5, 66);

            Money b = a - 600;

            Assert.AreEqual(a.Rubles, 0);
            Assert.AreEqual(a.Kopeks, 0);
        }

        [TestMethod]
        public void MoneyMinusMoney1stMore()
        {
            Money a = new Money(50,60);
            Money b = new Money(10, 20);

            Money c = a - b;
            Assert.AreEqual(c.Rubles, 40);
            Assert.AreEqual(c.Kopeks, 40);
        }

        [TestMethod]
        public void MoneyMinusMoney2ndMore()
        {
            Money a = new Money(20, 30);
            Money b = new Money(40, 50);

            Money c = a - b;
            Assert.AreEqual(c.Rubles, 0);
            Assert.AreEqual(c.Kopeks, 0);
        }

        [TestMethod]
        public void IncrimentMoneyKopeksRight()
        {
            Money a = new Money(20, 83);
            a++;
            Assert.AreEqual(a.Kopeks, 84);
        }

        [TestMethod]
        public void IncrimentMoneyKopeks99()
        {
            Money a = new Money(20, 99);
            a++;
            Assert.AreEqual(a.Rubles, 21);
            Assert.AreEqual(a.Kopeks, 0);
        }

        [TestMethod]
        public void PrefIncrimentMoneyKopeksRight()
        {
            Money a = new Money(20, 83);
            ++a;
            Assert.AreEqual(a.Kopeks, 84);
        }

        [TestMethod]
        public void PrefIncrimentMoneyKopeks99()
        {
            Money a = new Money(20, 99);
            ++a;
            Assert.AreEqual(a.Rubles, 21);
            Assert.AreEqual(a.Kopeks, 0);
        }

        [TestMethod]
        public void DecrimentMoneyKopeksRight()
        {
            Money a = new Money(11, 44);

            a--;

            Assert.AreEqual(a.Kopeks, 43);
            Assert.AreEqual(a.Rubles, 11);
        }

        [TestMethod]
        public void DecrimentMoneyKopeksRightMoneyZero()
        {
            Money a = new Money(0, 0);

            a--;

            Assert.AreEqual(a.Kopeks, 0);
            Assert.AreEqual(a.Rubles, 0);
        }

        [TestMethod]
        public void DecrimentMoneyKopeks0()
        {
            Money a = new Money(20, 0);

            a--;

            Assert.AreEqual(a.Kopeks, 99);
            Assert.AreEqual(a.Rubles, 19);
        }

        [TestMethod]
        public void PrefDecrimentMoneyKopeksRight()
        {
            Money a = new Money(20, 44);

            --a;

            Assert.AreEqual(a.Kopeks, 43);
            Assert.AreEqual(a.Rubles, 20);
        }

        [TestMethod]
        public void PrefDecrimentMoneyKopeks0()
        {
            Money a = new Money(20, 0);

            --a;

            Assert.AreEqual(a.Kopeks, 99);
            Assert.AreEqual(a.Rubles, 19);
        }

        [TestMethod]
        public void ConvertImplicitMoneyToInt()
        {
            Money a = new Money(20, 66);

            int b = (int)a;

            Assert.AreEqual(b, 20);
        }


        [TestMethod]
        public void ConvertMoneyToDoble()
        {
            Money a = new Money(20, 66);

            double b = (double)a;

            Assert.AreEqual(b, 0,66);
        }

        [TestMethod]
        public void ShowTestForMoneyWithoutArgs()
        {
            Money a = new Money();

            Assert.AreEqual(a.Show(), "0 рублей 0 копеек");
        }

        [TestMethod]
        public void ShowTestForMoneyWithArgs()
        {
            Money a = new Money(55, 66);

            Assert.AreEqual(a.Show(), "55 рублей 66 копеек");
        }

        [TestMethod]
        public void ShowTestForMoneyWithArgsDouble()
        {
            Money a = new Money(5.75);

            Assert.AreEqual(a.Show(), "5 рублей 75 копеек");
        }

        [TestMethod]
        public void TestMinusMoneyMoney1stMore()
        {
            Money a = new Money(40, 50);
            Money b = new Money(10, 20);
            Money c = new Money();
            c.Minus(a, b);

            Assert.AreEqual(a.Rubles, 30);
            Assert.AreEqual(a.Kopeks, 30);

        }

        [TestMethod]
        public void TestMinusMoneyMoney2ndMore()
        {
            Money a = new Money(10, 20);
            Money b = new Money(50, 60);
            Money c = new Money();
            c.Minus(a, b);

            Assert.AreEqual(a.Rubles, 0);
            Assert.AreEqual(a.Kopeks, 0);

        }

        [TestMethod]
        public void EqualsTest1()
        {
            Money a = new Money(10, 20);
            Money b = new Money(10, 20);

            Assert.AreEqual(a.Equals(b), true);
        }

        [TestMethod]
        public void EqualsTest2()
        {
            Money a = new Money(10, 20);
            int b = 1;

            Assert.AreEqual(a.Equals(b), false);
        }

        [TestMethod]
        public void GetCount()
        {
            Money a = new Money();
            Assert.AreEqual(a.Count, 23);
        }

    }
}
