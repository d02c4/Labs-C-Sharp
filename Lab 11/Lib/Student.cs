using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class Student : Person, ICloneable
    {
        protected int numberExam;
        protected string nameUniver;
        protected string formStudy;
        protected string groupName;
        protected int course;

        static protected Student[] AllStudents = new Student[0];


        public string GroupName { get => groupName; set => groupName = value; }

        // свойства для количества экзаменов
        public int NumberExam
        { 
            get => numberExam;
            set
            {
                if (value < 0)
                    numberExam = 0;
                else if (value > 20)
                    numberExam = 20;
                else
                    numberExam = value;
            }
        }

        public int Course
        {
            get => course;
            set
            {
                if (value < 1)
                    course = 1;
                else if (value > 7)
                    course = 7;
                else
                    course = value;
            }
        }
        public string NameUniver
        {
            get => nameUniver;
            set => nameUniver = value;
        }

        public string FormStudy
        {
            get => formStudy;
            set => formStudy = value;
        }

        public Person Mom 
        {
            get;
            set; 
        }



        public Student[] AddStudents(Student[] allStudents, Person other)
        {
            Student[] tmp = new Student[allStudents.Length + 1];
            for (int i = 0; i < allStudents.Length; i++)
            {
                tmp[i] = allStudents[i];
            }
            tmp[tmp.Length - 1] = this;
            return tmp;
        }



        public Student(string test): base(test){}


        public Student()
            : base()
        {
            NameUniver = "PNRPU";
            GroupName = "IVT-20-2b";
            Course = 1;
            FormStudy = "Budget";
            NumberExam = 3;
            AllStudents = AddStudents(AllStudents, this);
        }

        public Student(string name, string surname, int age, string sex, double avgRating, string nameUniver, string groupName, int course, int numberExam, string formStudy)
            : base(name, surname, age, sex, avgRating)
        {
            NameUniver = nameUniver;
            GroupName = groupName;
            Course = course;
            FormStudy = formStudy;
            NumberExam = numberExam;
            AllStudents = AddStudents(AllStudents, this);
        }

        public override int Age
        { 
            get => age;
            set
            {
                if (value < 16)
                    age = 16;
                else if (value > 40)
                    age = 40;
                else
                    age = value;
            }
        }

        public override void Show()
        {
            base.Show();
            if(this.Mom != null)
                Console.WriteLine($"Name University: {NameUniver}\nGroup name: {GroupName}\nCourse: {Course}\nForm Study: {FormStudy}\nNumber exam: {NumberExam}\nMom: {Mom.Name}");
            else
                Console.WriteLine($"Name University: {NameUniver}\nGroup name: {GroupName}\nCourse: {Course}\nForm Study: {FormStudy}\nNumber exam: {NumberExam}\nMom: Нет мамы");
        }


        public void ShowAllWhereCourse(int course)
        {
            foreach(var x in AllStudents)
            {
                if (x.Course == course)
                    x.Show();
            }
        }

        public object ShallowClone()
        {
            return this.MemberwiseClone();
        }

        public object Clone()
        {
            var t = new Student(this.Name, this.Surname, this.Age, this.Sex, this.AVGRating, this.NameUniver, this.GroupName, this.Course, this.NumberExam, this.FormStudy);
            if (this.Mom != null)
            {
                t.Mom = new Person(this.Mom.Name, this.Mom.Surname, this.Mom.Age, this.Mom.Sex, this.Mom.AVGRating);
            }
            return t;
        }

    }
}
