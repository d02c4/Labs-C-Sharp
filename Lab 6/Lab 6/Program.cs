using System;

namespace Lab_6
{
    public class Program
    {
        static int ind = 0;
        static string[] SeparatorsArr;
        static string resultStr = "";

        // функция проверки размера массива на 0
        static bool SizeZero(int[] arr1)
        {
            if (arr1.Length == 0)
                return true;
            else
                return false;
        }

        // печать одномерного массива int
        static void PrintArr(int[] arr1)
        {
            if(!SizeZero(arr1))
            {
                Console.Write("\n[ " + arr1[0]);
                for(int i = 1; i < arr1.Length; i++)
                {
                    Console.Write(", " + arr1[i]);
                }
                Console.WriteLine(" ]\n");
            }
            else
            {
                Console.WriteLine("\n Массив пуст!\n");
            }
        }

        // печать массива с подстроками 
        static void PrintArr2(string[] arr2)
        {
            if(arr2.Length != 0)
            {
                Console.WriteLine("======================================");
                Console.Write($"Итоговая строка: {resultStr}");
                Console.WriteLine("\n======================================");
            }
            else
            {
                Console.WriteLine("======================================");
                Console.Write("Итоговая строка: Пуста!!!");
                Console.WriteLine("\n======================================");
            }
        }

        // печать главного меню
        static void PrintMainMenu()
        {
            Console.WriteLine("1) Работа с одномерным массивом с элементами типа int");
            Console.WriteLine("2) Работа со строкой");
            Console.WriteLine("3) Выход из программы");
            Console.Write("Ваш выбор: ");
        }

        //печать меню работы с одномерным массивом int
        static void PrintSubMenu1()
        {
            Console.WriteLine("1) Создать массив");
            Console.WriteLine("2) Печать массива");
            Console.WriteLine("3) Отсортировать массив");
            Console.WriteLine("4) Удалить из массива все элементы кратные минимальному элементу массива");
            Console.WriteLine("5) Выход");
            Console.Write("Ваш выбор: ");
        }

        // печать меню работы со строкой
        static void PrintSubMenu2()
        {
            Console.WriteLine("1) Ввод строки");
            Console.WriteLine("2) Разбить на подстроки и удалить все слова в строке, которые начинаются с цифры");
            Console.WriteLine("3) Печать строки");
            Console.WriteLine("4) Выход");
            Console.Write("Ваш выбор: ");
        }

        // печать меню размера массива int
        static void PrintSubMenuSize()
        {
            Console.Write("Введите размер массива: ");
        }

        // печать меню создания одномерного массива
        static void PrintSubMenuCreateArr()
        {
            Console.WriteLine("Как заполнить массив?");
            Console.WriteLine("1) Автоматически");
            Console.WriteLine("2) Вручную");
            Console.WriteLine("3) Назад");
            Console.Write("Ваш выбор: ");
        }

        // печать меню ручного заполнения одномерного массива int
        static void PrintManualFill()
        {
            Console.Write($"Введите {ind} элемент массива: ");
            ind++;
        }

        // печать меню создания строки
        static void PrintSubMenuCreateSentenses()
        {
            Console.WriteLine("Как заполнить строку?");
            Console.WriteLine("1) Автоматически");
            Console.WriteLine("2) Вручную");
            Console.WriteLine("3) Назад");
            Console.Write("Ваш выбор: ");
        }

        // функция для вызова других функций печати, исходя из полученного аргумента
        static void PrintMenu(int SelectMenu)
        {
            switch (SelectMenu)
            {
                case 1: PrintMainMenu(); break;
                case 2: PrintSubMenu1(); break;
                case 3: PrintSubMenuSize(); break;
                case 4: PrintSubMenuCreateArr(); break;
                case 5: PrintManualFill(); break;
                case 6: PrintSubMenu2(); break;
                case 7: PrintSubMenuCreateSentenses(); break;
                case 8: break;
            }

        }

        // фукнция ввода
        static int Input(int choice, int count, int SelectMenu)
        {
            bool ok = false;
            string buf;
            do
            {
                Console.WriteLine("\n");
                PrintMenu(SelectMenu); // печать меню в консоль
                buf = Console.ReadLine();
                ok = Int32.TryParse(buf, out choice);
                
                if (!ok || choice < 1 || choice > count)
                {
                    Console.WriteLine("\n\nНекорректный ввод\n\n");
                    ind--;
                }
            } while (!ok || choice < 1 || choice > count);

            return choice;
        }

        // фукнция задания размера массива
        static void SizeArr(out int[] arr1)
        {
            int size = 0;
            size = Input(size, 50, 3);
            arr1 = new int[size];

            // по умолчанию заполняем 1
            for(int i = 0; i < size; i++)
            {
                arr1[i] = 1;
            }
        }

        // фукнция автозаполнения массива
        static void AutoFillArr(int[] arr1)
        {
            Random rand = new Random();
            for(int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = rand.Next(1, 100);
            }
        }

        // функция ручного заполнения массива
        static void ManualFill(int[] arr1)
        {
            ind = 0;
            for(int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = Input(arr1[i], 100, 5);
            }
        
        }

        // функция создания одномерного массива
        static void CreateArr1(out int[] arr1)
        {
            bool exit = false;
            SizeArr(out arr1);
            int choice = 0;  
            while (!exit)
            {    
                PrintArr(arr1);
                choice = Input(choice, 3, 4);
                switch (choice)
                {
                    case 1: AutoFillArr(arr1); break;
                    case 2: ManualFill(arr1); break;
                    case 3: exit = true; break;
                }
            }
        }

        // функция поиска минимального элемента массива
        static int FindMin(int[] arr)
        {
            if (arr.Length > 0)
            {
                int[] tmp = new int[arr.Length];
                Array.Copy(arr, tmp, arr.Length);
                Array.Sort(tmp);
                return tmp[0];
            }
            else 
                return 0;
        }

        // поиск и удаление элементов из временного массива
        static void FindDelElements(ref int[] arr1, int el)
        {      
            int size = 0;
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] == el)
                {
                    size++;
                }
            }
            int[] tmp = new int[arr1.Length - size];
            int index = 0;
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != el)
                {
                    tmp[index] = arr1[i];
                    index++;
                }
            }
            arr1 = tmp;
        }

        // функция удаления элементов из основного массива
        static void DelElements(ref int[] arr1)
        {
            if (arr1.Length > 0)
            {
                int[] tmpArr = arr1;
                int Min = FindMin(tmpArr);
                for (int i = 0; i < arr1.Length; i++)
                {
                    if (arr1[i] % Min == 0)
                    {
                        FindDelElements(ref tmpArr, arr1[i]);
                    }
                }
                arr1 = tmpArr;
                PrintArr(arr1);
            }
            else
            {
                Console.WriteLine("Массив пуст!");
            }
        }

        // фукнция разбиения строки на подстроки
        static string[] SplitString(string sentenses)
        {
            string[] separators = { " ", " ", " .", " ,", " ;", " :", " !", " ?", ",", ", ", ".", ". ", "!", "! ", "?", "? ", "-", " - ", "- ", ";", "; ", ":", ": " };
            string[] arrWords = sentenses.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            return arrWords;
        }

        // функция создания строки результата
        static void CreateResultString(string[] arr2)
        {
            resultStr = "";
            int i = 0;
            foreach (var x in arr2)
            {
                resultStr += x;
                while (i < SeparatorsArr.Length)
                {
                    if (SeparatorsArr[i] != null)
                    {
                        resultStr += SeparatorsArr[i];
                        i++;
                        break;
                    }
                    i++;
                }
            }
        }

        // проверка на разделители
        static bool IsSigngs(char a)
        {
            if(a == ' ' || a == '.' || a == '!' || a == ',' || a == '?' || a == '-' || a == ';' || a == ':')
            {
                return true;
            }
            return false;
        }

        // удаление элементов из массива разделителей
        static void DelInSeporatorsArr(int i)
        {
            SeparatorsArr[i] = null;
        }

        // добавление элементов в массив разделителей
        static void AddInSeporatorsArr(string str)
        {
            bool f = true;
            for(int i = 0; i < SeparatorsArr.Length && f; i++)
            {
                if(SeparatorsArr[i] == null)
                {
                    f = false;
                    SeparatorsArr[i] = str;
                }
            }
        }

        // переопределение массива разделителей
        static void CreateSeparatorsArr()
        {
            SeparatorsArr = new string[1000];
        }

        static void CreateStringSigns(string arr2)
        {
            for(int i = 0; i < arr2.Length; i++)
            {
                char a;
                string str = "";
                a = arr2[i];
                while (IsSigngs(a))
                {
                    str += a;
                    i++;
                    if (i >= arr2.Length)
                        break;
                    a = arr2[i];
                }
                if(str!= "")
                    AddInSeporatorsArr(str);
            }
        }

        // меню для работы с одномерным массивом int
        static void SubMenu1(ref int[] arr1)
        {
            int choice = 0; // переменная, отвечающая за выбор действия в подменю
            bool exit = false;
            while (!exit)
            {
                choice = Input(choice, 5, 2); // выбор действия в меню
                switch (choice)
                {
                    case 1: CreateArr1(out arr1); break;
                    case 2: PrintArr(arr1); break;
                    case 3: Array.Sort(arr1); PrintArr(arr1); break;
                    case 4: DelElements(ref arr1); break;
                    case 5: exit = true; break;
                }
            }

        }

        // автоматическое заполнение строки
        static void AutoFillSentenses(ref string sentenses)
        {
            sentenses = "";
            string alpha = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string al = ",.!?;:";
            Random rand = new Random();
            int countWords = rand.Next(3, 12);
            int countLetters = rand.Next(5, 10);
            for (int j = 0; j < countWords; j++)
            {
                for (int i = 0; i < countLetters; i++)
                {
                    int y = rand.Next(0, alpha.Length - 1);
                    sentenses += alpha[y];
                }
                int tmpRand = rand.Next(0, al.Length - 1);
                sentenses += al[tmpRand];
                sentenses += ' ';
            }
        }

        // ручное заполнение строки
        static void ManualFillArr2(ref string sentenses)
        {
            Console.Write("Введите строку: ");
            sentenses = Console.ReadLine();
        }

        // создание строки
        static void CreateSentenses(ref string sentenses)
        {
            int choice = 0; // переменная, отвечающая за выбор действия в подменю
            bool exit = false;
            while (!exit)
            {
                if (sentenses != "")
                {
                    Console.WriteLine($"\nстрока: {sentenses}\n");
                }
                else
                {
                    Console.WriteLine($"\nстрока: Пуста!!\n");
                }
                choice = Input(choice, 3, 7); // выбор действия в меню 
                switch (choice)
                {
                    case 1: AutoFillSentenses(ref sentenses); break;
                    case 2: ManualFillArr2(ref sentenses); break;
                    case 3: exit = true; break;
                }
            }
        }


        // проверка на то, что в подстроке 1 символ не число
        static bool FirstNotNumber(char letter)
        {
            if (letter != '0'
                    && letter != '1'
                    && letter != '2'
                    && letter != '3'
                    && letter != '4'
                    && letter != '5'
                    && letter != '6'
                    && letter != '7'
                    && letter != '8'
                    && letter != '9')
            {
                return true;
            }
            return false;
        }


        // подсчет слов без чисел на месте первого символа
        static int CountWordWithOutNumb(string[] arr2)
        {
            int count = 0;
            for (int i = 0; i < arr2.GetLength(0); i++)
            {
                if (FirstNotNumber(arr2[i][0]))
                {
                    count++;
                }
                else
                {
                    DelInSeporatorsArr(i);
                }
            }
            return count;
        }

        // удаление подстрок по условию
        static void DelWordsNumber(out string[] arr2, string sentenses)
        {
            arr2 = SplitString(sentenses);
            int count = CountWordWithOutNumb(arr2); // счетчик слов начинающихся не с цифр
            string[] tempArr2 = new string[count];
            count = 0;
            for(int i = 0; i < arr2.GetLength(0); i++)
            {
                if(FirstNotNumber(arr2[i][0]))
                {
                    tempArr2[count] = arr2[i];
                    count++;
                }
            }
            arr2 = tempArr2;
            if (count != 0)
            {
                Console.WriteLine("\nПреобразование успешно завершено!");
            }
            else
            {
                Console.WriteLine("\nПреобразование не произведено!");
            }
            CreateResultString(arr2);
            PrintArr2(arr2);
        }

        // меню работы со строкой
        static void SubMenu2(ref string[] arr2)
        {
            int choice = 0; // переменная, отвечающая за выбор действия в подменю
            bool exit = false;
            string senteses = "";
            while (!exit)
            {
                choice = Input(choice, 4, 6); // выбор действия в меню
                switch (choice)
                {
                    case 1: CreateSentenses(ref senteses); CreateSeparatorsArr(); CreateStringSigns(senteses); resultStr = senteses; break;
                    case 2: DelWordsNumber(out arr2, senteses); break;
                    case 3: PrintArr2(arr2); break;
                    case 4: exit = true; break;

                }
            }
        }

        // Главное меню
        static void Menu(ref int[] arr1, ref string[] arr2)
        {
            int choice = 0; // переменная, отвечающая за выбор в главном меню
            bool exit = false; // флаг отвечающий за выход из программы
            while (!exit)
            {
                Console.Clear();
                choice = Input(choice, 3, 1); // выбор действия в меню
                    switch (choice)
                    {
                        case 1: Console.Clear(); SubMenu1(ref arr1); break;
                        case 2: Console.Clear(); SubMenu2(ref arr2); break;
                        case 3: exit = true; break;
                    }
            }
        }
        static void Main(string[] args)
        {
            int[] arr1 = new int[0];
            string[] arr2 = new string[0];
            Menu(ref arr1, ref arr2);
        }
    }
}
