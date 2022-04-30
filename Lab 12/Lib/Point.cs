using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{

    // класс элемента коллекции
    public class Point<T>
    {
        // значение нумератора
        public T Value;
        //указатель на следующий элемент
        public Point<T> Next { get; set; }
        //указатель на предыдущий элемент
        public Point<T> Previous { get; set; }


        
        public Point(T value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }
        public Point(T value, Point<T> next, Point<T> previous)
        {
            Next = next;
            Previous = previous;
        }

     }
}
