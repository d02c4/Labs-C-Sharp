﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;



namespace Lib
{
    public class Person : IExecutable, IComparable, ICloneable
    {
        // Имя
        protected string name;
        // Фамилия
        protected string surname;
        // Возраст
        protected int age;
        // пол
        protected string sex;
        // Средняя оценка
        protected double avgRating;

        static protected int countMens = 0;
        static protected int countWomens = 0;
        static protected Person[] AllPersons = new Person[0];

        protected string[] nameA = { "Александр", "Алексей", "Анатолий", "Андрей", "Антон", "Аркадий", "Арсений", "Артём", "Артур", "Борис", "Вадим", "Валентин", "Валерий", "Василий", "Виктор", "Виталий", "Владимир", "Владислав", "Вячеслав", "Георгий", "Глеб", "Григорий", "Даниил", "Денис", "Дмитрий", "Евгений", "Егор", "Иван", "Игорь", "Илья", "Кирилл", "Константин", "Лев", "Леонид", "Максим", "Марк", "Матвей", "Михаил", "Никита", "Николай", "Олег", "Павел", "Пётр", "Роман", "Руслан", "Сергей", "Степан", "Тимур", "Фёдор", "Юрий", "Ярослав" };
        protected string[] surnameA = { "Пантелеев", "Чувашев", "Галинов", "Ананина", "Масылюк", "Вострокнутова", "Сабуров", "Исламов", "Шамай", "Филатов", "Сафронов", "Шарпов", "Карелов", "Брейкин", "Копытов", "Солдатов", "Кузнецов", "Пажгин", "Фотин", "Бадретдинов", "Механошин", "Булдаков", "Тулинов", "Тедеев", "Колпаков", "Черных", "Нефедов", "Рябцев", "Пепеляев", "Тарасов", "Аркадьев" };
        protected string[] nameSchoolA = { "37 школа", "1 лицей", "2 лицей", "38 школа", "1 гимназия" };
        protected string[] nameUniverA = { "ПНИПУ", "ПГНИУ", "ВятГУ", "КубГУ", "ПГУ", "МГУ", "МФТИ", "РАНХиГС" };
        protected string[] nameGroupA = { "ИВТ-20-2б", "ИВТ-20-1б", "РИС-20-1б", "РИС-20-2б", "АСУ-19", "АСУ-18", "КС-19", "КС-18" };
        protected string[] sexA = { "Man", "Woman" };

        public void NullAllPerson()
        {
            AllPersons = new Person[0];
        }

        // свойства для имени
        public string Name
        {
            get{ return name; }
            set { name = value; }
        }

        // свойства для фамилии
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        // Свойства счетчика мужчин
        public int CountMens
        {
            get => countMens;
            set
            {
                if (value < 0)
                    countMens = 0;
                else if (value > AllPersons.Length)
                    countMens = AllPersons.Length;
                else
                    countMens = value;
            }
        }
        
        // Свойства счетчика Женщин
        public int CountWomens
        {
            get => countWomens;
            set
            {
                if (value < 0)
                    countWomens = 0;
                else if (value > AllPersons.Length)
                    countWomens = AllPersons.Length;
                else
                    countWomens = value;
            }
        }

        // свойства для пола
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        // свойства для возраста
        virtual public int Age
        {
            get { return age; }
            set 
            {
                if (value < 0)
                    age = 0;
                else if (value > 120)
                    age = 120;
                else
                    age = value;
            }
        }
        //свойства для средней оценки
        public double AVGRating
        {
            get { return avgRating; }
            set
            {
                if (value < 2)
                    avgRating = 2;
                else if (value > 5)
                    AVGRating = 5;
                else
                    avgRating = value;
            }
        }

        public Person[] AddPersons(Person[] allPersons, Person other)
        {
            Person[] tmp = new Person[allPersons.Length + 1];
            for (int i = 0; i < allPersons.Length; i++)
            {
                tmp[i] = allPersons[i];
            }
            tmp[tmp.Length - 1] = other;
            return tmp;
        }

        public void ShowAllPersons()
        {
            foreach(var x in AllPersons)
            {
                x.Show();
            }
        }

        // конструктор по умолчанию
        public Person()
        {
            Random rnd = RandomClass.rnd;
            Name = nameA[rnd.Next(0, nameA.Length - 1)];
            Surname = surnameA[rnd.Next(0, surnameA.Length - 1)];
            Age = rnd.Next(0, 45);
            
            int rand = rnd.Next(0, 2);
            if (rand == 0)
                sex = "Man";
            else
                sex = "Woman";
            AVGRating = Math.Round(rnd.Next(2, 4) + rnd.NextDouble(), 1);
            if (CheckMens(this))
                CountMens++;
            else if (CheckWomens(this))
                CountWomens++;
            AllPersons = AddPersons(AllPersons, this);
        }

        public bool CheckMens(Person a)
        {
            if(a.Sex == "Man" || a.Sex == "M" || a.Sex == "man" || a.Sex == "Men" || a.Sex == "men")
            {
                return true;
            }
            return false;
        }

        public bool CheckWomens(Person a)
        {
            if (a.Sex == "Woman" || a.Sex == "W" || a.Sex == "woman" || a.Sex == "Women" || a.Sex == "women")
            {
                return true;
            }
            return false;
        }

        public void ShowMens()
        {
            int tmp = 0;
            foreach (var x in AllPersons)
            {
                if (x.CheckMens(x))
                {
                    tmp++;
                    x.Show();
                }
            }
            if (tmp == 0)
                ShowErrorMens();
        }

        public void ShowWomens()
        {
            int tmp = 0;
            foreach (var x in AllPersons)
            {
                if (x.CheckWomens(x))
                {
                    tmp++;
                    x.Show();
                }
            }
            if (tmp == 0)
                ShowErrorWomens();
        }

        // Конструктор с параметрами
        public Person(string name, string surname, int age, string sex, double avgRating)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Sex = sex;
            AVGRating = avgRating;

            if (CheckMens(this))
                CountMens++;
            else if (CheckWomens(this))
                CountWomens++;

            // добавление элемента в статическое поле
            AllPersons = AddPersons(AllPersons, this);
        }

        public Person(string test) { }

        // вывести элемент на экран
        virtual public void Show()
        {
            Person other = this;
            Type T = this.GetType();

            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
            Console.WriteLine($"Сlass object: {T.Name}");
            Console.Write($"Name: {Name}\nSurname: {Surname}\nAge: {Age}\n");
            Console.WriteLine($"Sex: {Sex}\nAVG Rating: {AVGRating}");
        }

        protected bool CheckNotZero(int var)
        {
            if (var != 0)
                return true;
            return false;
        }

        protected void ShowErrorMens()
        {
            Console.WriteLine("=========================");
            Console.WriteLine("Мужчины отсутствуют!");
            Console.WriteLine("=========================");
        }

        protected void ShowErrorWomens()
        {
            Console.WriteLine("=========================");
            Console.WriteLine("Женщины отсутствуют!");
            Console.WriteLine("=========================");
        }

        protected void ShowCountMens()
        {
            
            if (CheckNotZero(CountMens))
            {
                Console.WriteLine("=========================");
                Console.WriteLine($"Count mens: {CountMens}");
                Console.WriteLine("=========================");
            }
            else
                ShowErrorMens();
        }

        protected void ShowCountWomens()
        {
            if (CheckNotZero(CountWomens))
            {
                Console.WriteLine("=========================");
                Console.WriteLine($"Count mens: {CountWomens}");
                Console.WriteLine("=========================");
            }
            else
                ShowErrorWomens();
        }

        public void ShowCount(int choice)
        {
            if (choice == 0)
                ShowCountMens();
            else if (choice == 1)
                ShowCountWomens();
            else
                Console.WriteLine("Передан неверный параметр: 0-мужчины, 1-женщины");
        }
        public int CompareTo(object obj)
        {
            Person tmp = (Person)obj;
            if (this.Age > tmp.Age)
                return 1;
            if(this.Age < tmp.Age)
                return -1;
            return 0;
        }

        public override bool Equals(object obj)
        {
            if (obj is Person)
            {
                Person m = (Person)obj;
                return Name == m.Name 
                    && Surname == m.Surname
                    && Age == m.Age
                    && Sex == m.Sex
                    && AVGRating == m.AVGRating;
            }
            return false;
        }

        // переопределение метода для получения хэш кода объекта
        public override int GetHashCode()
        {
            string tmp = Name + Surname + Age + Sex + AVGRating;
            return tmp.GetHashCode();
        }

        public override string ToString()
        {
            return "Имя: " + Name + "\nФамилия: " + Surname + "\nВозраст: " + Age + "\nПол: " + Sex + "\nСредняя оценка: " + AVGRating;
        }

        public virtual object Clone()
        {
            var t = new Person(this.Name, this.Surname, this.Age, this.Sex, this.AVGRating);
            return t;
        }
        public object ShallowClone()
        {
            return this.MemberwiseClone();
        }




    }
}
