using System;

namespace part_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Решение 3 задачи");
            Console.WriteLine("a = 100, b = 0.001");
            double a = 100;
            double b = 0.001;

            double c = Math.Pow(a - b, 3);
            double d = Math.Pow(a, 3);
            double e = Math.Pow(b, 2);
            double f = 3 * a * e;
            double g = Math.Pow(b, 3);
            double h = Math.Pow(a, 2);
            double i = 3 * h * b;
            Console.WriteLine((c - d) / (f - g - i));


            float c1 = (float)Math.Pow(a - b, 3);
            float d1 = (float)Math.Pow(a, 3);
            float e1 = (float)Math.Pow(b, 2);
            float f1 = (float)3 * (float)a * e1;
            float g1 = (float)Math.Pow(b, 3);
            float h1 = (float)Math.Pow(a, 2);
            float i1 = (float)3 * h1 * (float)b;
            Console.WriteLine((c1 - d1) / (f1 - g1 - i1));
        }
    }
}
