using System;

using Lib;

namespace Lab_10
{
    class Program
    {
        static void ShowArr(IExecutable[] executable)
        {
            foreach (var x in executable)
            {
                x.Show();
            }
        }

        static void Main(string[] args)
        {
            Options option = new Options();
            Schoolboy a = new Schoolboy();
            Schoolboy b = new Schoolboy();
            Student q = new Student();
            Student w = new Student();
            Person e = new Person();
            Person y = new Person();
            PartTimeStudent u = new PartTimeStudent();
            PartTimeStudent i = new PartTimeStudent();
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
            option.Menu();



            Console.WriteLine("\n\nЗадание 3\n\n");

            // создаение массива из элементов унаследовавших интерфейс
            IExecutable[] executable = new IExecutable[5];
            executable[0] = new Schoolboy();
            executable[1] = new Student();
            executable[2] = new Person();
            executable[3] = new Schoolboy("Aboba", "Aloha", 12, "M", 4.2, "Sharaga", 9);
            executable[4] = new Student("Jotaro", "Kujo", 20, "M", 3.5, "NoSharaga", "IVT-60-61", 2, 4, "Zaoch");
            ShowArr(executable);

            Console.WriteLine("\n\nОтсортированный с помощью интерфейса IComparable по возрасту массив\n\n");
            Array.Sort(executable);
            ShowArr(executable);

            Console.WriteLine("\n\nОтсортированный с помощью интерфейса ICompare по Фамилии\n\n");
            Array.Sort(executable, new CompareBySurname());
            ShowArr(executable);

            Console.WriteLine("\n\nОтсортированный с помощью интерфейса ICompare по Средней оценке\n\n");
            Array.Sort(executable, new CompareByAVGRating());
            ShowArr(executable);

            // бинарный поиск в отсортированном массиве
            Student student = new Student("Jotaro", "Kujo", 20, "M", 3.5, "NoSharaga", "IVT-60-61", 2, 4, "Zaoch");
            int ind = Array.BinarySearch(executable, student, new CompareByPerson());
            if (ind >= 0)
                Console.WriteLine($"\n\nЭлемент найден и находится в массиве под индексом: {ind}\n");
            else
                Console.WriteLine("\n\nЭлемент не найден!\n");

            Console.WriteLine("====================\nПоверхностное копирование");
            Student tmp = new Student();
            tmp.Mom = new Person();
            Student tmpShallowClone = (Student)tmp.ShallowClone();
            tmpShallowClone.Mom.Name = "Aboba";
            tmpShallowClone.Show();
            tmp.Show();
            Console.WriteLine("====================");

            Console.WriteLine("====================\nГлубокое копирование");
            Student tmp1 = new Student();
            tmp1.Mom = new Person();
            Student tmpClone = (Student)tmp1.Clone();
            tmpClone.Mom.Name = "Gojo";
            tmpClone.Show();
            tmp1.Show();
            Console.WriteLine("====================");
        }
    }
}
