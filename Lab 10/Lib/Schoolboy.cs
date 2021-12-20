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
            SchoolName = "37 Школа";
            NumberClass = 1;
        }

        public Schoolboy(string name, string surname, int age, string sex, double avgRating, string schoolName, int nubmerClass)
            : base(name, surname, age, sex, avgRating)
        {
            SchoolName = schoolName;
            NumberClass = numberClass;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"School Name: {SchoolName}\nNubmer Class: {NumberClass}");
        }


    }
}
