using System;
using System.Numerics;


namespace Lab_3
{
    class Program
    {
        public const double ep = 0.0001;


        static double F(double x)
        {
            return ((1 - (x * x / 2)) * Math.Cos(x) - (x / 2 * Math.Sin(x)));
        }

        static void Main(string[] args)
        {
            Console.WriteLine("y = (1 - (x^2/2)) * cos(x) - (x/2) * sin(x))\n");
            double a = 0.1, b = 1;
            double k = (b - a) / 10;
            int count = 0;
            for (double x = a; x <= b; x += k, count++)
            {       
                double tmp = 1;
                double S = tmp;
                for (int n = 1; n <= 35; n++)
                {
                    // найдем q - коефициент прогрессии по формуле q = bn/b(n-1)
                    // заранее выведем q
                    double q = -1 * ((2 * n * n * x * x + x * x) / (8 * n * n * n * n - 20 * n * n * n + 20 * n * n - 6 * n));
                    tmp *= q;
                    S += tmp;
                }    
                double SE = 1, f = 1, prevF = 0;
                for (int i = 1; Math.Abs(prevF - f) > ep; i++)
                {
                    prevF = f;
                    // найдем q - коефициент прогрессии по формуле q = bn/b(n-1)
                    double q = -1 * ((2 * i * i * x * x + x * x) / (8 * i * i * i * i - 20 * i * i * i + 20 * i * i - 6 * i));
                    f *= q;
                    SE += f;
                }
                Console.WriteLine($"[{count}] \tx = {x}; \tSN = {S}; \tSE = {SE}; \tY = {F(x)}\n");
            }
        }
    }
}
