using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{

   

    public class NewMyCollection<T> : IDisposable, ICloneable, IEnumerable<T>, ICollection<T> where T : ICloneable, IComparable
    {


        // количество элементов в коллекции
        public int Count { get; private set; }

        public bool IsReadOnly { get; set; }

        // начало двунаправленного списка
        public Point<T> Begin { get; private set; }
        // конец двунаправленного списка
        public Point<T> End { get; private set; }

        // добавление одного элемента в коллекцию
        public virtual void Add(T item)
        {
            if (IsReadOnly) 
                return;
            // если в списке нет элементов
            if (Begin == null)
            {
                Begin = new Point<T>(item);
                End = new Point<T>(item);
            }
            // если есть эелементы
            else
            {
                // нумератор
                Point<T> point = Begin;
                // пока следующий элемент есть в списке
                while(point.Next != null)
                {
                    // переходим к следующему элементу в списке
                    point = point.Next;
                }
                // создаем новый элемент и добавляем в конец списка
                point.Next = new Point<T>(item);
                // сдвигаем указатель конца списка
                End = point.Next;
            }
            // уделичение количества элементов
            Count++;
        }


        // добаление нескольких элементов в коллекцию
        public void Add(T[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                // вызывается метод добавления для каждого элемента массива
                Add(items[i]);
            }
        }

        // конструктор по умолчанию
        public NewMyCollection()
        {
            Count = 0;
        }

        // конструктор коллекции с указаным размером коллекции
        public NewMyCollection(int capacity)
        {
            for(int i = 0; i < capacity; i++)
            {
                // получаем случайный тип данных со случайными значениями
                var item = RandomClass.GetRadomClass();
                // добавляем случайное значение в коллекцию
                Add((T)(object)item);
            }
        }

        // коллекция создается на основе существующей коллекции
        public NewMyCollection(NewMyCollection<T> c)
        {
            // проходимся по всем элементам коллекции
            foreach (var item in c)
            {
                // добавляем эти копии этих элементов в текущую коллекцию
                this.Add((T)item.Clone());
            }
        }

        // конструктор на основе списка
        public NewMyCollection(List<T> list)
        {
            // проходимся по всем элементам списка
            foreach (var item in list)
            {
                // добавляем эти копии этих элементов в текущую коллекцию
                this.Add((T)item.Clone());
            }
        }

        // метод проверки есть ли указанный элемент в коллекции
        public bool Contains(T item)
        {
            // проходимся по всем элементам просматриваемой коллекции
            foreach (var element in this)
            {
                // сравнимаем значение элемента коллекции и требуемого объекта
                if (element.Equals((T)item))
                    return true;
            }
            return false;
        }

        // Клонирование колекции
        public object Clone()
        {
            // возвращаем копию объекта
            return new NewMyCollection<T>(this);
        }

        // поверхностное копирование коллекции
        public object Copy()
        {
            return this.MemberwiseClone();
        }

        // сравнимание 
        public int CompareTo(object obj)
        {
            return Count.CompareTo(obj);
        }


        // высвобождение неуправляемых ресурсов
        public void Dispose()
        {
            Begin = null;
            End = null;
            Count = 0;
        }

        // метод для вызова метода Dispose
        public void Clear()
        {
            if (IsReadOnly) 
                return;
            Dispose();
        }

        // удаление элемента из коллекции
        public virtual bool Remove(T item)
        {
            // если в коллекции нет элементов
            if (Begin == null || IsReadOnly)
                return false;
            // если в коллекции есть элементы
            // если количество элементов равно 1 и удаляемый элемент равен тому единственому элементу
            if(Count == 1 && Begin.Value.Equals(item))
            {
                // вызываем метод очистки всей коллекции
                Clear();
            }
            // если же в коллекции больше одного элемента
            else
            {
                // создаем нумератор который указывает на текущий элемент
                Point<T> current = Begin;
                // создаем нумератор которым будем запоминать предыдущий элемент
                Point<T> tmp = Begin;
                // пока не нашли совпадение значения текущего проспатриваемого элемента и пока текущий просматриваемый элемент не равен null
                while(!current.Value.Equals(item) && current != null)
                {
                    // запоминаем текущую позицию
                    tmp = current;
                    // двигаем нумератор
                    current = current.Next;
                }
                //если текущий просматриваемый элемент равен null, то элемент отсутствует в коллекции 
                if (current == null)
                    return false;
                // если искомый элемент оказался последним в списке
                if (current.Next == null)
                    // удаляем значение current
                    tmp.Next = null;
                else if (current == Begin)
                {
                    // исключаем current из списка
                    Begin = current.Next;
                    Begin.Previous = null;
                    current = Begin;
                    current.Previous = null;
                    tmp = Begin;
                }
                // если искомый элемент не последний 
                else
                {
                    // исключаем current из списка
                    current.Next.Previous = tmp;
                    tmp.Next = current.Next;
                }
                // уменьшаем количество элементов на 1
                Count--;
            }
            // если количество элемнтов равно 0
            if(Count == 0)
            {
                Begin = null;
                End = null;
            }
            // элемент успешно удален
            return true;
        }

        // индексатор
        public virtual T this[int index]
        {
            get
            {
                // выход за рамки списка
                if (index < 0 || index > Count) 
                    // бросаем ошибку
                    throw new IndexOutOfRangeException();

                // создаем нумератор
                Point<T> curr = Begin;
                
                while (index-- != 0)
                {
                    // переходим к следующему элементу
                    curr = curr.Next;
                    // если текущий просматриваемый элемент равен null, значит мы достигли конца коллекции
                    if (curr == null)
                    {
                        // текущий просматриваемый элемент равен первому элементу коллекции
                        curr = Begin;
                    }
                }
                // возвращаем наденное значение
                return curr.Value;
            }
            set
            {
                // выход за рамки списка
                if (index < 0 || index > Count)
                    // бросаем ошибку
                    throw new IndexOutOfRangeException();
                // создаем нумератор и ставим его в начало коллекции
                Point<T> curr = Begin;
                
                while (index-- != 0)
                {
                    // переходим к следующему элементу коллекции
                    curr = curr.Next;
                }
                // присваиваем найденному элементу коллекции требуемое значение
                curr.Value = value;
            }
        }


        // Копирует элементы коллекции ICollection в массив Array, начиная с указанного индекса массива Array.
        public void CopyTo(T[] array, int arrayIndex)
        {
            
            int i = arrayIndex;

            // проходимся по всем элементам массива
            foreach (T item in this)
            {
                // если достигли границы массива
                if (i == array.Length) 
                    // завершаем цикл
                    break;
                // 
                array[i++] = (T)item.Clone();
            }
        }

        //метод обобщенного интерфейса IEnumerable<T>, который возвращает обобщенный объект-нумератор
        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator<T>(this);
        }

        //метод необобщенного интерфейса IEnumerable, который возвращает объект-нумератор
        IEnumerator IEnumerable.GetEnumerator()
        {
            // возвращаем нумератор
            return GetEnumerator();
        }

        // печать коллекции
        public void Print()
        {
            // если размер коллекции равен 0
            if (Count == 0)
            {
                // выводим сообщение о том что коллекция пуста
                Console.WriteLine("Коллекция пуста");
                return;
            }
            
            var i = 0;
            // проходимся по всем элементам коллекции
            foreach (var item in this)
            {

                Console.WriteLine("==================");
                Type a = item.GetType();
                Console.WriteLine($"{a.Name}");
                Console.WriteLine($"[{i}] {item}");
                i++;
            }
        }

    }
}
