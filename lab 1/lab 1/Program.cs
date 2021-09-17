using System;

namespace lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, m;
            double x;
            string buf;
            bool ok = false;
            do
            {
                Console.Write("n = ");
                buf = Console.ReadLine();
                ok = Int32.TryParse(buf, out n);
                if (!ok)
                {
                    Console.WriteLine("Введено некорректное значение для n, n - целочисленное!");
                }
            }
            while (!ok);

            do
            {
                Console.Write("m = ");
                buf = Console.ReadLine();
                ok = Int32.TryParse(buf, out m);
                if (!ok)
                {
                    Console.WriteLine("Введено некорректное значение для m, m - целочисленное!");
                }
            }
            while (!ok);

            do
            {
                Console.Write("x = ");
                buf = Console.ReadLine();
                ok = double.TryParse(buf, out x);
                if (!ok)
                {
                    Console.WriteLine("Введено некорректное значение для x!");
                }
                else if (x < -1)
                {
                    Console.WriteLine("Вещественное число должно быть больше -1");
                }
            }
            while (!ok || x < -1);

            Console.WriteLine($"n = {n}, m = {m}, x = {x}");


            int result_1 = n++ * m;
            n--;
            bool result_2 = n++ < m;
            n--;
            bool result_3 = --m > n;
            m++;
            double result_4 = Math.Pow(2, -x) * Math.Sqrt(x + Math.Pow(Math.Abs(x), 1 / 4));
            Console.WriteLine($"n++*m = {result_1}, n++<m = {result_2}, --m>n = {result_3}, result_4 = {result_4}");
        }
    }
}
