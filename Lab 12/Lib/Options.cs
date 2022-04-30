//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Lib
//{
//    public class Options
//    {
        
//        static void PrintMainMenu()
//        {
//            Console.WriteLine("1: Вывести всех мужчин");
//            Console.WriteLine("2: Вывести всех женщин");
//            Console.WriteLine("3: Вывести всех студентов выбранного курса");
//            Console.WriteLine("4: Вывести количество мужчин");
//            Console.WriteLine("5: Вывести количество женщин");
//            Console.WriteLine("6: Вывести данные о всех людях");
//            Console.WriteLine("7: Выйти");
//            Console.Write("Ваш выбор: ");
//        }

//        static void PrintSubMenu()
//        {
//            Console.WriteLine("1: Первый курс");
//            Console.WriteLine("2: Второй курс");
//            Console.WriteLine("3: Третий курс");
//            Console.WriteLine("4: Четвертый курс");
//            Console.WriteLine("5: Пятый курс");
//            Console.WriteLine("6: Шестой курс");
//            Console.WriteLine("7: Седьмой курс");
//            Console.Write("Ваш выбор: ");
//        }

//        static void PrintMenu(int SelectMenu)
//        {
//            switch (SelectMenu)
//            {
//                case 1: PrintMainMenu(); break;
//                case 2: PrintSubMenu(); break;
//                case 3: break;
//            }
//        }

//        static public int Input(int choice, int count, int SelectMenu)
//        {
//            bool ok = false;
//            string buf;
//            do
//            {
//                Console.WriteLine("\n");
//                PrintMenu(SelectMenu); // печать меню в консоль
//                buf = Console.ReadLine();
//                ok = Int32.TryParse(buf, out choice);

//                if (!ok || choice < 1 || choice > count)
//                {
//                    Console.WriteLine("\n\nНекорректный ввод\n\n");
//                }
//            } while (!ok || choice < 1 || choice > count);
//            return choice;
//        }


//        static void SubMenu()
//        {
//            Student testS = new Student("test");
//            int choice = 0; // переменная, отвечающая за выбор в главном меню
//            bool exit = false; // флаг отвечающий за выход из программы
//            while (!exit)
//            {
//                Console.Clear();
//                choice = Input(choice, 7, 2); // выбор действия в меню
//                testS.ShowAllWhereCourse(choice);
//                exit = true;
//            }
//        }

//        public void Menu()
//        {
//            int choice = 0; // переменная, отвечающая за выбор в главном меню
//            bool exit = false; // флаг отвечающий за выход из программы
//            while (!exit)
//            {
//                choice = Input(choice, 7, 1); // выбор действия в меню
                
                
//                switch (choice)
//                {
//                    case 1:  break;
//                    case 2:  break;
//                    case 3:  break;
//                    case 4:  break;
//                    case 5:  break;
//                    case 6:  break;
//                    case 7: Console.Clear(); exit = true; break;
//                }
//            }
//        }
//    }
//}
