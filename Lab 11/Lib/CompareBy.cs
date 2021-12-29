using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class CompareByAVGRating : IComparer
    {
        public int Compare(object x, object y)
        {
            Person p1 = (Person)x;
            Person p2 = (Person)y;

            if (p1.AVGRating < p2.AVGRating)
                return -1;
            else if (p1.AVGRating > p2.AVGRating)
                return 1;
            else
                return 0;

        }
    }
    public class CompareByName : IComparer
    {
        public int Compare(object x, object y)
        {
            Person p1 = (Person)x;
            Person p2 = (Person)y;

            return String.Compare(p1.Name, p2.Name);

        }
    }
    public class CompareBySurname : IComparer
    {
        public int Compare(object x, object y)
        {
            Person p1 = (Person)x;
            Person p2 = (Person)y;
            return String.Compare(p1.Surname, p2.Surname);
        }
    }

    public class CompareByAge : IComparer
    {
        public int Compare(object x, object y)
        {
            Person p1 = (Person)x;
            Person p2 = (Person)y;

            if (p1.Age < p2.Age)
                return -1;
            else if (p1.Age > p2.Age)
                return 1;
            else
                return 0;
        }
    }

    // компаратор для бинарного поиска
    public class CompareByPerson : IComparer
    {
        public int Compare(object x, object y)
        {
            Person p1 = (Person)x;
            Person p2 = (Person)y;

            if (p1.Name == p2.Name && p1.Surname == p2.Surname && p1.Sex == p2.Sex && p1.AVGRating == p2.AVGRating)
                return 0;
            else
                return -1;
        }
    }
}
