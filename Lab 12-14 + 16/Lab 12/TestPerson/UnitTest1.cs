using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lib;
using System.Reflection;

namespace TestPerson
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestShowShowWomens0()
        {
            Person person = new Person("Абоба", "Chuvashev", 20, "Men", 5);
            person.NullAllPerson();
            person.ShowWomens();
        }

        [TestMethod]
        public void TestShowShowMens0()
        {
            Person person = new Person("Абоба", "Chuvashev", 20, "Women", 5);
            person.NullAllPerson();
            person.ShowMens();
        }

        [TestMethod]
        public void TestGetName()
        {
            Person person = new Person("Абоба", "Chuvashev", 20, "Man", 5);
            string act = person.Name;
            string expected = "Абоба";
            Assert.AreEqual(expected, act);
        }

        [TestMethod]
        public void TestSetName()
        {
            Person person = new Person("Абоба", "Chuvashev", 20, "Man", 5);
            person.Name = "Diluk";
            string expected = "Diluk";
            Assert.AreEqual(expected, person.Name);
        }

        [TestMethod]
        public void TestGetSurname()
        {
            Person person = new Person("Абоба", "Chuvashev", 20, "Man", 5);
            string act = person.Surname;
            string expected = "Chuvashev";
            Assert.AreEqual(expected, act);
        }

        [TestMethod]
        public void TestSetSurname()
        {
            Person person = new Person("Абоба", "Chuvashev", 20, "Man", 5);
            person.Surname = "Arataki";
            string expected = "Arataki";
            Assert.AreEqual(expected, person.Surname);
        }


        [TestMethod]
        public void TestGetCountMen()
        {
            Person person = new Person("Абоба", "Chuvashev", 20, "Man", 5);
            int act = person.CountMens;
            int expected = 13;
            Assert.AreEqual(expected, act);
        }

        [TestMethod]
        public void TestSetCountMen()
        {
            Person person = new Person("Абоба", "Chuvashev", 20, "Man", 5);
            person.CountMens = 5;
            int expected = 5;
            Assert.AreEqual(expected, person.CountMens);
        }

        [TestMethod]
        public void TestSetCountMenCountMoreAllPerson()
        {
            Person person = new Person("Абоба", "Chuvashev", 20, "Man", 5);
            person.CountMens = 200;
            int expected = 31;
            Assert.AreEqual(expected, person.CountMens);
        }

        [TestMethod]
        public void TestSetCountMenCountLessAllPerson()
        {
            Person person = new Person("Абоба", "Chuvashev", 20, "Man", 5);
            person.CountMens = -10;
            int expected = 0;
            Assert.AreEqual(expected, person.CountMens);
        }

        [TestMethod]
        public void TestGetCountWomen()
        {
            Person person = new Person("Абоба", "Chuvasheva", 20, "Woman", 5);
            int act = person.CountWomens;
            int expected = 1;
            Assert.AreEqual(expected, act);
        }

        [TestMethod]
        public void TestSetCountWomen()
        {
            Person person = new Person("Абоба", "Chuvasheva", 20, "w", 5);
            person.CountWomens = 5;
            int expected = 5;
            Assert.AreEqual(expected, person.CountWomens);
        }

        [TestMethod]
        public void TestSetCountWomenCountMoreAllPerson()
        {
            Person person = new Person("Абоба", "Chuvasheva", 20, "w", 5);
            person.CountWomens = 200;
            int expected = 34;
            Assert.AreEqual(expected, person.CountWomens);
        }

        [TestMethod]
        public void TestSetCountWomenCountLessAllPerson()
        {
            Person person = new Person("Абоба", "Chuvasheva", 20, "w", 5);
            person.CountWomens = -2000;
            int expected = 0;
            Assert.AreEqual(expected, person.CountWomens);
        }

        [TestMethod]
        public void TestShowAllPersons()
        {
            Person person = new Person("Абоба", "Chuvasheva", 20, "w", 5);
            person.ShowAllPersons();
        }

        [TestMethod]
        public void TestConstructorWithoutParameter()
        {
            Person person = new Person("Абоба", "Chuvasheva", 20, "w", 5);
            person.Show();
        }

        [TestMethod]
        public void TestShowMens()
        {
            Person person = new Person("Абоба", "Chuvasheva", 20, "w", 5);
            person.ShowMens();
        }

        [TestMethod]
        public void TestShowMensCountMen0()
        {
            Person person = new Person("Абоба", "Chuvasheva", 20, "w", 5);
            person.CountMens = 0;
            person.ShowMens();
        }

        [TestMethod]
        public void TestShowWomensCount()
        {
            Person person = new Person("Абоба", "Chuvasheva", 20, "w", 5);
            person.ShowWomens();
        }

        [TestMethod]
        public void TestShowWomensCount0()
        {
            Person person = new Person("Абоба", "Chuvasheva", 20, "w", 5);
            person.CountWomens = 0;
            person.ShowWomens();
        }

        [TestMethod]
        public void TestShowCountMens()
        {
            Person person = new Person("Абоба", "Chuvashev", 20, "M", 5);
            person.ShowCount(0);
        }

        [TestMethod]
        public void TestShowCountMens0()
        {
            Person person = new Person("Абоба", "Chuvashev", 20, "W", 5);
            person.CountMens = 0;
            person.ShowCount(0);
        }

        [TestMethod]
        public void TestShowCountWomens()
        {
            Person person = new Person("Абоба", "Chuvasheva", 20, "w", 5);
            person.ShowCount(1);
        }

        [TestMethod]
        public void TestShowCountWomens0()
        {
            Person person = new Person("Абоба", "Chuvasheva", 20, "M", 5);
            person.CountWomens = 0;
            person.ShowCount(1);
        }

        [TestMethod]
        public void TestShowCountError()
        {
            Person person = new Person("Абоба", "Chuvasheva", 20, "w", 5);
            person.ShowCount(9);
        }

        [TestMethod]
        public void TestCompareToSecondMore()
        {
            Person p1 = new Person("Абоба", "Chuvasheva", 20, "M", 5);
            Person p2 = new Person("Абоба", "Chuvasheva", 25, "M", 5);
            int expected = p1.CompareTo(p2);
            Assert.AreEqual(expected, -1);
        }

        [TestMethod]
        public void TestCompareToFirstMore()
        {
            Person p1 = new Person("Абоба", "Chuvasheva", 25, "M", 5);
            Person p2 = new Person("Абоба", "Chuvasheva", 20, "M", 5);
            int expected = p1.CompareTo(p2);
            Assert.AreEqual(expected, 1);
        }

        [TestMethod]
        public void TestCompareToFirstEqual()
        {
            Person p1 = new Person("Абоба", "Chuvasheva", 20, "M", 5);
            Person p2 = new Person("Абоба", "Chuvasheva", 20, "M", 5);
            int expected = p1.CompareTo(p2);
            Assert.AreEqual(expected, 0);
        }


        [TestMethod]
        public void TestEqualsPerson()
        {
            Person p1 = new Person("Абоба", "Chuvasheva", 20, "M", 5);
            Person p2 = new Person("Абоба", "Chuvasheva", 20, "M", 5);
            bool expected = p1.Equals(p2);
            Assert.AreEqual(expected, true);
        }

        [TestMethod]
        public void TestEqualsPersonNotEqual()
        {
            Person p1 = new Person("Абоба", "Chuvasheva", 20, "M", 5);
            Person p2 = new Person("UWU", "Chuvasheva", 20, "M", 5);
            bool expected = p1.Equals(p2);
            Assert.AreEqual(expected, false);
        }

        [TestMethod]
        public void TestEqualsNotPerson()
        {
            Person p1 = new Person("Абоба", "Chuvasheva", 20, "M", 5);
            int a = 0;
            bool expected = p1.Equals(a);
            Assert.AreEqual(expected, false);
        }


        [TestMethod]
        public void TestGetAge()
        {
            Person p1 = new Person("Абоба", "Chuvasheva", 20, "M", 5);
            int expected = p1.Age;
            Assert.AreEqual(expected, 20);
        }

        [TestMethod]
        public void TestSetAgeMore120()
        {
            Person p1 = new Person("Абоба", "Chuvasheva", 20, "M", 5);
            p1.Age = 200;
            int expected = p1.Age;
            Assert.AreEqual(expected, 120);
        }

        [TestMethod]
        public void TestSetAgeLessZero()
        {
            Person p1 = new Person("Абоба", "Chuvasheva", 20, "M", 5);
            p1.Age = -200;
            int expected = p1.Age;
            Assert.AreEqual(expected, 0);
        }


        [TestMethod]
        public void TestSetAge()
        {
            Person p1 = new Person("Абоба", "Chuvasheva", 20, "M", 5);
            p1.Age = 40;
            int expected = p1.Age;
            Assert.AreEqual(expected, 40);
        }


        [TestMethod]
        public void TestGetAVG()
        {
            Person p1 = new Person("Абоба", "Chuvasheva", 20, "M", 5);
            double expected = p1.AVGRating;
            Assert.AreEqual(expected, 5);
        }


        [TestMethod]
        public void TestSetAVG()
        {
            Person p1 = new Person("Абоба", "Chuvasheva", 20, "M", 5);
            p1.AVGRating = 3.3;
            double expected = p1.AVGRating;
            Assert.AreEqual(expected, 3.3);
        }

        [TestMethod]
        public void TestSetAVGMore5()
        {
            Person p1 = new Person("Абоба", "Chuvasheva", 20, "M", 4);
            p1.AVGRating = 100;
            double expected = p1.AVGRating;
            Assert.AreEqual(expected, 5);
        }

        [TestMethod]
        public void TestSetAVGLess2()
        {
            Person p1 = new Person("Абоба", "Chuvasheva", 20, "M", 4);
            p1.AVGRating = 1;
            double expected = p1.AVGRating;
            Assert.AreEqual(expected, 2);
        }

        [TestMethod]
        public void TestGetHashCodeRight()
        {
            Person p1 = new Person("Абоба", "Chuvasheva", 20, "M", 4);
            Person p2 = new Person("Абоба", "Chuvasheva", 20, "M", 4);
            int expected = p1.GetHashCode();
            Assert.AreEqual(expected, p2.GetHashCode());
        }


        [TestMethod]
        public void TestGetHashCodeFalse()
        {
            Person p1 = new Person("Абоба", "Chuvasheva", 20, "M", 4);
            Person p2 = new Person();
            int expected = p1.GetHashCode();
            Assert.AreNotEqual(expected, p2.GetHashCode());
        }

    }
}
