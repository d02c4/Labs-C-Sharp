using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class Options
    {
        static void PrintMainMenu()
        {
            Console.WriteLine("1: Создать колекции");
            Console.WriteLine("2: Отобразить элементы колекций");
            Console.WriteLine("3: Добавить элемент в колекции");
            Console.WriteLine("4: Удалить элемент из колекций");
            Console.WriteLine("5: Поиск элемента в списке");
            Console.WriteLine("6: Поиск элемента в словаре");
            Console.WriteLine("7: Выйти");
            Console.Write("Ваш выбор: ");
        }

        static void PrintSubMenu1()
        {
            Console.Write("Размер: ");
        }

        static void PrintSubMenu4()
        {
            Console.WriteLine("1: Удаление из коллекции по ключу");
            Console.WriteLine("2: Удаление из коллекции по значению");
            Console.WriteLine("3: Назад");
            Console.Write("Ваш выбор: ");
        }

        static void PrintSubMenu5()
        {
            Console.Write("Возраст: ");
        }
        static void PrintSubMenu6()
        {
            Console.Write("Номер класса: ");
        }

        static void PrintSubMenu7()
        {
            Console.WriteLine("1: Выполнение поиска в коллекциях по ключу");
            Console.WriteLine("2: Выполнение поиска в коллекциях по значению");
            Console.WriteLine("3: Назад");
            Console.Write("Ваш выбор: ");
        }

        static void PrintSubMenu8()
        {
            Console.WriteLine("1: Выполнение поиска в коллекциях первого элемента");
            Console.WriteLine("2: Выполнение поиска в коллекциях последнего элемента");
            Console.WriteLine("3: Выполнение поиска в коллекциях среднего элемента");
            Console.WriteLine("4: Выполнение поиска в коллекциях несуществующего элемента");
            Console.WriteLine("5: Назад");
            Console.Write("Ваш выбор: ");
        }

        static void PrintMenu(int SelectMenu)
        {
            switch (SelectMenu)
            {
                case 1: PrintMainMenu(); break;
                case 2: PrintSubMenu1(); break;
                case 3: PrintSubMenu4(); break;
                case 4: PrintSubMenu5(); break;
                case 5: PrintSubMenu6(); break;
                case 6: PrintSubMenu7(); break;
                case 7: PrintSubMenu8(); break;
                case 8: break;
            }
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

                if (!ok || choice < 1 || choice > count)
                {
                    Console.WriteLine("\n\nНекорректный ввод\n\n");
                }
            } while (!ok || choice < 1 || choice > count);
            return choice;
        }

        // подменю для печати коллекций
        static void SubMenu2(TestCollections testCollections)
        {
            if (testCollections != null)
                testCollections.Show();
            else
                Console.WriteLine("\nКоллекция не инициализирована");
        }


        // подменю для добавления элемента в колекцию
        static void SubMenu3(ref TestCollections testCollections)
        {
            if (testCollections == null)
            {
                testCollections = new TestCollections(1);
                testCollections.Show();
            }
            else
                testCollections.Add();
        }

        // подменю для ввода средней оценки
        static double SubMenu6()
        {
            double choice = 0;
            bool ok = false;
            string buf;
            do
            {
                Console.Write("Средняя оценка: ");
                buf = Console.ReadLine();
                ok = Double.TryParse(buf, out choice);

                if (!ok || choice < 2 || choice > 20)
                {
                    Console.WriteLine("\n\nНекорректный ввод\n\n");
                }
            } while (!ok || choice < 2 || choice > 20);
            return choice;
        }

        // метод для создание объекта школьник из консоли
        static Schoolboy InputSchoolboy()
        {
            Schoolboy schoolboy = new Schoolboy();

            Console.WriteLine("Данные удаляемого школьника");
            Console.Write("Имя:");
            schoolboy.Name = Console.ReadLine();
            Console.Write("Фамилия: ");
            schoolboy.Surname = Console.ReadLine();
            Console.Write("Пол: ");
            schoolboy.Sex = Console.ReadLine();
            schoolboy.Age = Input(0, 20, 4);
            schoolboy.AVGRating = SubMenu6();
            Console.Write("Название школы: ");
            schoolboy.SchoolName = Console.ReadLine();
            schoolboy.NumberClass = Input(0, 11, 5);
            return schoolboy;
        }

        // подменю для удаления элемента из коллекции
        static void SubMenu4(ref TestCollections testCollections)
        {
            int choice = 0; // переменная, отвечающая за выбор в главном меню
            bool exit = false; // флаг отвечающий за выход из программы
            while (!exit)
            {
                Console.Clear();
                choice = Input(choice, 3, 3); // выбор действия в меню
                switch (choice)
                {
                    case 1: testCollections.Remove(InputSchoolboy(), 1, false); break;
                    case 2: testCollections.Remove(InputSchoolboy(), 2, false); break;
                    case 3: exit = true; break;
                }
            }                                
        }

        // подменю для инициализации колекции
        static void SubMenu1(ref TestCollections testCollections)
        {
            int choice = 0; // переменная, отвечающая за выбор в главном меню
            bool exit = false; // флаг отвечающий за выход из программы
            while (!exit)
            {
                Console.Clear();
                choice = Input(choice, 1100, 2); // выбор действия в меню
                exit = true;
            }
            testCollections = new TestCollections(choice);
        }

        // метод для остановки вывода, до нажатия клавиши
        static void Continue()
        {
            Console.WriteLine("Нажмите для продолжения...");
            Console.ReadKey();
        }

        // метод для выбора 
        static void SubMenu8(TestCollections testCollections, int choiceLast)
        {
            int tmp = 0;
            int choice = 0; // переменная, отвечающая за выбор в главном меню
            bool exit = false; // флаг отвечающий за выход из программы
            while (!exit)
            {
                Console.Clear();
                choice = Input(choice, 5, 7); // выбор действия в меню
                switch (choice)
                {
                    case 1: tmp = 0; testCollections.FindBy(tmp, choiceLast); Continue(); break;
                    case 2: tmp = 1; testCollections.FindBy(tmp, choiceLast); Continue(); break;
                    case 3: tmp = 2; testCollections.FindBy(tmp, choiceLast); Continue(); break;
                    case 4: tmp = 3; testCollections.FindBy(tmp, choiceLast); Continue(); break;
                    case 5: exit = true; break;
                }
            }
        }

        // подменю для выбора метода поиска
        static void SubMenu7(TestCollections testCollections)
        {
            int choice = 0; // переменная, отвечающая за выбор в главном меню
            bool exit = false; // флаг отвечающий за выход из программы
            while (!exit)
            {
                Console.Clear();
                choice = Input(choice, 3, 6); // выбор действия в меню
                switch (choice)
                {
                    case 1: SubMenu8(testCollections, 0); break;
                    case 2: SubMenu8(testCollections, 1); break;
                    case 3: exit = true; break;
                }
            }
        }

        public void Menu(ref TestCollections testCollections)
        {
            int choice = 0; // переменная, отвечающая за выбор в главном меню
            bool exit = false; // флаг отвечающий за выход из программы
            while (!exit)
            {
                choice = Input(choice, 7, 1); // выбор действия в меню
                Person testP = new Person("test");
                
                switch (choice)
                {
                    case 1: SubMenu1(ref testCollections); break;
                    case 2: SubMenu2(testCollections); break;
                    case 3: SubMenu3(ref testCollections); break;
                    case 4:
                        if(testCollections != null) 
                            SubMenu4(ref testCollections); 
                        else
                            Console.WriteLine("\nСначала инициализируйте коллекцию!");
                        break;
                    case 5:
                        if (testCollections != null)
                            SubMenu8(testCollections, 2);
                        else
                            Console.WriteLine("\nСначала инициализируйте коллекцию!");
                        break;
                    case 6:
                        if (testCollections != null)
                            SubMenu7(testCollections);
                        else
                            Console.WriteLine("\nСначала инициализируйте коллекцию!");
                        break;
                    case 7: Console.Clear(); exit = true; break;
                }
            }
        }
    }
}
