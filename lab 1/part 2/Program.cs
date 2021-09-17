using System;

namespace part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string buf;
            bool ok;
            Console.WriteLine("Решение 2 задачи");

            double X, Y;
            do
            {
                Console.Write("X = ");
                buf = Console.ReadLine();
                ok = double.TryParse(buf, out X);
                if (!ok)
                {
                    Console.WriteLine("Введено не число!");
                }
            }
            while (!ok);

            do
            {
                Console.Write("Y = ");
                buf = Console.ReadLine();
                ok = double.TryParse(buf, out Y);
                if (!ok)
                {
                    Console.WriteLine("Введено не число!");
                }
            }
            while (!ok);

            Console.WriteLine($"X = {X}, Y = {Y}");

            double MaxY1, MinY1, MaxY2, MinY2;
            bool f1;

            MaxY1 = (5 / 7 * X + 5);
            MinY1= (-5 / 7 * X - 5);
            MaxY2 = 0;
            MinY2 = 5 / 3 * X - 5;
            f1 = (X < 0 && X >= -7 && Y <= MaxY1 && Y >= MinY1) || (X >= 0 && X <= 3 && Y <= MaxY2 && Y >= MinY2) || ( X == 0 && Y == 0);
            Console.WriteLine(f1);
        }
    }
}
