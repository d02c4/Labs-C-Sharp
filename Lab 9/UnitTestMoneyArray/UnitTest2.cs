using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lib;

namespace UnitTestMoneyArray
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void GetSizeZeroSize()
        {
            MoneyArray arr = new MoneyArray();
            Assert.AreEqual(arr.Size, 0);
        }

        [TestMethod]
        public void GetSizeNormalSize()
        {
            MoneyArray arr = new MoneyArray(5);
            Assert.AreEqual(arr.Size, 5);
        }




        [TestMethod]
        public void SetSizeNormalSize()
        {
            MoneyArray arr = new MoneyArray();
            arr.Size = 10;
            Assert.AreEqual(arr.Size, 10);
        }

        [TestMethod]
        public void SetSizeSizeLessZero()
        {
            MoneyArray arr = new MoneyArray();
            arr.Size = -10;
            Assert.AreEqual(arr.Size, 0);
        }

        [TestMethod]
        public void GetElemIndexRight()
        {
            MoneyArray arr = new MoneyArray(10);

            Assert.IsInstanceOfType(arr[5], typeof(Money));
        }

        [TestMethod]
        public void GetElemIndexRightWrong()
        {
            MoneyArray arr = new MoneyArray(5);
            try
            {
                Console.WriteLine(arr[-1000]);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Ошибка доступа к индексу!");
            }
        }

        [TestMethod]
        public void SetRightElemWithIndex()
        {
            MoneyArray arr = new MoneyArray(10);

            Money a = new Money(10, 20);
            arr[5] = a;

            Assert.AreEqual(arr[5], a);
        }

        [TestMethod]
        public void SetWrongElemWithIndex()
        {
            MoneyArray arr = new MoneyArray(5);
            try
            {
                arr[-1000] = new Money();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Ошибка доступа к индексу!");
            }
        }


        [TestMethod]
        public void CreateArrWithoutArgs()
        {
            MoneyArray arr = new MoneyArray();

            Assert.AreEqual(arr.Size, 0);
        }

        [TestMethod]
        public void CreateArrWithArgRightSizeAutoGenerate()
        {
            MoneyArray arr = new MoneyArray(10);
            for (int i = 0; i < arr.Size; i++)
            {
                Assert.IsInstanceOfType(arr[i], typeof(Money));
            }
        }

        [TestMethod]
        public void CreateArrWithArgWrongSizeAutoGenerate()
        {
            try
            {
                MoneyArray arr = new MoneyArray(-25);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Ошибка, некорректно указан размер");
            }
        }

        [TestMethod]
        public void CreateArrWithArgWrong2ndArgManualInput()
        {
            try
            {
                MoneyArray arr = new MoneyArray(25, 12);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Неверно передан второй артумент. Для выбора ручного ввода, необходимо указать значение 0!");
            }
        }

        [TestMethod]
        public void CreateArrWithArgWrongSizeArgManualInput()
        {
            try
            {
                MoneyArray arr = new MoneyArray(-25, 0);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Некорректно указан размер массива!");
            }
        }

        [TestMethod]
        public void TestShowMoneyArrayRight()
        {
            MoneyArray arr = new MoneyArray(5);
            Assert.AreEqual(arr.Show(), true);

        }

        [TestMethod]
        public void TestShowMoneyArrayWrong()
        {
            MoneyArray arr = new MoneyArray();
            Assert.AreEqual(arr.Show(), false);
        }

        [TestMethod]
        public void FindMaxTestSizeMore0()
        {
            MoneyArray arr = new MoneyArray(5);

            Assert.IsInstanceOfType(arr.FindMax(), typeof(Money));
        }

        [TestMethod]
        public void FindMaxTestSizeZero()
        {
            MoneyArray arr = new MoneyArray();

            Assert.IsInstanceOfType(arr.FindMax(), typeof(Money));
        }

        [TestMethod]
        public void EqualsTest1()
        {
            MoneyArray a = new MoneyArray();
            MoneyArray b = new MoneyArray();

            Assert.AreEqual(a.Equals(b), true);
        }

        [TestMethod]
        public void EqualsTest2()
        {
            MoneyArray a = new MoneyArray();
            int b = 1;

            Assert.AreEqual(a.Equals(b), false);
        }


        [TestMethod]
        public void EqualsTest()
        {
            MoneyArray a = new MoneyArray(1);
            MoneyArray b = new MoneyArray(1);
            Money c = new Money(5, 5);
            a[0] = c;
            b[0] = c;
            Assert.AreEqual(a.Equals(b), true);
        }

        [TestMethod]
        public void NotEqualsTest()
        {
            MoneyArray a = new MoneyArray(1);
            MoneyArray b = new MoneyArray(1);
            Money c = new Money(5, 5);
            Money d = new Money(0, 0);
            a[0] = c;
            b[0] = d;
            Assert.AreEqual(a.Equals(b), false);
        }

        [TestMethod]
        public void GetCount()
        {
            MoneyArray a = new MoneyArray();
            Assert.AreEqual(a.Count, 11);
        }

    }
}
