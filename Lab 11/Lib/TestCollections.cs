using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace Lib
{
    public class TestCollections
    {
        List<Person> list1;
        List<string> list2;
        Dictionary<Person, Schoolboy> dict1;
        Dictionary<string, Schoolboy> dict2;

        static Stopwatch timer = new Stopwatch();
        static Random rand = new Random();

        static string[] nameA = { "Александр", "Алексей", "Анатолий", "Андрей", "Антон", "Аркадий", "Арсений", "Артём", "Артур", "Борис", "Вадим", "Валентин", "Валерий", "Василий", "Виктор", "Виталий", "Владимир", "Владислав", "Вячеслав", "Георгий", "Глеб", "Григорий", "Даниил", "Денис", "Дмитрий", "Евгений", "Егор", "Иван", "Игорь", "Илья", "Кирилл", "Константин", "Лев", "Леонид", "Максим", "Марк", "Матвей", "Михаил", "Никита", "Николай", "Олег", "Павел", "Пётр", "Роман", "Руслан", "Сергей", "Степан", "Тимур", "Фёдор", "Юрий", "Ярослав" };
        static string[] surnameA = { "Пантелеев", "Чувашев", "Галинов", "Ананина", "Масылюк", "Вострокнутова", "Сабуров", "Исламов", "Шамай", "Филатов", "Сафронов", "Шарпов", "Карелов", "Брейкин", "Копытов", "Солдатов", "Кузнецов", "Пажгин", "Фотин", "Бадретдинов", "Механошин", "Булдаков", "Тулинов", "Тедеев", "Колпаков", "Черных", "Нефедов", "Рябцев", "Пепеляев", "Тарасов", "Аркадьев" };
        static string[] nameSchoolA = { "37 школа", "1 лицей", "2 лицей", "38 школа", "1 гимназия" };
        static string[] sexA = { "Man", "Woman" };

        private Schoolboy GenSchoolboy()
        {
            string name = nameA[rand.Next(0, nameA.Length)];
            string surname = surnameA[rand.Next(0, surnameA.Length)];
            int age = rand.Next(1, 21);
            int numberClass = rand.Next(1, 12);
            string schoolName = nameSchoolA[rand.Next(0, nameSchoolA.Length)];
            string sex = sexA[rand.Next(0, sexA.Length)];
            avg += 0.0025;
            return new Schoolboy(name, surname, age, sex, avg, schoolName, numberClass);
        }

        static double avg = 1.9975;

        int MaxSize = 1100;

        public void Add()
        {
            if (list1.Count <= MaxSize)
            {
                Schoolboy schoolboy = GenSchoolboy();
                list1.Add(schoolboy.BasePerson());
                list2.Add(schoolboy.BasePerson().ToString());
                dict1.Add(schoolboy.BasePerson(), schoolboy);
                dict2.Add(schoolboy.BasePerson().ToString(), schoolboy);
                schoolboy.Show();
                Console.WriteLine($"Успешно добавлен в коллекции!");
            }
            else
                Console.WriteLine("Коллекция превысила максимальный размер!!!\nЭлемент не был добавлен!");
        }

        public void Continue()
        {
            Console.WriteLine("Нажмите чтобы продолжить...");
            Console.ReadKey();
        }

        public void Remove(Schoolboy schoolboy, int key, bool test)
        {
            if (list1.Remove(schoolboy.BasePerson()))
            {
                Console.WriteLine($"Удален объект:");
                schoolboy.Show();
                if (!test)
                    Continue();
                list2.Remove(schoolboy.BasePerson().ToString());
                if (key == 1)
                {
                    dict1.Remove(schoolboy.BasePerson());
                    dict2.Remove(schoolboy.BasePerson().ToString());
                }
                else if (key == 2)
                {
                    dict1.Remove(schoolboy);
                    dict2.Remove(schoolboy.ToString());
                }
            }
            else
            {
                Console.WriteLine("Объект в каталоге не найден!");
                if (!test)
                    Continue();
            }
        }

        public TestCollections(int size)
        {
            avg = 1.9975;
            List<Schoolboy> tmp = new List<Schoolboy>(size);

            for (int i = 0; i < size; i++)
            {
                tmp.Add(GenSchoolboy());
            }

            list1 = new List<Person>(size);
            list2 = new List<string>(size);
            dict1 = new Dictionary<Person, Schoolboy>(size);
            dict2 = new Dictionary<string, Schoolboy>(size);
            foreach (var x in tmp)
            {
                list1.Add(x.BasePerson());
                list2.Add(x.BasePerson().ToString());
                dict1.Add(x.BasePerson(), x);
                dict2.Add(x.BasePerson().ToString(), x);
            }
        }

        public void Show()
        {
            if (dict1.Count != 0)
            {
                foreach (var x in dict1)
                {
                    Console.WriteLine(x.GetType() + "\n");
                    x.Value.Show();
                    Console.WriteLine("\n\n");
                }

                Console.WriteLine($"Количество элементов в коллекциях: {dict1.Count}");
            }
            else
                Console.WriteLine("Коллекции не инициализированы!!!!!!");

        }

        public void FindInList(Person person)
        {
            timer.Restart();
            bool res = list1.Contains(person);
            timer.Stop();
            Console.WriteLine("\nПоиск элемента Person в контейнере List<Person> с помощью Contains");
            if (res)
                Console.WriteLine($"Элемент найден!\nВремя нахождения элемента: {timer.ElapsedTicks} тика\n");
            else
                Console.WriteLine($"Элемент не найден!\nВремя работы метода: {timer.ElapsedTicks} тика\n");
        }

        public void FindInList(string str)
        {
            timer.Restart();
            bool res = list2.Contains(str);
            timer.Stop();
            Console.WriteLine("\nПоиск элемента string в контейнере List<string> с помощью Contains");
            if (res)
                Console.WriteLine($"Элемент найден!\nВремя нахождения элемента: {timer.ElapsedTicks} тика\n");
            else
                Console.WriteLine($"Элемент не найден!\nВремя работы метода: {timer.ElapsedTicks} тика\n");
        }

        public void FindInDictByKey(Person person)
        {
            timer.Restart();
            bool res = dict1.ContainsKey(person);
            timer.Stop();
            Console.WriteLine("\nПоиск элемента в контейнере Dictionary<Person, Schoolboy> по ключу с помощью ContainsKey");
            if (res)
                Console.WriteLine($"Элемент найден!\nВремя нахождения элемента: {timer.ElapsedTicks} тика\n");
            else
                Console.WriteLine($"Элемент не найден!\nВремя работы метода: {timer.ElapsedTicks} тика\n");
        }

        public void FindInDictByKey(string str)
        {
            timer.Restart();
            bool res = dict2.ContainsKey(str);
            timer.Stop();
            Console.WriteLine("\nПоиск элемента в контейнере Dictionary<string, Schoolboy> по ключу с помощью ContainsKey");
            if (res)
                Console.WriteLine($"Элемент найден!\nВремя нахождения элемента: {timer.ElapsedTicks} тика\n");
            else
                Console.WriteLine($"Элемент не найден!\nВремя работы метода: {timer.ElapsedTicks} тика\n");
        }

        public void FindInDictByValue1(Schoolboy schoolboy)
        {
            timer.Restart();
            bool res = dict1.ContainsValue(schoolboy);
            timer.Stop();
            Console.WriteLine("\nПоиск элемента в контейнере Dictionary<Person, Schoolboy> по значению с помощью ContainsValue");
            if (res)
                Console.WriteLine($"Элемент найден!\nВремя нахождения элемента: {timer.ElapsedTicks} тика\n");
            else
                Console.WriteLine($"Элемент не найден!\nВремя работы метода: {timer.ElapsedTicks} тика\n");
        }

        public void FindInDictByValue2(Schoolboy schoolboy)
        {
            timer.Restart();
            bool res = dict2.ContainsValue(schoolboy);
            timer.Stop();
            Console.WriteLine("\nПоиск элемента в контейнере Dictionary<string, Schoolboy> по значению с помощью ContainsValue");
            if (res)
                Console.WriteLine($"Элемент найден!\nВремя нахождения элемента: {timer.ElapsedTicks} тика\n");
            else
                Console.WriteLine($"Элемент не найден!\nВремя работы метода: {timer.ElapsedTicks} тика\n");
        }

        public void FindByWhat(Schoolboy schoolboy, int choiceMet)
        {
            if (choiceMet == 0)
            {
                FindInDictByKey(schoolboy.BasePerson());
                FindInDictByKey(schoolboy.BasePerson().ToString());
            }
            else if (choiceMet == 1)
            {
                FindInDictByValue1(schoolboy);
                FindInDictByValue2(schoolboy);
            }
            else
            {
                FindInList(schoolboy.BasePerson());
                FindInList(schoolboy.BasePerson().ToString());
            }
        }

        public void FindBy(int choiceVal, int choiceMet)
        {
            Schoolboy tmp = null;
            switch (choiceVal)
            {
                case 0: tmp = dict1.First().Value; Schoolboy first = (Schoolboy)tmp.Clone(); FindByWhat(first, choiceMet); break;
                case 1: tmp = dict1.Last().Value; Schoolboy last = (Schoolboy)tmp.Clone(); FindByWhat(last, choiceMet); break;
                case 2: tmp = dict1.ElementAt(dict1.Count / 2).Value; Schoolboy middle = (Schoolboy)tmp.Clone(); FindByWhat(middle, choiceMet); break;
                case 3: tmp = new Schoolboy("0", "0", 0, "0", 2, "0", 1); FindByWhat(tmp, choiceMet); break;
            }
        }

        public Person GetKeyByIndex(int ind)
        {
            if (ind < 0 || ind >= dict1.Count) 
                return null;
            return dict1.ElementAt(ind).Key;
        }

        public Schoolboy GetValueByIndex(int ind)
        {
            if (ind < 0 || ind >= dict1.Count) 
                return null;
            return dict1.ElementAt(ind).Value;
        }
    }
}
