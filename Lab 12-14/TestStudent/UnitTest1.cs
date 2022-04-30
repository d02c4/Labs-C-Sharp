using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lib;

namespace TestStudent
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetGroupName()
        {
            Student student = new Student();
            string expected = student.GroupName;
            Assert.AreEqual(expected, student.GroupName);

        }

        [TestMethod]
        public void TestSetGroupName()
        {
            Student student = new Student();
            student.GroupName = "RIS-18";
            string expected = student.GroupName;
            Assert.AreEqual(expected, "RIS-18");

        }


        [TestMethod]
        public void TestGetNumberExam()
        {
            Student student = new Student();
            int expected = student.NumberExam;
            int test = student.NumberExam;
            Assert.AreEqual(expected, test);
        }

        [TestMethod]
        public void TestSetNumberExam()
        {
            Student student = new Student();
            student.NumberExam = 18;
            int expected = student.NumberExam;
            Assert.AreEqual(expected, 18);
        }

        [TestMethod]
        public void TestSetNumberExamLessZero()
        {
            Student student = new Student();
            student.NumberExam = -20;
            int expected = student.NumberExam;
            Assert.AreEqual(expected, 0);
        }

        [TestMethod]
        public void TestSetNumberExamMore20()
        {
            Student student = new Student();
            student.NumberExam = 25;
            int expected = student.NumberExam;
            Assert.AreEqual(expected, 20);
        }

        [TestMethod]
        public void TestGetCourse()
        {
            Student student = new Student();
            int expected = student.Course;
            int test = student.Course;
            Assert.AreEqual(expected, test);
        }

        [TestMethod]
        public void TestSetCourse()
        {
            Student student = new Student();
            student.Course = 3;
            int expected = student.Course;
            Assert.AreEqual(expected, 3);
        }

        [TestMethod]
        public void TestSetCourseLess1()
        {
            Student student = new Student();
            student.Course = 0;
            int expected = student.Course;
            Assert.AreEqual(expected, 1);
        }

        [TestMethod]
        public void TestSetCourseMore7()
        {
            Student student = new Student();
            student.Course = 8;
            int expected = student.Course;
            Assert.AreEqual(expected, 7);
        }

        [TestMethod]
        public void TestGetNameUniver()
        {
            Student student = new Student();
            string expected = student.NameUniver;
            string test = student.NameUniver;
            Assert.AreEqual(expected, test);
        }

        [TestMethod]
        public void TestSetNameUniver()
        {
            Student student = new Student();
            student.NameUniver = "PGU";
            string expected = student.NameUniver;
            Assert.AreEqual(expected, "PGU");
        }



        [TestMethod]
        public void TestGetFormStudy()
        {
            Student student = new Student();
            string expected = student.FormStudy;
            Assert.AreEqual(expected, "Budget");
        }

        [TestMethod]
        public void TestSetFormStudy()
        {
            Student student = new Student();
            student.FormStudy = "Plat";
            string expected = student.FormStudy;
            Assert.AreEqual(expected, "Plat");
        }

        [TestMethod]
        public void TestConstructorWithArgs()
        {
            Student student = new Student("Jotaro", "Kujo", 20, "M", 3.5, "NoSharaga", "IVT-60-61", 2, 4, "Zaoch");
        }

        [TestMethod]
        public void TestGetAge()
        {
            Student student = new Student();
            int expected = student.Age;
            int test = student.Age;
            Assert.AreEqual(expected, test);
        }

        [TestMethod]
        public void TestSetAge()
        {
            Student student = new Student("Jotaro", "Kujo", 20, "M", 3.5, "NoSharaga", "IVT-60-61", 2, 4, "Zaoch");
            student.Age = 25;
            int expected = student.Age;
            int test = student.Age;
            Assert.AreEqual(expected, test);
        }

        [TestMethod]
        public void TestSetAgeLess16()
        {
            Student student = new Student("Jotaro", "Kujo", 20, "M", 3.5, "NoSharaga", "IVT-60-61", 2, 4, "Zaoch");
            student.Age = 10;
            int expected = student.Age;
            int test = student.Age;
            Assert.AreEqual(expected, test);
        }

        [TestMethod]
        public void TestSetAgeMore40()
        {
            Student student = new Student("Jotaro", "Kujo", 20, "M", 3.5, "NoSharaga", "IVT-60-61", 2, 4, "Zaoch");
            student.Age = 50;
            int expected = student.Age;
            Assert.AreEqual(expected, 40);
        }

        [TestMethod]
        public void TestShow()
        {
            Student student = new Student("Jotaro", "Kujo", 20, "M", 3.5, "NoSharaga", "IVT-60-61", 2, 4, "Zaoch");
            student.Show();
        }

        [TestMethod]
        public void TestShowWithMama()
        {
            Student student = new Student("Jotaro", "Kujo", 20, "M", 3.5, "NoSharaga", "IVT-60-61", 2, 4, "Zaoch");
            Person mama = new Person("Абоба", "Chuvasheva", 20, "w", 5);
            student.Mom = mama;
            student.Show();
        }


        [TestMethod]
        public void TestShowAllWhereCourse()
        {
            Student student = new Student("Jotaro", "Kujo", 20, "M", 3.5, "NoSharaga", "IVT-60-61", 2, 4, "Zaoch");
            student.ShowAllWhereCourse(2);
        }

        [TestMethod]
        public void TestShallowClone()
        {
            Student student = new Student("Jotaro", "Kujo", 20, "M", 3.5, "NoSharaga", "IVT-60-61", 2, 4, "Zaoch");
            Student tmp = (Student)student.ShallowClone();
        }


        [TestMethod]
        public void TestClone()
        {
            Student student = new Student("Jotaro", "Kujo", 20, "M", 3.5, "NoSharaga", "IVT-60-61", 2, 4, "Zaoch");
            Student tmp = (Student)student.Clone();
        }


        [TestMethod]
        public void TestCloneWithMom()
        {
            Student student = new Student("Jotaro", "Kujo", 20, "M", 3.5, "NoSharaga", "IVT-60-61", 2, 4, "Zaoch");
            Person mama = new Person("Абоба", "Chuvasheva", 20, "w", 5);
            student.Mom = mama;
            Student tmp = (Student)student.Clone();
        }
    }
}
