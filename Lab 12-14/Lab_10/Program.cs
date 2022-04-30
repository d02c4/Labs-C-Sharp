using System;

using Lib;

namespace Lab_10
{
    class Program
    {
        private static NewMyCollection<Person> collection = new NewMyCollection<Person>();

        // 1 меню
        static private void PrintMainMenu()
        {
            Console.WriteLine("Двунаправленный список\n" +
                "1) Добавить элемент\n" +
                "2) Удалить элемент\n" +
                "3) Поиск элемента\n" +
                "4) Очистить коллекцию\n" +
                "5) Распечатать элементы коллекции\n" +
                "6) Выйти из программы\n");
        }

        // 2 меню
        static private void PrintAddElemMenu()
        {
            Console.Write("Введите количество элементов для добавления: ");
        }

        // 3 меню
        static private void PrintSelectHowDelElem()
        {
            Console.Write("1) Удаление по индексу\n2) Удаление по значению\n3) Назад\nВаш выбор: ");
        }

        // 4 меню
        static private void PrintRemoveByIndex()
        {
            Console.Write("Введите индекс: ");
        }

        // 5 меню

        static private void PrintChoiceMethodSearch()
        {
            Console.Write("1) Поиск по значению\n2) Поиск по индексу\n3) Назад\nВаш выбор: ");
        }
        // 6 меню
        static private void PrintChoiceMethodSearchByValue()
        {
            Console.Write("1) Ввод вручную\n2) Схитрить\n3) Назад\nВаш выбор: ");
        }

        // 7 меню
        static private void PrintWriteIndex()
        {
            Console.Write("Введите индекс: ");
        }

        // 8 меню
        static private void PrintSelectByWhat()
        {
            Console.WriteLine("1) Поиск по имени\n2) Поиск по фамилии\n3) Поиск по Фамилии Имени\n4) Поиск всем параметрам\n5) Назад\nВаш выбор: ");
        }

        static void PrintMenu(int SelectMenu)
        {
            switch (SelectMenu)
            {
                case 1: PrintMainMenu(); break;
                case 2: PrintAddElemMenu(); break;
                case 3: PrintSelectHowDelElem(); break;
                case 4: PrintRemoveByIndex(); break;
                case 5: PrintChoiceMethodSearch(); break;
                case 6: PrintChoiceMethodSearchByValue(); break;
                case 7: PrintWriteIndex(); break;
                case 8: PrintSelectByWhat(); break;
                case 9: break;
            }
        }


        static public void AddElem()
        {
            int c = Input(0, 100000, 2);
            for (int i = 0; i < c; i++)
            {
                var tmp = RandomClass.GetRadomClass();
                collection.Add(tmp);
            }
            Console.Clear();
            Console.WriteLine($"Элементов добавлено в коллекцию: {c}\n");
            collection.Print();
        }

        static private void RemoveByIndex()
        {
            if (collection.Count == 0)
                Console.WriteLine("Коллекция пуста!");
            else
            {
                int index = Input(0, collection.Count - 1, 4);
                var element = collection[index];
                collection.Remove(element);
                Console.Clear();
                Console.WriteLine($"Элемент успешно удален из коллекции\n");
                collection.Print();
            }
        }

        static private void RemoveByValue()
        {
            if (collection.Count == 0)
                Console.WriteLine("Коллекция пуста!");
            else
            {
                var tmp = RandomClass.RequestInput();
                if (collection.Contains(tmp))
                {
                    collection.Remove(tmp);
                    Console.Clear();
                    Console.WriteLine("Элемент успешно удален!\n");
                }
                else
                    Console.WriteLine("Данного элемента в коллекции нет!");
            }
        }

        static private void SmileMethodSearch()
        {
            Console.WriteLine("Поиск происходить по значению, а не по индексу, не волнуемся\nВведите индекс требуемого элемента!");
            int choice = Input(0, collection.Count - 1, 0);

            var tmp = collection[choice].Clone();
            if (collection.Contains((Person)tmp))
            {
                Console.WriteLine("Элемент есть в коллекции :)\n\n");
            }
            else
            {
                Console.WriteLine("Данного элемента нет в коллекции :(\n\n");
            }
        }

        static private void SearchByFI()
        {
            Console.WriteLine("==================================");
            Console.WriteLine("Поиск элемента по фамилии и имени\n");
            string buf;
            Console.Write("Введите фамилию: ");
            buf = Console.ReadLine();
            Console.Write("Введите имя: ");
            buf += Console.ReadLine();;
            string FI ="";
            foreach(var x in collection)
            {
                FI = x.Surname + x.Name;
                if(FI == buf)
                {
                    x.Show();
                    
                }
            }
        }

        static private void SearchByName()
        {
            Console.WriteLine("==================================");
            Console.WriteLine("Поиск элемента по имени\n");
            string buf = "";
            Console.Write("Введите имя: ");
            buf += Console.ReadLine(); ;
            foreach (var x in collection)
            {
                if (x.Name == buf)
                {
                    x.Show();
                }
            }
        }


        static private void SearchBySurname()
        {
            Console.WriteLine("==================================");
            Console.WriteLine("Поиск элемента по фамилии\n");
            string buf = "";
            Console.Write("Введите Фамилию: ");
            buf += Console.ReadLine(); ;
            foreach (var x in collection)
            {
                if (x.Surname == buf)
                {
                    x.Show();
                }
            }
        }

        // поиск по какому значению
        static private void SearchByWhat()
        {
            int choice = 0; // переменная, отвечающая за выбор в главном меню
            bool exit = false; // флаг отвечающий за выход из программы
            while (!exit)
            {
                choice = Input(choice, 5, 8); // выбор действия в меню
                switch (choice)
                {
                    case 1: SearchByName(); break;
                    case 2: SearchBySurname(); break;
                    case 3: SearchByFI(); break;
                    case 4: SearchElement(); break;
                    case 5: Console.Clear(); exit = true; break;
                }
            }
        }

        static private void SelectSearchMethodByValue()
        {
            int choice = 0; // переменная, отвечающая за выбор в главном меню
            bool exit = false; // флаг отвечающий за выход из программы
            while (!exit)
            {
                choice = Input(choice, 3, 6); // выбор действия в меню
                switch (choice)
                {
                    case 1: SearchByWhat(); break;
                    case 2: SmileMethodSearch(); break;
                    case 3: Console.Clear(); exit = true; break;
                }
            }
        }

        static private void SearchMethodByIndex()
        {
            int choice = 0; // переменная, отвечающая за выбор в главном меню
            choice = Input(choice, collection.Count - 1, 7); // выбор действия в меню
            Console.Clear();
            Console.WriteLine($"Искомый элемент\n[{choice}]");
            collection[choice].Show();
        }

        static private void SelectSearchMethod()
        {
            if (collection.Count != 0)
            {
                int choice = 0; // переменная, отвечающая за выбор в главном меню
                bool exit = false; // флаг отвечающий за выход из программы
                while (!exit)
                {
                    choice = Input(choice, 3, 5); // выбор действия в меню
                    switch (choice)
                    {
                        case 1: SelectSearchMethodByValue(); break;
                        case 2: SearchMethodByIndex(); break;
                        case 3: Console.Clear(); exit = true; break;
                    }
                }
            }
            else
                Console.WriteLine("Коллекция пуста!");
        }

        static public void SelectHowDelElem()
        {
            if (collection.Count != 0)
            {
                int choice = 0; // переменная, отвечающая за выбор в главном меню
                bool exit = false; // флаг отвечающий за выход из программы
                while (!exit)
                {
                    choice = Input(choice, 3, 3); // выбор действия в меню

                    switch (choice)
                    {
                        case 1: RemoveByIndex(); break;
                        case 2: RemoveByValue(); break;
                        case 3: Console.Clear(); exit = true; break;
                    }
                }
            }
            else
                Console.WriteLine("Коллекция пуста!");
        }

        private static void SearchElement()
        {
            if (collection.Count == 0)
            {
                Console.WriteLine("Коллекция пуста!");
                return;
            }
            collection.Print();
            var data = RandomClass.RequestInput();
            Console.Clear();
            if (collection.Contains(data))
            {
                Console.WriteLine("Элемент есть в коллекции!\n\n");
            }
            else
            {
                Console.WriteLine("Данного элемента нет в коллекции!\n\n");
            }
        }

        static private void ClearCollection()
        {
            if (collection.Count != 0)
            {
                collection.Clear();
                Console.WriteLine("Коллекция была успешно очищена!");
                collection.Print();
            }
            else
                Console.WriteLine("Коллекция уже пуста!");
        }
        static public int Input(int choice, int count, int SelectMenu)
        {
            bool ok = false;
            string buf;
            do
            {
                Console.WriteLine("\n");
                PrintMenu(SelectMenu); // печать меню в консоль
                buf = Console.ReadLine();
                ok = Int32.TryParse(buf, out choice);

                if (!ok || choice < 0 || choice > count)
                {
                    Console.WriteLine("\n\nНекорректный ввод\n\n");
                }
            } while (!ok || choice < 0 || choice > count);
            return choice;
        }


        static public void Menu()
        {
            int choice = 0; // переменная, отвечающая за выбор в главном меню
            bool exit = false; // флаг отвечающий за выход из программы
            while (!exit)
            {
                choice = Input(choice, 6, 1); // выбор действия в меню
                switch (choice)
                {
                    case 1: AddElem(); break;
                    case 2: SelectHowDelElem(); break;
                    case 3: SelectSearchMethod(); break;
                    case 4: ClearCollection(); break;
                    case 5: collection.Print(); break;
                    case 6: Console.Clear(); exit = true; break;
                }
            }
        }
        static void Main(string[] args)
        {
            Menu();
        }
    }
}
