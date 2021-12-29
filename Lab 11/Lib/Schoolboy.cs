using System;

namespace Lib
{
    public class Schoolboy : Person, ICloneable
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
            SchoolName = "37 Школа";
            NumberClass = 1;
        }

        public Schoolboy(string name, string surname, int age, string sex, double avgRating, string schoolName, int Class)
            : base(name, surname, age, sex, avgRating)
        {
            SchoolName = schoolName;
            NumberClass = Class;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"School Name: {SchoolName}\nNubmer Class: {NumberClass}");
        }

        public Person BasePerson()
        {
            // возвращает объект базового класса
            return new Person(Name, Surname, Age, Sex, AVGRating);
        }

        public override string ToString() 
        {
            return Name + " " + Surname + " " + Age + " " + Sex + " " + AVGRating + " " + NumberClass + " " + SchoolName;
        }

        public object ShallowClone()
        {
            return this.MemberwiseClone();
        }

        public object Clone()
        {
            var t = new Schoolboy(this.Name, this.Surname, this.Age, this.Sex, this.AVGRating, this.SchoolName, this.NumberClass );
            return t;
        }


    }
}
