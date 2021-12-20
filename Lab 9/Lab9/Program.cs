using System;
using Lib;


namespace Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            Money a1 = new Money();
            Console.WriteLine("Конструктор без параметров");
            a1.Show();
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-");
            Money a2 = new Money(10, 20);
            Console.WriteLine("Конструктор с двумя параметрами типа int");
            a2.Show();
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-");
            Money a3 = new Money(10, 655);
            Console.WriteLine("Конструктор с двумя параметрами типа int, при этом копеек больше 100");
            a3.Show();
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-");
            Money a4 = new Money(11.66);
            Console.WriteLine("Конструктор c параметром типа double");
            a4.Show();
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-");
            Console.WriteLine("Вычитаение через статическую фукнцию");
            Money a5 = new Money();
            Console.WriteLine($"{a3.Show()} - {a4.Show()}");
            a5 = a5.Minus(a3, a4);
            a5.Show();
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-");
            Console.WriteLine("Вычитаение через статическую фукнцию из меньшего большее");
            Money a6 = new Money();
            a4 = new Money(1, 55);
            a3 = new Money(33, 66);
            Console.WriteLine($"{a4.Show()} - {a3.Show()}");
            a6 = a6.Minus(a4, a3);
            a6.Show();
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-");
            Console.WriteLine("Вычитаение через перегрузку оператора вычитаение");
            a4 = new Money(1, 55);
            a3 = new Money(33, 66);
            Console.WriteLine($"{a3.Show()} - {a4.Show()}");
            Money a7 = new Money();
            a7 = a3 - a4;
            a7.Show();
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-");
            Console.WriteLine("Инкремент копеек");
            Money b1 = new Money(11, 22);
            b1++;
            b1.Show();
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-");
            Console.WriteLine("Инкремент копеек если копейки равны 99");
            Money b2 = new Money(11, 99);
            b2++;
            b2.Show();
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-");
            Console.WriteLine("Декремент копек копеек если копеек");
            Money b3 = new Money(9, 15);
            b3--;
            b3.Show();
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-");
            Console.WriteLine("Декремент копек копеек если копеек 0");
            Money b4 = new Money(9, 0);
            b4--;
            b4.Show();
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-");
            Console.WriteLine("Декремент копек копеек если копеек и рублей 0");
            Money b5 = new Money(0, 0);
            b5--;
            b5.Show();
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-");
            Console.WriteLine("Приведение типа Money к int");
            Money b6 = new Money(55, 55);
            int tmp = b6;
            Console.WriteLine($"Неявное приведение типов: {tmp}");
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-");
            Console.WriteLine("Приведение типа Money к double");
            Money b7 = new Money(88, 88);
            double tmpD = (double)b7;
            Console.WriteLine($"Неявное приведение типов: {tmpD}");
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-");
            Console.WriteLine("Money - целое число копеек");
            Money b8 = new Money(88, 88);
            Console.WriteLine($"{b8.Show()} - 1313 копеек");
            b8 = b8 - 1313;
            b8.Show();
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-");
            Console.WriteLine("Money - целое число копеек, вычитаемое больше");
            Money b9 = new Money(88, 88);
            Console.WriteLine($"{b9.Show()} - 10099 копеек");
            b9 = b9 - 10099;
            b9.Show();
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-");
            Console.WriteLine("Money - целое число копеек");
            Money b10 = new Money(88, 88);
            Money b11 = new Money(77, 77);
            Console.WriteLine($"{b10.Show()} - {b11.Show()}");
            b10 = b10 - b11;
            b10.Show();
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-");
            Console.WriteLine("Money - целое число копеек, вычитаемое больше");
            Money b12 = new Money(88, 88);
            Money b13 = new Money(77, 77);
            Console.WriteLine($"{b13.Show()} - {b12.Show()}");
            b13 = b13 - b12;
            b13.Show();
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-");
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-");
            Console.WriteLine("Конструктов MoneyArray без параметров");
            MoneyArray arr1 = new MoneyArray();
            arr1.Show();
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-");
            Console.WriteLine("Конструктов MoneyArray с параметром size и автоматической генерацией элементов");
            MoneyArray arr2 = new MoneyArray(10);
            arr2.Show();
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-");
            Console.WriteLine("Конструктов MoneyArray с некорректным параметром size");
            try
            {
                MoneyArray arr3 = new MoneyArray(-10);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-");
            Console.WriteLine("Конструктов MoneyArray с параметром size и ручным вводом элементов");
            MoneyArray arr4 = new MoneyArray(5, 0);
            arr4.Show();
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-");
            Console.WriteLine("Конструктов MoneyArray с некорректным параметром size и ручным вводом");
            try
            {
                MoneyArray arr5 = new MoneyArray(-10, 0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-");
            Console.WriteLine("Получение значения через индексатор");
            try
            {
                MoneyArray arr6 = new MoneyArray(10);
                Money c1 = arr6[3];
                c1.Show();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-");

            Console.WriteLine("Обращение к несуществующему индексу");
            try
            {
                MoneyArray arr6 = new MoneyArray(10);
                Money c1 = arr6[10000];
                c1.Show();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-");
            Console.WriteLine("Поиск максимального элемента массива");
            MoneyArray arr7 = new MoneyArray(10);
            arr7.Show();
            Money c2 = arr7.FindMax();
            Console.WriteLine($"Максимальный элемент: {c2.Show()}");
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-");
            Console.WriteLine($"Kоличество созданных элементов класса Money = {c2.Count}");
            Console.WriteLine($"Kоличество созданных элементов класса ArrayMoney = {arr7.Count}");
        }
    }
}
