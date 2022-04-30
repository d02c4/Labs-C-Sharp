using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Lib;


namespace Lab_14
{

    public static class NewMyCollectionExtension
    {
        // расширяющий метод который возвращает коллекцию, состоящую только из мужчин
        public static NewMyCollection<T> SelectAllMen<T>(this NewMyCollection<T> collection) where T : ICloneable, IComparable
        {
            // получаем список мужчин
            var selectMenList = (from p in collection
                                 where p is Person person
                                 && person.CheckMens(person) == true
                                 select p).ToList();
            return new NewMyCollection<T>(selectMenList);
        }


        // расширяющий метод который возвращиет коллекцию, состоящую только из женщин
        public static NewMyCollection<T> SelectAllWomen<T>(this NewMyCollection<T> collection) where T : ICloneable, IComparable
        {
            // получаем список женщин
            var selectWomenList = (from p in collection
                                   where p is Person person
                                   && person.CheckWomens(person) == true
                                   select p).ToList();
            return new NewMyCollection<T>(selectWomenList);
        }

        // расширяющий метод, который возвращает количество мужчин в коллекции
        public static int CountMen<T>(this NewMyCollection<T> collection) where T : ICloneable, IComparable
        {
            var countMen = (from p in collection
                            where p is Person person
                            && person.CheckMens(person) == true
                            select p).Count();
            return countMen;
        }

        // расширяющий метод, который возвращает количество женщин в коллекции
        public static int CountWomen<T>(this NewMyCollection<T> collection) where T : ICloneable, IComparable
        {
            var countWomen = (from p in collection
                              where p is Person person
                              && person.CheckWomens(person) == true
                              select p).Count();
            return countWomen;
        }

        // количество объектов в коллекции класса Person
        public static int CountPerson<T>(this NewMyCollection<T> collection) where T : ICloneable, IComparable
        {
            var countPerson = (from person in collection
                               where person is Person
                               select person).Count();
            return countPerson;
        }

        // количество объектов в коллекции класса Schoolboy
        public static int CountSchoolBoy<T>(this NewMyCollection<T> collection) where T : ICloneable, IComparable
        {
            var schoolBoyCount = (from schoolBoy in collection
                                  where schoolBoy is Schoolboy
                                  select schoolBoy).Count();
            return schoolBoyCount;
        }

        // количество объектов в коллекции класса Student
        public static int CountStudent<T>(this NewMyCollection<T> collection) where T : Person
        {
            var studentCount = (from stud in collection
                                where stud is Student
                                select stud.AVGRating).Count();
            return studentCount;
        }

        // Средняя оценка всех студентов в коллекции
        public static double AVGRatingStudent<T>(this NewMyCollection<T> collection) where T : Person
        {
            var avgRating = (from student in collection
                             where student is Student
                             select student.AVGRating).Average();
            return avgRating;
        }

        // максимальный возраст всех объектов
        public static int MaxAge<T>(this NewMyCollection<T> collection) where T : Person
        {
            int maxAge = (from person in collection
                          select person.Age).Max();
            return maxAge;
        }


        public static NewMyCollection<T> OrderByName<T>(this NewMyCollection<T> collection) where T : Person
        {
            var orderList = (from p in collection
                             orderby p.Name
                             select p).ToList();

            return new NewMyCollection<T>(orderList);
        }

    }

    internal class Program
    {

        private static List<List<Person>> list = new List<List<Person>>();

        static void Main(string[] args)
        {
            var city = new List<Person>();
            var institution = new List<Person>();

            for(int i = 0; i < 10; i++)
            {
                var first = RandomClass.GetRadomClass();
                
                var second = RandomClass.GetRadomClass();
                
                city.Add(first);
                institution.Add(second);
                
            }
            list.Add(city);
            list.Add(institution);

            Console.WriteLine("Город:");
            foreach (var x in city)
                x.Show();

            Console.WriteLine("\nУчебное заведение");
            foreach (var x in institution)
                x.Show();
            Console.ForegroundColor = ConsoleColor.Gray;


            Query1();
            Query2();
            Query3();
            Query4();
            Task2();


            Console.ReadKey();
        }

        static public void Task2()
        {
            Console.Clear();
            NewMyCollection<Person> people = new NewMyCollection<Person>(10);
            people.Print();
            NewMyCollection<Person> people1 = people.SelectAllMen();
            people1.Print();
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
                    Console.WriteLine($"\n\nНекорректный ввод значение должно быть в диапазоне от {choice} - {count}\n\n");
                }
            } while (!ok || choice < 0 || choice > count);
            return choice;
        }

        // меню 1
        static void PrintQuery1()
        {
            Console.Write("Введите номер курса студента: ");
        }

        // меню 2
        static void PrintQuery2()
        {
            Console.Write("Возраст: ");
        }

        static void PrintMenu(int SelectMenu)
        {
            switch (SelectMenu)
            {
                case 1: PrintQuery1(); break;
                case 2: PrintQuery2(); break;
                case 3: break;
                default:
                    Console.WriteLine(); break;
            }
        }

        private static void PrintMethod(bool f)
        {
            if (f)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"\n\nLINQ запрос:\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"\n\nМетод расширения:\n");
            }
        }

        private static void Query1()
        {
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("\n============================================\n" +
                "1 - 2 запрос\n" +
                "Имена студентов указанного курса и их количество\n");


            int course = Input(0, 8, 1);

            PrintMethod(true);
            var CourseLINQ = from stud in list
                             from pers in stud
                             where pers is Student student && student.Course == course
                             select pers.Name;

            foreach (var s in CourseLINQ)
                Console.WriteLine($"Имя: {s}");


            PrintMethod(false);

            var CourseExpention = list.SelectMany(l => l.Where(p => p is Student student && student.Course == course).Select(p => ((Student)p).Name));

            foreach (var s in CourseExpention)
                Console.WriteLine($"Имя: {s}");

            Console.ResetColor();
        }



        static void Query2()
        {
            Console.WriteLine("\n============================================\n" +
                                "3 - 4 запрос\n" +
                                "Имена всех лиц мужского пола и их количество\n");

            PrintMethod(true);
            var NameMenLINQ = from l in list
                              from p in l
                              where p.CheckMens(p) == true
                              select p;

            var CountManLINQ = (from l in list
                               from p in l
                               where p.CheckMens(p) == true
                               select p).Count();

            foreach (var man in NameMenLINQ)
                man.Show();
            Console.WriteLine($"\nИтого {CountManLINQ} элементов");


            PrintMethod(false);

            var NameMenExpention = list.SelectMany(l => l.Where(p => p.CheckMens(p)).Select(p => p));
            var CountMenExpention = list.SelectMany(l => l.Where(p => p.CheckMens(p)).Select(p => p)).Count();
            foreach (var man in NameMenExpention)
                man.Show();
            Console.WriteLine($"\nИтого {CountMenExpention} элементов");
            Console.ResetColor();
        }


        static void Query3()
        {
            Console.WriteLine("\n============================================\n" +
                                "5 запрос\n" +
                                "Количество студентов которые сдали все экзамены\n");

            PrintMethod(true);
            var CountStud5LINQ = (from l in list
                                from p in l
                                where p is Student student && student.AVGRating == 5.0
                                select p).Count();

            Console.WriteLine($"\n\nКоличество студентов отличников: {CountStud5LINQ}");


            PrintMethod(false);

            var CountStud5Expantion = list.SelectMany(l => l.Where(p => p is Student student && student.AVGRating == 5.0)).Count();

            Console.WriteLine($"\n\nКоличество студентов отличников: {CountStud5Expantion}");

            Console.ResetColor();
        }


        static void Query4()
        {
            Console.WriteLine("\n============================================\n" +
                                "6 запрос\n" +
                                "Вывести средний балл всех студентов\n");

            PrintMethod(true);
            var CountStud5LINQ = (from l in list
                                  from p in l
                                  where p is Student
                                  select p.AVGRating).Average();

            Console.WriteLine($"\nСредний балл всех студентов: {CountStud5LINQ}");


            PrintMethod(false);

            var CountStud5Expantion = list.SelectMany(l => l.Where(p => p is Student student).Select(p => p.AVGRating)).Average();

            Console.WriteLine($"\nСредний балл всех студентов: {CountStud5Expantion}");

            Console.ResetColor();
        }
    }
}
