using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lib;

namespace TestPoint
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestConstructor1()
        {
            Person person = new Person();
            Person person1 = new Person();
            Person person2 = new Person();

            Point<Person> p1 = new Point<Person>(person1);
            Point<Person> p2 = new Point<Person>(person2);
            Point<Person> p = new Point<Person>(person, p1, p2);
            Assert.AreEqual(p.Previous.Value, person1);
            Assert.AreEqual(p.Next.Value, person2);
            Assert.AreEqual(p.Value, person);
        }
    }
}
