using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_13
{
    // создаем делегат
    public delegate void CollectionHandler(object sourse, CollectionHandlerEventArgs args);
    public class CollectionHandlerEventArgs : EventArgs
    {
        // название коллекции
        public string NameCollection { get; set; }
        // тип изменения
        public string TypeChange { get; set; }
        // объект изменения
        public object Object { get; set; }
        // новый объект на который заменяют
        public object NewObject { get; set; }

        // конструктор аргументов для ивента добавления или удаленя элемента из коллекции
        public CollectionHandlerEventArgs(string name, string type, object obj)
        {
            NameCollection = name;
            TypeChange = type;
            Object = obj;
        }


        // конструктор аргументов для ивента изменения элемента в коллекции
        public CollectionHandlerEventArgs(string name, string type, object obj, object newObject) : this(name, type, obj)
        {
            NewObject = newObject;
        }

        public override string ToString()
        {
            return $"Name Collection:\t{NameCollection}\n" +
                $"Type Change:\t{TypeChange}\n" +
                $"Object:\t{Object}\n" +
                $"New Object:\t{NewObject}";
        }

    }



}
