using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class RandomClass
    {

        public static Random rnd = new Random((int)DateTime.Now.Ticks);

        public static Person GetRadomClass()
        {
            switch (rnd.Next(3))
            {
                case 0: return new Person();
                case 1: return new Schoolboy();
                case 2: return new Student();
            }
            return new Person();
        }
        public static bool CheckZeroFill(string str)
        {
            if (str != "")
                return false;
            else
                return true;
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
        // меню 1
        static void PrintMainMenu()
        {
            Console.WriteLine("Объект класса:\n1) Person\n2)Schoolboy\n3)Student");
        }

        // меню 2
        static void PrintPersonAge()
        {
            Console.Write("Возраст: ");
        }

        static void PrintMenu(int SelectMenu)
        {
            switch (SelectMenu)
            {
                case 1: PrintMainMenu(); break;
                case 2: PrintPersonAge(); break;
                case 3: break;
                default:
                    Console.WriteLine(); break;
            }
        }

        static public Person PersonInput()
        {
            Person person = new Person();
            string str = "";
            int integer = 0;
            Console.Write("Имя: ");
            while (CheckZeroFill(str))
                str = Console.ReadLine();
            person.Name = str;

            str = "";
            Console.Write("\nФамилия: ");
            while (CheckZeroFill(str))
                str = Console.ReadLine();
            person.Surname = str;


            integer = Input(0, 45, 2);
            person.Age = integer;

            str = "";
            Console.Write("\nПол: ");
            while (CheckZeroFill(str))
            {
                str = Console.ReadLine();
                person.Sex = str;
                if (person.CheckMens(person) || person.CheckWomens(person))
                    break;
            }
            
            double avg = 0;
            bool f = false;
            str = "";
            while(!f)
            {
                Console.Write("\nСредний рейтинг: ");
                str = Console.ReadLine();
                f = Double.TryParse(str, out avg);
                if(!f)
                    Console.WriteLine("Ошибка ввода!");
            }
            person.AVGRating = avg;
            return person;
        }

        public static Schoolboy SchoolBoyInput()
        {
            Schoolboy schoolboy = new Schoolboy();
            schoolboy = (Schoolboy)PersonInput();

            string str = "";
            Console.Write("\nВведите название школы: ");
            while(CheckZeroFill(str))
                str = Console.ReadLine();
            schoolboy.SchoolName = str;

            int integer = Input(1, 11, 0);
            Console.Write("\nНомер класса: ");
            schoolboy.NumberClass = integer;

            return schoolboy;
        }

        public static Student StudentInput()
        {
            Student student = new Student();
            string str = "";
            Console.Write("\nНазвание университета: ");
            while (CheckZeroFill(str))
                str = Console.ReadLine();
            student.NameUniver = str;

            str = "";
            Console.Write("\nНазвание группы: ");
            while (CheckZeroFill(str))
                str = Console.ReadLine();
            student.GroupName = str;

            str = "";
            Console.Write("\nФорма обучения: ");
            while (CheckZeroFill(str))
                str = Console.ReadLine();
            student.FormStudy = str;

            int integer = Input(1, 7, 0);
            Console.Write("\nНомер курса: ");
            student.Course = integer;

            integer = Input(1, 20, 0);
            Console.Write("\nКоличество экзаменов: ");
            student.Course = integer;
            return student;
        }

        public static Person RequestInput()
        {
            
            int choice = 0; // переменная, отвечающая за выбор в главном меню
            bool exit = false; // флаг отвечающий за выход из программы
            while (!exit)
            {
                choice = Input(choice, 3, 1); // выбор действия в меню
                switch (choice)
                {
                    case 1: return PersonInput();
                    case 2: return SchoolBoyInput();
                    case 3: return StudentInput();
                }
            }
            return null;
        }
    }
}
