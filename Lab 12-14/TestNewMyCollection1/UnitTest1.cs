using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lib;


namespace TestNewMyCollection1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestConstructor()
        {
            NewMyCollection<Person> people = new NewMyCollection<Person>();
            Assert.AreEqual(people.Count, 0);
        }

        [TestMethod]
        public void TestConstructorWithParameterSize()
        {
            NewMyCollection<Person> people = new NewMyCollection<Person>(5);
            Assert.AreEqual(people.Count, 5);
        }



        [TestMethod]
        public void TestConstructorWithParameterCollection()
        {
            NewMyCollection<Person> people = new NewMyCollection<Person>();
            Person person = new Person();
            people.Add(person);
            
            NewMyCollection<Person> people1 = new NewMyCollection<Person>(people);
            Person person1 = (Person)person.Clone();
            Assert.AreEqual(people1[0], people[0]);
            Assert.AreEqual(people.Count, people1.Count);
        }


        [TestMethod]
        public void TestContains()
        {
            NewMyCollection<Person> people = new NewMyCollection<Person>();
            Schoolboy schoolboy = new Schoolboy();
            Schoolboy schoolboy1 = (Schoolboy)schoolboy.Clone(); 
            people.Add(schoolboy);
            Assert.AreEqual(people.Contains(schoolboy1), true);
        }

        [TestMethod]
        public void TestNotContains()
        {
            NewMyCollection<Person> people = new NewMyCollection<Person>();
            Schoolboy schoolboy = new Schoolboy();
            Schoolboy schoolboy1 = (Schoolboy)schoolboy.Clone();
            schoolboy1.Name = "Alexey";
            people.Add(schoolboy);
            Assert.AreEqual(people.Contains(schoolboy1), false);
        }

        [TestMethod]
        public void TestClone()
        {
            NewMyCollection<Person> people = new NewMyCollection<Person>(5);

            NewMyCollection<Person> peopleC = (NewMyCollection<Person>)people.Clone();

            for (int i = 0; i < people.Count; i++)
            {
                Assert.AreEqual(people[i], peopleC[i]);
            }
        }

        [TestMethod]
        public void TestCopy()
        {
            NewMyCollection<Person> people = new NewMyCollection<Person>(5);

            NewMyCollection<Person> peopleC = (NewMyCollection<Person>)people.Copy();

            for (int i = 0; i < people.Count; i++)
            {
                Assert.AreEqual(people[i], peopleC[i]);
            }
        }

        [TestMethod]
        public void TestClear()
        {
            NewMyCollection<Person> people = new NewMyCollection<Person>(5);
            Assert.AreEqual(people.Count, 5);
            people.Clear();
            Assert.AreEqual(people.Count, 0);
        }


        [TestMethod]
        public void TestRemoveSizeZero()
        {
            NewMyCollection<Person> people = new NewMyCollection<Person>();
            Person person = new Person();
            bool f = people.Remove(person);
            Assert.AreEqual(f, false);
        }

        [TestMethod]
        public void TestRemoveZero()
        {
            NewMyCollection<Person> people = new NewMyCollection<Person>();
            Person person = new Person();
            people.Add(person);
            bool f = people.Remove(person);
            Assert.AreEqual(f, true);
        }

        [TestMethod]
        public void TestRemove()
        {
            NewMyCollection<Person> people = new NewMyCollection<Person>(5);
            Person person = new Person("Maxim", "Chuvashev", 18, "Man", 4.1);
            people.Add(person);
            bool f = people.Remove(person);
            Assert.AreEqual(f, true);
        }

        [TestMethod]
        public void TestRemove1()
        {
            NewMyCollection<Person> people = new NewMyCollection<Person>(5);
            Person person = new Person("Maxim", "Chuvashev", 18, "Man", 4.1);
            people.Add(person);
            people.Add(person);
            people.Add(person);
            people.Add(person);
            bool f = people.Remove(person);
            Assert.AreEqual(f, true);
        }

        [TestMethod]
        public void TestRemoveLast()
        {
            NewMyCollection<Person> people = new NewMyCollection<Person>(5);
            Person person1 = new Person("Maxim", "Chuvashev", 18, "Man", 4.1);
            Schoolboy person2 = new Schoolboy("Alexey", "Chuvashev", 18, "Man", 4.1, "aboba", 10);
            Student person3 = new Student("Andrey", "Chuvashev", 18, "Man", 4.1, "Aboba", "ИВТ-20-2б", 2, 5, "Бюджет");
            Person[] arrP = new Person[] { person1, person2, person3 };
            people.Add(arrP);
            bool f = people.Remove(person3);
            Assert.AreEqual(f, true);
        }

        [TestMethod]
        public void TestGetIndex()
        {
            NewMyCollection<Person> people = new NewMyCollection<Person>(5);
            Person person = (Person)people[0].Clone();
            Assert.AreEqual(person, people[0]);
        }

        [TestMethod]
        public void TestSetIndex()
        {
            NewMyCollection<Person> people = new NewMyCollection<Person>(5);
            Person person = new Person("Maxim", "Chuvashev", 18, "Man", 4.1);
            people[3] = person;
            Person person1 = (Person)person.Clone();
            Assert.AreEqual(person1, people[3]);
        }

        [TestMethod]
        public void TestGetIndexLess0()
        {
            NewMyCollection<Person> people = new NewMyCollection<Person>(5);
            Person person = new Person("Maxim", "Chuvashev", 18, "Man", 4.1);
            try
            {
                person = people[-1000];
            }
            catch (Exception ex)
            {
                IndexOutOfRangeException ex1 = new IndexOutOfRangeException();
                Assert.AreEqual(ex1.Message, ex.Message);
            }
        }

        [TestMethod]
        public void TestGetIndexMore()
        {
            NewMyCollection<Person> people = new NewMyCollection<Person>(5);
            Person person = new Person("Maxim", "Chuvashev", 18, "Man", 4.1);
            try
            {
                person = people[1000];
            }
            catch (Exception ex)
            {
                IndexOutOfRangeException ex1 = new IndexOutOfRangeException();
                Assert.AreEqual(ex1.Message, ex.Message);
            }
        }

        [TestMethod]
        public void TestSetIndexLess0()
        {
            NewMyCollection<Person> people = new NewMyCollection<Person>(5);
            Person person = new Person("Maxim", "Chuvashev", 18, "Man", 4.1);
            try
            {
                people[-1000] = person;
            }
            catch (Exception ex)
            {
                IndexOutOfRangeException ex1 = new IndexOutOfRangeException();
                Assert.AreEqual(ex1.Message, ex.Message);
            }
        }

        [TestMethod]
        public void TestSetIndexMoreCount()
        {
            NewMyCollection<Person> people = new NewMyCollection<Person>(5);
            Person person = new Person("Maxim", "Chuvashev", 18, "Man", 4.1);
            try
            {
                people[1000] = person;
            }
            catch (Exception ex)
            {
                IndexOutOfRangeException ex1 = new IndexOutOfRangeException();
                Assert.AreEqual(ex1.Message, ex.Message);
            }
        }

        [TestMethod]
        public void TestNum()
        {
            NewMyCollection<Person> people = new NewMyCollection<Person>(5);

            foreach(var elem in people)
            {
                Console.WriteLine(elem);
            }
        }

        [TestMethod]
        public void TestPrint()
        {
            NewMyCollection<Person> people = new NewMyCollection<Person>(5);
            people.Print();         
        }

        [TestMethod]
        public void TestPrintZeroSize()
        {
            NewMyCollection<Person> people = new NewMyCollection<Person>();
            people.Print();
        }

        [TestMethod]
        public void TestAddArr()
        {
            NewMyCollection<Person> people = new NewMyCollection<Person>();
            Person person1 = new Person("Maxim", "Chuvashev", 18, "Man", 4.1);
            Schoolboy person2 = new Schoolboy("Alexey", "Chuvashev", 18, "Man", 4.1, "aboba", 10);
            Student person3 = new Student("Andrey", "Chuvashev", 18, "Man", 4.1, "Aboba", "ИВТ-20-2б", 2, 5, "Бюджет");
            Person[] arrP = new Person[] { person1, person2, person3 };
            people.Add(arrP);
            Assert.AreEqual(people.Count, 3);
            Assert.AreEqual(people[0], person1.Clone());
            Assert.AreEqual(people[1], person2.Clone());
            Assert.AreEqual(people[2], person3.Clone());
        }

        [TestMethod]
        public void TestCopyTo()
        {
            NewMyCollection<Person> people = new NewMyCollection<Person>(5);
            Person[] peopleArr = new Person[5];
            people.CopyTo(peopleArr, 0);

            int i = 0;
            foreach (Person person in peopleArr)
            {
                Assert.AreEqual(people[i], person);
                i++;
            }
        }



    }
}
