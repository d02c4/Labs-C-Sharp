using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lib;

namespace TestMyNumerator
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            NewMyCollection<Person> people = new NewMyCollection<Person>(10);
            MyEnumerator<Person> myEnumerator = (MyEnumerator<Person>)people.GetEnumerator();

            int i = 0;
            while (myEnumerator.MoveNext())
            {
                Assert.AreEqual(people[i], myEnumerator.Current);
                i++;
            }
        }
    }
}
