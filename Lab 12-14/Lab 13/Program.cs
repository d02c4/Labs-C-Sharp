using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib;


namespace Lab_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ObserveNewMyCollection<Person> collection1 = new ObserveNewMyCollection<Person>("1 коллекция");
            ObserveNewMyCollection<Person> collection2 = new ObserveNewMyCollection<Person>("2 коллекция");

            Journal journal1 = new Journal("Подписан на события CollectionCountChanged и CollectionReferenceChanged из первой коллекции");
            Journal journal2 = new Journal("Подписан на событие CollectionReferenceChanged из первой и второй коллекции");

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

            journal1.PrintData();
            journal2.PrintData();

            Console.ReadKey();
        }
    }
}
