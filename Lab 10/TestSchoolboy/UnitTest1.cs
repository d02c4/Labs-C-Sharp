using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lib;

namespace TestSchoolboy
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetSchoolName()
        {
            Schoolboy schoolboy = new Schoolboy();
            string expected = schoolboy.SchoolName;
            Assert.AreEqual(expected, "37 Школа");
        }

        [TestMethod]
        public void TestSetSchoolName()
        {
            Schoolboy schoolboy = new Schoolboy();
            schoolboy.SchoolName = "School 44";
            string expected = schoolboy.SchoolName;
            Assert.AreEqual(expected, "School 44");
        }

        [TestMethod]
        public void TestGetNumberClass()
        {
            Schoolboy schoolboy = new Schoolboy();
            int expected = schoolboy.NumberClass;
            Assert.AreEqual(expected, 1);
        }

        [TestMethod]
        public void TestSetNumberClass()
        {
            Schoolboy schoolboy = new Schoolboy();
            schoolboy.NumberClass = 4;
            int expected = schoolboy.NumberClass;
            Assert.AreEqual(expected, 4);
        }

        [TestMethod]
        public void TestSetNumberClassLess1()
        {
            Schoolboy schoolboy = new Schoolboy();
            schoolboy.NumberClass = -50;
            int expected = schoolboy.NumberClass;
            Assert.AreEqual(expected, 1);
        }

        [TestMethod]
        public void TestSetNumberClassMore11()
        {
            Schoolboy schoolboy = new Schoolboy();
            schoolboy.NumberClass = 20;
            int expected = schoolboy.NumberClass;
            Assert.AreEqual(expected, 11);
        }

        [TestMethod]
        public void TestGetAge()
        {
            Schoolboy schoolboy = new Schoolboy();
            int expected = schoolboy.Age;
            Assert.AreEqual(expected, 18);
        }

        [TestMethod]
        public void TestSetAge()
        {
            Schoolboy schoolboy = new Schoolboy();
            schoolboy.Age = 15;
            int expected = schoolboy.Age;
            Assert.AreEqual(expected, 15);
        }

        [TestMethod]
        public void TestSetAgeLess6()
        {
            Schoolboy schoolboy = new Schoolboy();
            schoolboy.Age = 4;
            int expected = schoolboy.Age;
            Assert.AreEqual(expected, 6);
        }

        [TestMethod]
        public void TestSetAgeMore20()
        {
            Schoolboy schoolboy = new Schoolboy();
            schoolboy.Age = 25;
            int expected = schoolboy.Age;
            Assert.AreEqual(expected, 20);
        }

        [TestMethod]
        public void TestShow()
        {
            Schoolboy schoolboy = new Schoolboy("Aboba", "Aloha", 12, "M", 4.2, "Sharaga", 9);
            schoolboy.Show();
        }

    }
}
