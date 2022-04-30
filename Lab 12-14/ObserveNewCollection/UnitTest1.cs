using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lib;
using Lab_13;

namespace ObserveNewCollection
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestConstructor()
        {
            var collection1 = new ObserveNewMyCollection<Person>("1 коллекция");
            Assert.AreEqual(collection1.Name, "1 коллекция");
        }

        [TestMethod]
        public void TestAdd()
        {
            var collection1 = new ObserveNewMyCollection<Person>("1 коллекция");
            Person person = new Person();
            collection1.Add(person);
            Assert.AreEqual(collection1[0], person.Clone());
        }

        [TestMethod]
        public void TestRemove()
        {
            var collection1 = new ObserveNewMyCollection<Person>("1 коллекция");
            Person person = new Person();
            collection1.Add(person);
            collection1.Remove(0);
            Assert.AreEqual(collection1.Count, 0);
        }

        [TestMethod]
        public void TestRemoveFalse()
        {
            var collection1 = new ObserveNewMyCollection<Person>("1 коллекция");
            Person person = new Person();
            collection1.Add(person);
            try
            {
                collection1.Remove(10);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Индекс находился вне границ массива.");
            }
        }

        [TestMethod]
        public void TestSet()
        {
            var collection1 = new ObserveNewMyCollection<Person>("1 коллекция");
            Person person = new Person("Абоба", "Chuvasheva", 20, "Woman", 5);
            Person person2 = new Person("asdf", "fdsa", 20, "Woman", 5);
            collection1.Add(person);
            collection1[0] = person2;
            Assert.AreEqual(collection1[0], person2.Clone());

        }


        [TestMethod]
        public void TestAll()
        {
            var collection1 = new ObserveNewMyCollection<Person>("1 коллекция");
            var collection2 = new ObserveNewMyCollection<Person>("2 коллекция");

            var journal1 = new Journal("Подписан на события CollectionCountChanged и CollectionReferenceChanged из 1 коллекции");
            var journal2 = new Journal("Подписан на событие CollectionReferenceChanged из первой и второй коллекции");

            // подписываем на события
            collection1.CollectionCountChanged += journal1.OnCollectionCountChanged;
            collection1.CollectionReferenceChanged += journal1.OnCollectionReferenceChanged;

            collection1.CollectionReferenceChanged += journal2.OnCollectionReferenceChanged;
            collection2.CollectionReferenceChanged += journal2.OnCollectionReferenceChanged;


            // добавление элементов
            collection1.Add(new Person());
            collection1.Add(new Schoolboy());
            collection1.Add(new Person());


            collection2.Add(new Student());
            collection2.Add(new Schoolboy());
            collection2.Add(new Schoolboy());


            // удаление элементов по индексу
            collection1.Remove(1);
            collection2.Remove(0);

            // замена элементов
            collection1[0] = new Student();
            collection1[1] = new Person();

            collection2[2] = new Schoolboy();
            collection2[1] = new Student();


            Assert.AreEqual(collection1.Name, "1 коллекция");

        }




    }
}
