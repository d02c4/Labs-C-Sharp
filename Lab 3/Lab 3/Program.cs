using System;

namespace Lab_3
{
    class Program
    {
        public const double ep = 0.0001;
        static double F(double x)
        {
            return ((1 - (Math.Pow(x, 2) / 2)) * Math.Cos(x) - (x / 2 * Math.Sin(x)));
        }

        static int Factorial(int n)
        {
            int s = 1;
            for (int i = 1; i <= n; i++)
            {
                s *= i;
            }
            return s;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("y = (1 - (x^2/2)) * cos(x) - (x/2) * sin(x))\n");
            double a = 0.1, b = 1;
            double k = (b - a) / 10;
            int count = 0;

            for (double x = a; x <= b; x += k, count++)
            {
                double S = 1.0;
                for (int n = 1; n <= 15; n++)
                {
                    S += Math.Pow(-1, n) * (2 * Math.Pow(n, 2) + 1) / Factorial(2 * n) * Math.Pow(x, 2 * n);
                }

                double SE = 1, f = 0, prevF = 1;
                for (int i = 1; Math.Abs(prevF - f) > ep; i++)
                {
                    prevF = f;
                    f = Math.Pow(-1, i) * (2 * Math.Pow(i, 2) + 1) / Factorial(2 * i) * Math.Pow(x, 2 * i);
                    SE += f;
                }
                Console.WriteLine($"[{count}] \tx = {x}; \tSN = {S}; \tSE = {SE}; \tY = {F(x)}\n");
            }
        }
    }
}
