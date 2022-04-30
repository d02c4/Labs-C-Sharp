using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib;


namespace Lab_13
{
    public class ObserveNewMyCollection<T> : NewMyCollection<T> where T : ICloneable, IComparable
    {
        // название коллекции
        public string Name { get; set; }

        // событие добавления или удаления элемента из коллекции
        public event CollectionHandler CollectionCountChanged;
        // событие изменения элемента коллеции
        public event CollectionHandler CollectionReferenceChanged;

        // конструктор коллекции
        public ObserveNewMyCollection(string name)
        {
            Name = name;
        }

        // обработчик события
        public void OnCollectionCountChanged(object source, CollectionHandlerEventArgs args)
        {
            if (CollectionCountChanged != null)
                CollectionCountChanged.Invoke(source, args);
        }
        // обработчик события
        public void OnCollectionReferenceChanged(object source, CollectionHandlerEventArgs args)
        {
            if (CollectionReferenceChanged != null)
                CollectionReferenceChanged.Invoke(source, args);
        }
        // перегрузка метода добавления элемента в коллекцию
        public override void Add(T item)
        {
            // инициирование события 
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(Name, "Произошло добавление объекта", item));
            // добавление элемента в коллекциию метод наследуетс от базового класса
            base.Add(item);
        }

        // удаление элемента из коллекции
        public bool Remove(int index)
        {
            // получаем элемент по индексу
            var item = this[index];
            // инициирование события
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(Name, "Произошло удаление объекта по индексу", item));
            // если такой элемент есть в коллекции, то он удаляется
            if (item == null)
                return false;
            base.Remove(item);
            return true;
        }

        // перегрузка индексатора
        public override T this[int index]
        {
            get
            {
                    return base[index];
            }
            set
            {
                OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs(Name, "Изменение значения с помощью Set", base[index], value));
                base[index] = value;
            }
        }


    }
}
