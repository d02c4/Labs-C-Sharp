using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lib;

namespace TestCompareBy
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCompareByAVGRating()
        {
            IExecutable[] executable = new IExecutable[5];
            executable[0] = new Schoolboy();
            executable[1] = new Student();
            executable[2] = new Person();
            executable[3] = new Schoolboy("Aboba", "Aloha", 12, "M", 4.2, "Sharaga", 9);
            executable[4] = new Student("Jotaro", "Kujo", 20, "M", 3.5, "NoSharaga", "IVT-60-61", 2, 4, "Zaoch");
            Array.Sort(executable, new CompareByAVGRating());
        }

        [TestMethod]
        public void TestCompareByName()
        {
            IExecutable[] executable = new IExecutable[5];
            executable[0] = new Schoolboy();
            executable[1] = new Student();
            executable[2] = new Person();
            executable[3] = new Schoolboy("Aboba", "Aloha", 12, "M", 4.2, "Sharaga", 9);
            executable[4] = new Student("Jotaro", "Kujo", 20, "M", 3.5, "NoSharaga", "IVT-60-61", 2, 4, "Zaoch");
            Array.Sort(executable, new CompareByName());
        }

        [TestMethod]
        public void TestCompareBySurname()
        {
            IExecutable[] executable = new IExecutable[5];
            executable[0] = new Schoolboy();
            executable[1] = new Student();
            executable[2] = new Person();
            executable[3] = new Schoolboy("Aboba", "Aloha", 12, "M", 4.2, "Sharaga", 9);
            executable[4] = new Student("Jotaro", "Kujo", 20, "M", 3.5, "NoSharaga", "IVT-60-61", 2, 4, "Zaoch");
            Array.Sort(executable, new CompareBySurname());
        }

        [TestMethod]
        public void TestCompareByAge()
        {
            IExecutable[] executable = new IExecutable[5];
            executable[0] = new Schoolboy();
            executable[1] = new Student();
            executable[2] = new Person();
            executable[3] = new Schoolboy("Aboba", "Aloha", 12, "M", 4.2, "Sharaga", 9);
            executable[4] = new Student("Jotaro", "Kujo", 20, "M", 3.5, "NoSharaga", "IVT-60-61", 2, 4, "Zaoch");
            Array.Sort(executable, new CompareByAge());
        }

        [TestMethod]
        public void TestCompareByPerson()
        {
            IExecutable[] executable = new IExecutable[5];
            executable[0] = new Schoolboy();
            executable[1] = new Student();
            executable[2] = new Person();
            executable[3] = new Schoolboy("Aboba", "Aloha", 12, "M", 4.2, "Sharaga", 9);
            executable[4] = new Student("Jotaro", "Kujo", 20, "M", 3.5, "NoSharaga", "IVT-60-61", 2, 4, "Zaoch");
            Student student = new Student("Jotaro", "Kujo", 20, "M", 3.5, "NoSharaga", "IVT-60-61", 2, 4, "Zaoch");
            Array.BinarySearch(executable, student, new CompareByPerson());
        }

        [TestMethod]
        public void TestCompareByPersonError()
        {
            IExecutable[] executable = new IExecutable[5];
            executable[0] = new Schoolboy();
            executable[1] = new Student();
            executable[2] = new Person();
            executable[3] = new Schoolboy("Aboba", "Aloha", 12, "M", 4.2, "Sharaga", 9);
            executable[4] = new Student("Jotaro", "Kujo", 20, "M", 3.5, "NoSharaga", "IVT-60-61", 2, 4, "Zaoch");
            Student student = new Student("t", "t", 20, "M", 3.5, "NoSharaga", "IVT-60-61", 2, 4, "Zaoch");
            Array.BinarySearch(executable, student, new CompareByPerson());
        }

    }
}
