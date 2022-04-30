using System;

namespace Lib
{
    public class Schoolboy : Person
    {
        protected string schoolName;
        protected int numberClass;

        public string SchoolName
        {
            get => schoolName;
            set => schoolName = value;
        }

        public int NumberClass
        { 
            get => numberClass;
            set
            {
                if (value < 1)
                    numberClass = 1;
                else if (value > 11)
                    numberClass = 11;
                else
                    numberClass = value;
            }
        }

        public override int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 6)
                    age = 6;
                else if (value > 20)
                    age = 20;
                else
                    age = value;
            }
        }

        public Schoolboy() : base() 
        {
            Random rnd = RandomClass.rnd;
            SchoolName = nameSchoolA[rnd.Next(0, nameSchoolA.Length - 1)];
            NumberClass = rnd.Next(0, 11);
        }

        public Schoolboy(string name, string surname, int age, string sex, double avgRating, string schoolName, int nubmerClass)
            : base(name, surname, age, sex, avgRating)
        {
            SchoolName = schoolName;
            this.numberClass = nubmerClass;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"\nSchool Name: {SchoolName}\nNubmer Class: {NumberClass}");
        }

        public override object Clone()
        {
            var t = new Schoolboy(this.name, this.surname, this.age, this.sex, this.avgRating, this.schoolName, this.NumberClass);
            return t;
        }

        public override string ToString()
        {
            string str = "Имя: " + Name + "\nФамилия: " + Surname + "\nВозраст: " + Age + "\nПол: " + Sex + "\nСредняя оценка: " + AVGRating + $"\nSchool Name: {SchoolName}\nNubmer Class: {NumberClass}";
            return str;
        }

        public override bool Equals(object obj)
        {
            if (obj is Schoolboy)
            {
                Schoolboy m = (Schoolboy)obj;
                return Name == m.Name
                    && Surname == m.Surname
                    && Age == m.Age
                    && Sex == m.Sex
                    && AVGRating == m.AVGRating
                    && schoolName == m.schoolName
                    && NumberClass == m.NumberClass;
            }
            return false;
        }

        // переопределение метода для получения хэш кода объекта
        public override int GetHashCode()
        {
            string tmp = Name + Surname + Age + Sex + AVGRating + SchoolName + NumberClass;
            return tmp.GetHashCode();
        }


    }
}
