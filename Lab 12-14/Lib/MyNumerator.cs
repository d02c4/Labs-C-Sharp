using System;
using System.Collections;
using System.Collections.Generic;


namespace Lib
{
    
    public class MyEnumerator<T> : IEnumerator<T> where T : ICloneable, IComparable
    {
        // начало коллекции
        Point<T> begin { get; set; } = null;
        // текущий просматриваемый элемент коллекции
        Point<T> current { get; set; } = null;
        // флаг первого захода в коллекцию
        bool initial = false;

        // свойство, которое реализует интерфейс IEnumerator<T>
        public T Current 
        { 
            get
            {
                return current.Value;
            }
        }

        // свойство, которое реализует интерфейс IEnumerator
        object IEnumerator.Current
        {
            get
            {
                return current;
            }
        }

        public MyEnumerator(NewMyCollection<T> collection)
        {
            begin = collection.Begin;
        }

        // метод для удаления ресурсов нумератора, реализует интерфейс IEnumerator<T>
        public void Dispose()
        {
            begin = null;
            current = null;
        }


        // метод для перехода к следующему элементу списка, реализует интерфейс IEnumerator 
        public bool MoveNext()
        {
            // первое вхождение в коллекцию
            if (initial == false)
            {
                initial = true;
                current = begin;
                return true;
            }
            //если текущий элемент или следующий элемент отсутсвует
            if (current == null || current.Next == null)
            {
                Reset();
                return false;
            }
            // если текущий или следующий элемент существуют, то переходим к следующему элементу
            else
            {
                current = current.Next;
                return true;
            }
        }

        //метод, который ставит текущий элемент на начало коллекции, реализует интерфейс IEnumerator 
        public void Reset()
        {
            initial = false;
        }

    }


}
