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

            var countMens = (collection.Where(p => p is Person person && person.CheckMens(person) == true).Select(p => p)).Count();

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

        public static IEnumerable<IGrouping<int, T>> GroupByAge<T>(this NewMyCollection<T> collection) where T : Person
        {
            var GroupByAVGLINQ = collection.OrderBy(p => p.Age).GroupBy(p => p.Age);
            
            return GroupByAVGLINQ;
        }
    }

    internal class Program
    {
        
        private static Stack<Dictionary<int,Person>> city = new Stack<Dictionary<int, Person>>();

        static void Main(string[] args)
        {          
            

            for (int i = 0; i < 3; i++)
            {
                var institution = new Dictionary<int, Person>();
                for (int j = 0; j < 10; j++)
                {
                    var first = RandomClass.GetRadomClass();
                    institution.Add(j, first);
                }
                city.Push(institution);
            }

            int t = 1;
            foreach (var x in city)
            {
                Console.WriteLine($"\n\n====================\nУчебное заведение {t}:");
                t++;
                foreach (var y in x)
                {
                    y.Value.Show();
                }
            }


            Console.ForegroundColor = ConsoleColor.Gray;


            Query1();
            Query2();
            Query3();
            Query4();
            Query5();

            Task2();


            Console.ReadKey();
        }

        static public void Task2()
        {
            Console.WriteLine("Задание 2\n\nРасширяющие методы для своей коллекции");
            Console.Clear();
            NewMyCollection<Person> people = new NewMyCollection<Person>(10);
            people.Print();
            PrintMethod(true);
            Console.WriteLine("Поиск женщин\n");
            NewMyCollection<Person> people1 = people.SelectAllWomen();
            people1.Print();
            Console.ReadKey();
            Console.Clear();

            PrintMethod(false);
            Console.WriteLine("Количество женщин\n");
            Console.WriteLine($"Количество: {people.CountWomen()}\n");
            people1.Print();
            Console.ReadKey();
            Console.Clear();

            PrintMethod(true);
            Console.WriteLine("Максимальный возраст\n");
            Console.WriteLine($"Max: {people.MaxAge()}\n");
            people.Print();
            Console.ReadKey();
            Console.Clear();

            PrintMethod(false);
            Console.WriteLine("Средняя оценка у студентов\n");
            Console.WriteLine($"AVG: {people.AVGRatingStudent()}\n");
            Console.ReadKey();
            Console.Clear();

            PrintMethod(true);
            Console.WriteLine("Сортировка коллекции по имени\n");
            NewMyCollection<Person> people2 = people.OrderByName();
            people2.Print();
            Console.ReadKey();
            Console.Clear();

            PrintMethod(true);
            Console.WriteLine("Группировка данных по возрасту\n");
            var people3 = people.GroupByAge();
            foreach(var x in people3)
            {
                Console.WriteLine("\nВозраст: " + x.Key);
                foreach(var y in x)
                {
                    y.Show();
                }
            }
            Console.ReadKey();
            Console.Clear();

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
            var CourseLINQ = from inst in city
                             from pers in inst
                             where pers.Value is Student student && student.Course == course
                             select pers.Value.Name;

            if (CourseLINQ.Count() != 0)
            {
                foreach (var s in CourseLINQ)
                    Console.WriteLine($"Имя: {s}");
                Console.WriteLine($"Количество: {CourseLINQ.Count()}");
            }
            else
                Console.WriteLine("Студенты заданного курса отсутствуют!");


            PrintMethod(false);

            var CourseExpention = city.SelectMany(inst => inst.Where(p => p.Value is Student student && student.Course == course).Select(p => ((Student)p.Value).Name));

            if (CourseExpention.Count() != 0)
            {
                foreach (var s in CourseExpention)
                    Console.WriteLine($"Имя: {s}");
                Console.WriteLine($"Количество: {CourseExpention.Count()}");
            }
            else
                Console.WriteLine("Студенты заданного курса отсутствуют!");

            Console.ReadKey();
            Console.Clear();

            Console.ResetColor();
        }



        static void Query2()
        {
            Console.WriteLine("\n============================================\n" +
                                "3 - 4 запрос\n" +
                                "Имена всех лиц мужского пола и их количество\n");

            PrintMethod(true);
            var NameMenLINQ = from inst in city
                              from p in inst
                              where p.Value.CheckMens(p.Value) == true
                              select p.Value;

            var CountManLINQ = (from inst in city
                               from p in inst
                               where p.Value.CheckMens(p.Value) == true
                               select p).Count();

            foreach (var man in NameMenLINQ)
                man.Show();
            Console.WriteLine($"\nИтого {CountManLINQ} элементов");


            PrintMethod(false);

            var NameMenExpention = city.SelectMany(inst => inst.Where(p => p.Value.CheckMens(p.Value)).Select(p => p.Value));
            var CountMenExpention = city.SelectMany(inst => inst.Where(p => p.Value.CheckMens(p.Value)).Select(p => p)).Count();
            foreach (var man in NameMenExpention)
                man.Show();
            Console.WriteLine($"\nИтого {CountMenExpention} элементов");

            Console.ReadKey();
            Console.Clear();
            Console.ResetColor();
        }


        static void Query3()
        {
            Console.WriteLine("\n============================================\n" +
                                "5 запрос\n" +
                                "Количество студентов отличников\n");

            PrintMethod(true);
            var CountStud5LINQ = (from inst in city
                                from p in inst
                                where p.Value is Student student && student.AVGRating == 5.0
                                select p).Count();

            Console.WriteLine($"\n\nКоличество студентов отличников: {CountStud5LINQ}");


            PrintMethod(false);

            var CountStud5Expantion = city.SelectMany(inst => inst.Where(p => p.Value is Student student && student.AVGRating == 5.0)).Count();
            

            Console.WriteLine($"\n\nКоличество студентов отличников: {CountStud5Expantion}");


            Console.ReadKey();
            Console.Clear();
            Console.ResetColor();
        }


        static void Query4()
        {
            Console.WriteLine("\n============================================\n" +
                                "6 запрос\n" +
                                "Вывести средний балл всех студентов\n");

            PrintMethod(true);
            var CountStud5LINQ = (from inst in city
                                  from p in inst
                                  where p.Value is Student
                                  select p.Value.AVGRating).Average();

            Console.WriteLine($"\nСредний балл всех студентов: {CountStud5LINQ}");


            PrintMethod(false);

            var CountStud5Expantion = city.SelectMany(inst => inst.Where(p => p.Value is Student student).Select(p => p.Value.AVGRating)).Average();

            Console.WriteLine($"\nСредний балл всех студентов: {CountStud5Expantion}");


            Console.ReadKey();
            Console.Clear();
            Console.ResetColor();
        }


        static void Query5()
        {
            Console.WriteLine("\n============================================\n" +
                                "7 запрос\n" +
                                "Сруппировать всех людей по среднему баллу\n");

            PrintMethod(true);
            var GroupByAVGLINQ = (from inst in city
                                  from p in inst
                                  group p.Value by p.Value.AVGRating);

            foreach (IGrouping<double, Person> x in GroupByAVGLINQ)
            {
                Console.WriteLine($"\n===================\nСредний рейтинг : {x.Key} \n");
                foreach (var y in x)
                {
                    y.Show();
                }
            }
            PrintMethod(false);

            var GroupByAVGLINQExpantion = (city.SelectMany(inst => inst.Select(p => p.Value))).GroupBy(p => p.AVGRating);

            foreach (IGrouping<double, Person> x in GroupByAVGLINQExpantion)
            {
                Console.WriteLine($"\n===================\nСредний рейтинг : {x.Key} \n");
                foreach (var y in x)
                {
                    y.Show();
                }
            }


            Console.ReadKey();
            Console.Clear();
            Console.ResetColor();
        }

    }
}
