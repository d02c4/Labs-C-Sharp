using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_13
{
    public class JournalEntry
    {
        // название коллекции
        public string NameCollection { get; set; }
        // тип изменения в коллекции
        public string TypeChange { get; set; }
        // объект коллекции
        public object Object { get; set; }
        // новый объект коллекции
        public object NewObject { get; set; }

        // перегрузка метода ToString
        public override string ToString()
        {
            if (NewObject == null)
                return $"\nКоллекция: {NameCollection} \n({TypeChange}):\n{Object})";
            else
                return $"\nКоллекция: {NameCollection}\n({TypeChange}):\n{Object}\n\nОбъект заменён на:\n{NewObject}";
           
        }

        // конструктор для добавления объекта коллеции
        public JournalEntry(string name, string type, object obj)
        {
            NameCollection = name;
            TypeChange = type;
            Object = obj;
        }
        // конструктор для изменения элемента коллекции
        public JournalEntry(string name, string type, object obj, object newObject) : this(name, type, obj)
        {
            NewObject = newObject;
        }


    }
}
