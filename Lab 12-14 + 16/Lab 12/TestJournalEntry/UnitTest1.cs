using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lib;
using Lab_13;


namespace TestJournalEntry
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestToString()
        {
            ObserveNewMyCollection<Person> people = new ObserveNewMyCollection<Person>("1 коллекция");

            Journal journal = new Journal("1 и 2");

            people.CollectionCountChanged += journal.OnCollectionCountChanged;
            people.CollectionReferenceChanged += journal.OnCollectionReferenceChanged;

            Person person = new Person("Абоба", "Chuvasheva", 20, "Woman", 5);
            Person person1 = new Person("asdf", "fdsa", 20, "Woman", 5);
            people.Add(person);
            people.Add(person1);
            people.Remove(0);
            people[0] = person1;

            journal.PrintData();

            

        }
    }
}
