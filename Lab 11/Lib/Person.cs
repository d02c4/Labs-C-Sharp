using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;



namespace Lib
{
    public class Person : IExecutable, IComparable
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
            Name = "Иван";
            Surname = "Иванов";
            Age = 18;
            Random rnd = new Random();
            int rand = rnd.Next(0, 2);
            if (rand == 0)
                sex = "Man";
            else
                sex = "Woman";
            AVGRating = 2;
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
            Console.WriteLine($"Sex: {Sex}\nAVG Rating: {Math.Round(AVGRating, 4)}");
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
                return this.GetHashCode() == m.GetHashCode();
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
            return Name + " " + Surname + " " + Age + " " + Sex + " " + AVGRating;
        }

    }
}
