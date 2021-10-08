using System;

namespace Lab_5
{
    class Program
    {
        static int count1 = 0;
        static int count2 = 0;
        static int count3 = 0;

        // печать одномерного массива
        static void Print_1st_Arr(int[] arr)
        {

            if (arr.Length == 0)
            {
                Console.WriteLine("Одномерный массив пуст!");
            }
            else
            {
                Console.Write("\t[ " + arr[0]);
                for (int i = 1; i < arr.Length; i++)
                {
                    Console.Write(", " + arr[i]);
                }
                Console.WriteLine(" ]\n");
            }
            return;
        }
        static void Print_2nd_Arr(int[,] arr2)
        {
            if (arr2.GetLength(0) == 0 || arr2.GetLength(1) == 0)
            {
                Console.WriteLine("Массив пуст!");
            }
            else
            {
                for (int i = 0; i < arr2.GetLength(0); i++)
                {
                    Console.Write($"{i}) ");
                    for (int j = 0; j < arr2.GetLength(1); j++)
                    {
                        Console.Write(arr2[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }

        //Функция удаления из массива четных элементов массива
        static void Del_Even_in_1st_Arr(ref int[] arr1)
        {
            int count_not_even = 0;
            if (arr1.Length != 0)
            {
                foreach (int x in arr1)
                {
                    if (x % 2 != 0)
                    {
                        count_not_even++;
                    }
                }

                int[] arr = new int[count_not_even];
                int i = 0;
                foreach (int x in arr1)
                {
                    if (x % 2 != 0)
                    {
                        arr[i] = x;
                        i++;
                    }
                }
                arr1 = arr;
            }
        }

        // функция создания и заполнения массива указанным способом
        static void Select_in_1st_Create(int size, int choice, ref bool cancel, ref int[] arr1)
        {
            arr1 = new int[size];
            do
            {
                switch (choice)
                {
                    case 1:
                        Random rand = new Random();
                        for (int i = 0; i < size; i++)
                        {
                            arr1[i] = rand.Next(0, 255);
                        }
                        return;
                    case 2:
                        bool ok = false;
                        do
                        {

                            for (int i = 0; i < size; i++)
                            {
                                string buf;
                                Console.Write($"Введите {i} элемент массива: ");
                                buf = Console.ReadLine();
                                int temp;
                                ok = Int32.TryParse(buf, out temp);
                                if (!ok)
                                {
                                    Console.WriteLine("Указано некоректное значение!");
                                }
                                else
                                {
                                    arr1[i] = temp;
                                }
                            }
                        } while (!ok);
                        return;
                    case 3:
                        cancel = true;
                        return;
                }
            } while (!cancel);
            Print_1st_Arr(arr1);
        }

        static void Create_1st_Arr(ref int[] arr1)
        {
            bool cancel = false;

            int choice = -1;
            int size = 0;
            string buf;
            bool ok = false;
            do
            {

                Console.Write("Введите количество элементов одномерного массива: ");
                buf = Console.ReadLine();
                ok = Int32.TryParse(buf, out size);
            } while (size < 1 || !ok);
            do
            {

                Console.WriteLine("Как вы хотите заполнить одномерный массив?");
                Console.WriteLine("1) Создать массив с помощью ДСЧ");
                Console.WriteLine("2) Создать массив вручную");
                Console.WriteLine("3) Назад");
                Console.Write("Ваш выбор: ");
                buf = Console.ReadLine();
                ok = Int32.TryParse(buf, out choice);

            } while (choice < 1 || choice > 3 || !ok);
            Select_in_1st_Create(size, choice, ref cancel, ref arr1);
        }


        static void Select_in_Sub_Menu_1(ref bool end, ref int choice, ref int[] arr1)
        {
            string buf;
            buf = Console.ReadLine();
            if (!Int32.TryParse(buf, out choice))
            {
                choice = -1;
                return;
            }
            else
            {
                switch (choice)
                {
                    case 1: Create_1st_Arr(ref arr1); break;
                    case 2: Print_1st_Arr(arr1); break;
                    case 3: Del_Even_in_1st_Arr(ref arr1); break;
                    case 4: end = true; return;
                }
            }
        }

        static void Sub_Menu_1(ref int[] arr1)
        {
            bool cancel = false;
            bool end = false;
            do
            {
                int choice = -1;
                while (choice < 1 || choice > 4 || cancel)
                {
                    if (count1 == 0)
                    {
                        Console.Clear();
                        count1++;
                    }

                    cancel = false;
                    Console.WriteLine("Работа с одномерным динамическим массивом");
                    Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
                    Print_1st_Arr(arr1);
                    Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
                    Console.WriteLine("1) Создать массив");
                    Console.WriteLine("2) Напечатать массив");
                    Console.WriteLine("3) Удалить все четные элементы из массива");
                    Console.WriteLine("4) Назад");
                    Console.Write("Ваш выбор: ");
                    Select_in_Sub_Menu_1(ref end, ref choice, ref arr1);
                }
            } while (!end);
        }

        //Добавить К строк, начиная со строки с номером N
        static void Add_Rows(ref int[,] arr2)
        {
            if (arr2.GetLength(0) == 0)
            {
                Console.WriteLine("Сначала создайте массив!");
            }
            else
            {
                int K;
                int N;
                bool ok;
                string buf;
                do
                {
                    Console.Write("Сколько строк необходимо добавить: ");
                    buf = Console.ReadLine();
                    ok = Int32.TryParse(buf, out K);
                } while (!ok || K < 1 || K > 100);

                int[,] arr = new int[arr2.GetLength(0) + K, arr2.GetLength(1)];
                do
                {
                    Console.Write("Добавить в массив начиная со строки под номером: ");
                    buf = Console.ReadLine();
                    ok = Int32.TryParse(buf, out N);
                } while (!ok || N < 0 || N > arr2.GetLength(0) - 1);

                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < arr2.GetLength(1); j++)
                    {
                        arr[i, j] = arr2[i, j];
                    }
                }
                bool cancel = false;
                int choice;
                do
                {
                    Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
                    Print_2nd_Arr(arr2);
                    Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
                    Console.WriteLine("1) Автоматическое заполнение");
                    Console.WriteLine("2) Ручное заполнение");
                    Console.WriteLine("3) Назад");
                    Console.Write("Ваш выбор: ");
                    buf = Console.ReadLine();
                    ok = Int32.TryParse(buf, out choice);
                    int count = N;
                    switch (choice)
                    {
                        case 1:
                            count = N;
                            Random rand = new Random();
                            for (int i = N; i < N + K; i++)
                            {
                                for (int j = 0; j < arr2.GetLength(1); j++)
                                {
                                    arr[i, j] = rand.Next(0, 255);
                                }
                            }
                            for (int i = N + K; i < arr.GetLength(0); i++, count++)
                            {
                                for (int j = 0; j < arr2.GetLength(1); j++)
                                {
                                    arr[i, j] = arr2[count, j];
                                }
                            }
                            arr2 = arr;
                            break;
                        case 2:
                            count = N;
                            int x;
                            bool f = false;
                            for (int i = N; i < N + K; i++)
                            {
                                Console.WriteLine($"Заполните {i} строку");
                                for (int j = 0; j < arr2.GetLength(1); j++)
                                {
                                    do
                                    {
                                        Console.WriteLine($"Введите {j} элемент");
                                        buf = Console.ReadLine();
                                        f = Int32.TryParse(buf, out x);
                                    } while (!f);
                                    arr[i, j] = x;
                                }
                            }
                            for (int i = N + K; i < arr.GetLength(0); i++, count++)
                            {
                                for (int j = 0; j < arr2.GetLength(1); j++)
                                {
                                    arr[i, j] = arr2[count, j];
                                }
                            }
                            arr2 = arr;
                            break;
                        case 3:
                            cancel = true;
                            break;
                    }
                } while (!cancel || !ok);
            }
        }

        // функция выбора метода создания двумерного массива
        static void Create_2nd_Arr(ref int[,] arr2)
        {
            bool ok = false;
            string buf;
            int rows = -1;
            int cols = -1;
            do
            {
                Console.Write("Введите количество строк двумерного массива: ");
                buf = Console.ReadLine();
                ok = Int32.TryParse(buf, out rows);
            } while (rows < 1 || !ok);
            do
            {
                Console.Write("Введите количество столбцов двумерного массива: ");
                buf = Console.ReadLine();
                ok = Int32.TryParse(buf, out cols);
            } while (cols < 1 || !ok);
            arr2 = new int[rows, cols];
            bool cancel = false;
            int choice;
            do
            {
                Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
                Print_2nd_Arr(arr2);
                Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
                Console.WriteLine("1) Автозаполнение двумерного массива");
                Console.WriteLine("2) Ручное заполнение двумерного массиа");
                Console.WriteLine("3) Назад");
                Console.Write("Ваш выбор: ");
                buf = Console.ReadLine();
                ok = Int32.TryParse(buf, out choice);
                switch (choice)
                {
                    case 1:
                        Random rand = new Random();
                        for (int i = 0; i < rows; i++)
                        {
                            for (int j = 0; j < cols; j++)
                            {
                                arr2[i, j] = rand.Next(0, 255);
                            }
                        }
                        break;
                    case 2:
                        for (int i = 0; i < rows; i++)
                        {
                            Console.Clear();
                            Console.WriteLine($"Заполнение {i} строки");
                            for (int j = 0; j < cols; j++)
                            {
                                int x;
                                do
                                {
                                    Console.Write($"Введите {j} элемент строки: ");
                                    buf = Console.ReadLine();
                                    ok = Int32.TryParse(buf, out x);
                                } while (!ok);
                                arr2[i, j] = x;
                            }
                        }
                        break;
                    case 3: cancel = true; break;
                }
            } while (!cancel || !ok || choice < 1 || choice > 3);
        }

        static void Select_Sub_menu_2(ref int choice, ref bool end, ref int[,] arr2)
        {
            string buf;
            buf = Console.ReadLine();
            bool ok = Int32.TryParse(buf, out choice);
            if (!ok)
            {
                choice = -1;
                return;
            }
            else
            {
                switch (choice)
                {
                    case 1: Create_2nd_Arr(ref arr2); break;
                    case 2: Print_2nd_Arr(arr2); break;
                    case 3: Add_Rows(ref arr2); break;
                    case 4: end = true; return;
                }
            }
        }

        static void Sub_Menu_2(ref int[,] arr2)
        {
            bool end = false;
            do
            {
                int choice = -1;
                do
                {
                    if (count2 == 0)
                    {
                        Console.Clear();
                        count2++;
                    }

                    Console.WriteLine("Работа с Двумерным динамическим массивом");
                    Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
                    Print_2nd_Arr(arr2);
                    Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
                    Console.WriteLine("1) Создать массив");
                    Console.WriteLine("2) Напечатать массив");
                    Console.WriteLine("3) Добавить К строк, начиная со строки с номером N");
                    Console.WriteLine("4) Назад");
                    Console.Write("Ваш выбор: ");
                    Select_Sub_menu_2(ref choice, ref end, ref arr2);
                } while (choice < 1 || choice > 4);
            } while (!end);
        }



        static void Add_Rows_in_End(ref int[][] arr3)
        {
            int K;
            bool ok;
            string buf;
            do
            {
                Console.Write("Сколько строк необходимо добавить: ");
                buf = Console.ReadLine();
                ok = Int32.TryParse(buf, out K);
            } while (!ok || K < 1 || K > 100);
            int[][] arr = new int[arr3.Length + K][];
            for (int i = 0; i < arr3.Length; i++)
            {
                arr[i] = arr3[i];
            }
            bool cancel = false;
            int choice;
            do
            {
                Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
                CallPrint(ref arr3);
                Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
                Console.WriteLine("1) Автоматическое заполнение");
                Console.WriteLine("2) Ручное заполнение");
                Console.WriteLine("3) Назад");
                Console.Write("Ваш выбор: ");
                buf = Console.ReadLine();
                ok = Int32.TryParse(buf, out choice);
                switch (choice)
                {
                    case 1:
                        Random rand = new Random();
                        bool f = false;
                        int x;
                        for (int i = arr3.Length; i < arr.Length; i++)
                        {
                            do
                            {
                                Console.Write($"Введите количество элементов {i} строки: ");
                                buf = Console.ReadLine();
                                f = Int32.TryParse(buf, out x);
                            } while (!f || x < 1 || x > 100);
                            arr[i] = new int[x];
                            for (int j = 0; j < x; j++)
                            {
                                arr[i][j] = rand.Next(0, 255);
                            }
                        }
                        arr3 = arr;
                        break;
                    case 2:
                        f = false;
                        for (int i = arr3.Length; i < arr.Length; i++)
                        {
                            do
                            {
                                Console.Write($"Введите количество элементов {i} строки: ");
                                buf = Console.ReadLine();
                                f = Int32.TryParse(buf, out x);
                            } while (!f || x < 1 || x > 100);
                            arr[i] = new int[x];
                            int temp;
                            for (int j = 0; j < x; j++)
                            {
                                Console.WriteLine($"Заполните {i} строку");
                                do
                                {
                                    Console.Write($"Введите {j} элемент: ");
                                    buf = Console.ReadLine();
                                    f = Int32.TryParse(buf, out temp);
                                } while (!f);
                                arr[i][j] = temp;
                            }
                        }
                        arr3 = arr;
                        break;
                    case 3:
                        cancel = true;
                        break;
                }
            } while (!cancel || !ok);
        }
        static void Create_3rd_Arr(ref int[][] arr3)
        {
            bool ok = false;
            string buf;
            int rows = -1;
            int cols = -1;
            do
            {
                Console.Write("Введите количество строк рваного массива: ");
                buf = Console.ReadLine();
                ok = Int32.TryParse(buf, out rows);
            } while (rows < 1 || !ok);
            arr3 = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                cols = 0;
                do
                {
                    Console.Write($"Введите количество элементов {i} строки: ");
                    buf = Console.ReadLine();
                    ok = Int32.TryParse(buf, out cols);
                } while (cols < 1 || !ok);
                arr3[i] = new int[cols];
            }
            bool cancel = false;
            int choice;
            do
            {
                Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
                CallPrint(ref arr3);
                Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
                Console.WriteLine("1) Автозаполнение рваного массива");
                Console.WriteLine("2) Ручное заполнение рваного массиа");
                Console.WriteLine("3) Назад");
                Console.Write("Ваш выбор: ");
                buf = Console.ReadLine();
                ok = Int32.TryParse(buf, out choice);
                switch (choice)
                {
                    case 1:
                        Random rand = new Random();
                        for (int i = 0; i < arr3.Length; i++)
                        {
                            for (int j = 0; j < arr3[i].Length; j++)
                            {
                                arr3[i][j] = rand.Next(0, 255);
                            }
                        }
                        break;
                    case 2:
                        for (int i = 0; i < arr3.Length; i++)
                        {
                            Console.Clear();
                            Console.WriteLine($"Заполнение {i} строки");
                            for (int j = 0; j < arr3[i].Length; j++)
                            {
                                int x;
                                do
                                {
                                    Console.Write($"Введите {j} элемент строки: ");
                                    buf = Console.ReadLine();
                                    ok = Int32.TryParse(buf, out x);
                                } while (!ok);
                                arr3[i][j] = x;
                            }
                        }
                        break;
                    case 3: cancel = true; break;
                }

            } while (!cancel || !ok || choice < 1 || choice > 3);
        }

        static void CallPrint(ref int[][] arr3)
        {
            if (arr3.Length == 0)
            {
                Console.WriteLine("Массив пуст!");
            }
            else
            {
                for (int i = 0; i < arr3.Length; i++)
                {
                    Console.Write($"{i}) ");
                    Print_1st_Arr(arr3[i]);
                }
            }
        }

        static void Select_Sub_Menu_3(ref int choice, ref bool end, ref int[][] arr3)
        {
            string buf;
            buf = Console.ReadLine();
            bool ok = Int32.TryParse(buf, out choice);
            if (!ok)
            {
                choice = -1;
                return;
            }
            else
            {
                switch (choice)
                {
                    case 1: Create_3rd_Arr(ref arr3); break;
                    case 2: CallPrint(ref arr3); break;
                    case 3: Add_Rows_in_End(ref arr3); break;
                    case 4: end = true; return;
                }
            }
        }

        static void Sub_Menu_3(ref int[][] arr3)
        {
            bool end = false;
            do
            {
                int choice = -1;
                do
                {
                    if (count3 == 0)
                    {
                        Console.Clear();
                        count3++;
                    }
                    Console.WriteLine();
                    Console.WriteLine("Работа с рваным динамическим массивом");
                    Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
                    CallPrint(ref arr3);
                    Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
                    Console.WriteLine("1) Создать массив");
                    Console.WriteLine("2) Напечатать массив");
                    Console.WriteLine("3) Добавить К строк в конец массива ");
                    Console.WriteLine("4) Назад");
                    Console.Write("Ваш выбор: ");
                    Select_Sub_Menu_3(ref choice, ref end, ref arr3);
                } while (choice < 1 || choice > 4);
            } while (!end);
        }

        static void Select_in_Main_Menu(ref int choice, ref bool exit, ref int[] arr1, ref int[,] arr2, ref int[][] arr3)
        {
            string buf;
            buf = Console.ReadLine();
            if(!Int32.TryParse(buf, out choice))
            {
                choice = -1;
                return;
            }
            else
            {
                switch (choice)
                {
                    case 1: Sub_Menu_1(ref arr1); break;
                    case 2: Sub_Menu_2(ref arr2); break;
                    case 3: Sub_Menu_3(ref arr3); break;
                    case 4: exit = true; break;
                }
            }
        }

        // Функция главного меню
        static void Main_Menu(ref int[] arr1, ref int[,] arr2, ref int[][] arr3)
        {
            
            int choice = -1;
            bool exit = false; // флаг отвечающий за выход из программы
            while (choice < 1 || choice > 4 || exit == false)
            {
                if (!exit)
                {
                    Console.Clear();
                    exit = false;
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("С каким массивом будем работать?");
                    Console.WriteLine("1) Одномерный массив");
                    Console.WriteLine("2) Двумерный массив");
                    Console.WriteLine("3) Рваный массив");
                    Console.WriteLine("4) Выход из программы");
                    Console.Write("Ваш выбор: ");
                    Select_in_Main_Menu(ref choice, ref exit, ref arr1, ref arr2, ref arr3);
                }
                else
                {
                    break;
                }
            }
        }

        static void Main(string[] args)
        {

            int[] arr1 = new int[0];

            int[,] arr2 = new int[0, 0];

            int[][] arr3 = new int[0][];

            Main_Menu(ref arr1, ref arr2, ref arr3);
        }
    }
}
