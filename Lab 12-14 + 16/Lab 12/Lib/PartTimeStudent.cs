using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class PartTimeStudent : Student
    {
        protected int numberTimesAtUniversity;
        public int NumberTimesAtUniversity
        {
            get => numberTimesAtUniversity;
            set
            {
                if (value < 0)
                    numberTimesAtUniversity = 0;
                else
                    numberTimesAtUniversity = value;
            }
        }
        public PartTimeStudent():base()
        {
            NumberTimesAtUniversity = 2;
        }
        public PartTimeStudent(string name, string surname, int age, string sex, double avgRating, string nameUniver, string groupName, int course, int numberExam, string formStudy, int numberTimesAtUniversity)
            : base(name, surname, age, sex, avgRating, nameUniver, groupName, course, numberExam, formStudy)
        {
            NumberTimesAtUniversity = numberTimesAtUniversity;
        }


        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Количество раз в университетете: {NumberTimesAtUniversity}\n");
        }
    }
}
