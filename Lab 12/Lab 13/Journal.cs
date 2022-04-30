using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_13
{
    public class Journal
    {
        // имя коллекции
        public string Name { get; set; }
        // список изменений которые произошли в коллекции
        public List<JournalEntry> EntryList { get; private set; }
        // название журнала
        public Journal(string name)
        {
            Name = name;
            EntryList = new List<JournalEntry>();
        }
        //обработчик события добавления элемента в коллекцию
        public void OnCollectionCountChanged(object source, CollectionHandlerEventArgs args)
        {
            JournalEntry entry = new JournalEntry(args.NameCollection, args.TypeChange, args.Object, args.NewObject);
            EntryList.Add(entry);
        }
        //обработчик события изменнения элемента коллекции
        public void OnCollectionReferenceChanged(object source, CollectionHandlerEventArgs args)
        {
            JournalEntry entry = new JournalEntry(args.NameCollection, args.TypeChange, args.Object, args.NewObject);
            EntryList.Add(entry);
        }
        // метод печати событий сохраненных в журнале
        public void PrintData()
        {
            Console.WriteLine($"События, сохранённые в журнале \"{Name}\":\n");
            foreach (var entry in EntryList)
            {

                Console.WriteLine(entry);
                Console.WriteLine("===========================");
            }
        }
    }

}
