using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lib;


namespace TestPartTimeStudent
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetNumberTimesAtUniversity()
        {
            PartTimeStudent partTimeStudent = new PartTimeStudent();
            int expected = partTimeStudent.NumberTimesAtUniversity;
            Assert.AreEqual(expected, 2);
        }

        [TestMethod]
        public void TestSetNumberTimesAtUniversity()
        {
            PartTimeStudent partTimeStudent = new PartTimeStudent();
            partTimeStudent.NumberTimesAtUniversity = 5;
            int expected = partTimeStudent.NumberTimesAtUniversity;
            Assert.AreEqual(expected, 5);
        }


        [TestMethod]
        public void TestSetNumberTimesAtUniversityLess0()
        {
            PartTimeStudent partTimeStudent = new PartTimeStudent("Jotaro", "Kujo", 20, "M", 3.5, "NoSharaga", "IVT-60-61", 2, 4, "Zaoch", 12);
            partTimeStudent.NumberTimesAtUniversity = -50;
            int expected = partTimeStudent.NumberTimesAtUniversity;
            Assert.AreEqual(expected, 0);
        }

        [TestMethod]
        public void TestShow()
        {
            PartTimeStudent partTimeStudent = new PartTimeStudent("Jotaro", "Kujo", 20, "M", 3.5, "NoSharaga", "IVT-60-61", 2, 4, "Zaoch", 12);
            partTimeStudent.Show();
        }
    }
}
