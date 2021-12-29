using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lib;

namespace TestTestCollections
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateTestCollections()
        {
            TestCollections testCollections = new TestCollections(5);
        }

        [TestMethod]
        public void TestShow()
        {
            TestCollections testCollections = new TestCollections(5);
            testCollections.Show();
        }

        [TestMethod]
        public void TestShowThen0()
        {
            TestCollections testCollections = new TestCollections(0);
            testCollections.Show();
        }

        [TestMethod]
        public void TestFindByFirstInDictByKey()
        {
            TestCollections testCollections = new TestCollections(20);
            testCollections.FindBy(0, 0);
        }

        [TestMethod]
        public void TestFindByFirstInDictByValue()
        {
            TestCollections testCollections = new TestCollections(20);
            testCollections.FindBy(0, 1);
        }

        [TestMethod]
        public void TestFindByFirstInList()
        {
            TestCollections testCollections = new TestCollections(20);
            testCollections.FindBy(0, 2);
        }

        [TestMethod]
        public void TestFindByLastInDictByKey()
        {
            TestCollections testCollections = new TestCollections(20);
            testCollections.FindBy(1, 0);
        }

        [TestMethod]
        public void TestFindByLastInDictByValue()
        {
            TestCollections testCollections = new TestCollections(20);
            testCollections.FindBy(1, 1);
        }

        [TestMethod]
        public void TestFindByLastInList()
        {
            TestCollections testCollections = new TestCollections(20);
            testCollections.FindBy(1, 2);
        }

        [TestMethod]
        public void TestFindByMiddleInDictByKey()
        {
            TestCollections testCollections = new TestCollections(20);
            testCollections.FindBy(2, 0);
        }

        [TestMethod]
        public void TestFindByMiddleInDictByValue()
        {
            TestCollections testCollections = new TestCollections(20);
            testCollections.FindBy(2, 1);
        }

        [TestMethod]
        public void TestFindByMiddleInList()
        {
            TestCollections testCollections = new TestCollections(20);
            testCollections.FindBy(2, 2);
        }


        [TestMethod]
        public void TestFindByFakeInDictByKey()
        {
            TestCollections testCollections = new TestCollections(20);
            testCollections.FindBy(3, 0);
        }

        [TestMethod]
        public void TestFindByFakeInDictByValue()
        {
            TestCollections testCollections = new TestCollections(20);
            testCollections.FindBy(3, 1);
        }

        [TestMethod]
        public void TestFindByFakeInList()
        {
            TestCollections testCollections = new TestCollections(20);
            testCollections.FindBy(3, 2);
        }


        [TestMethod]
        public void TestDelete()
        {
            TestCollections testCollections = new TestCollections(20);
            Schoolboy schoolboy = testCollections.GetValueByIndex(1);
            testCollections.Remove(schoolboy, 1, true);
        }

        [TestMethod]
        public void TestDelete2()
        {
            TestCollections testCollections = new TestCollections(20);
            Schoolboy schoolboy = testCollections.GetValueByIndex(0);
            testCollections.Remove(schoolboy, 2, true);
        }
        [TestMethod]
        public void TestDeleteNoFound()
        {
            TestCollections testCollections = new TestCollections(20);
            Schoolboy schoolboy = new Schoolboy("0", "0", 10, "Man", 3, "0", 9);
            testCollections.Remove(schoolboy, 2, true);
        }


        [TestMethod]
        public void TestAdd()
        {
            TestCollections testCollections = new TestCollections(20);
            testCollections.Add();
        }

        [TestMethod]
        public void TestMoreMax()
        {
            TestCollections testCollections = new TestCollections(1102);
            testCollections.Add();
        }

        [TestMethod]
        public void TestGetValueByIndex()
        {
            TestCollections testCollections = new TestCollections(20);
            Schoolboy schoolboy = testCollections.GetValueByIndex(0);
            Assert.AreEqual(schoolboy, testCollections.GetValueByIndex(0));
        }

        [TestMethod]
        public void TestGetValueByIndexFalse()
        {
            TestCollections testCollections = new TestCollections(20);
            Schoolboy schoolboy = testCollections.GetValueByIndex(-20);
            Assert.AreEqual(schoolboy, null);
        }

        [TestMethod]
        public void TestGetKeyByIndexFalse()
        {
            TestCollections testCollections = new TestCollections(20);
            Person person = testCollections.GetKeyByIndex(-20);
            Assert.AreEqual(person, null);
        }

        [TestMethod]
        public void TestGetKeyByIndex()
        {
            TestCollections testCollections = new TestCollections(20);
            Person person = testCollections.GetKeyByIndex(10);
            Assert.AreEqual(person, testCollections.GetKeyByIndex(10));
        }



    }
}
