using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lib
{

    public class MoneyArray
    {
        private Money[] arr;
        private int size;
        static public int count = 0;

        public int Count
        {
            get
            {
                return count;
            }
        }

        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                if (value < 0)
                {
                    size = 0;
                }
                else
                {
                    size = value;
                }
            }
        }

        public Money this[int index]
        {
            get
            {
                if (index >= 0 && index < arr.Length)
                    return arr[index];
                else
                {
                    Exception ex = new Exception("Ошибка доступа к индексу!");
                    Console.WriteLine("Ошибка доступа к индексу!");
                    throw ex;
                }
            }
            set
            {
                if (index >= 0 && index < arr.Length)
                    arr[index] = value;
                else
                {
                    Exception ex = new Exception("Ошибка доступа к индексу!");
                    Console.WriteLine("Ошибка доступа к индексу!");
                    throw ex;
                }

            }
        }





        public MoneyArray()
        {
            count++;
            arr = new Money[0];
        }

        public MoneyArray(int size)
        {
            
            if (size > 0)
            {
                count++;
                arr = new Money[size];
                this.size = size;

                Random rand = new Random();

                for (int i = 0; i < Size; i++)
                {
                    Money tmp = new Money();
                    tmp.Kopeks = rand.Next(0, 99);
                    tmp.Rubles = rand.Next(0, 256);
                    arr[i] = tmp;
                }
            }
            else
            {
                Exception e = new Exception("Ошибка, некорректно указан размер");
                throw e;
            }
        }

        public MoneyArray(int size1, int choice)
        {
            if (choice == 0)
            {
                count++;
                if (size1 > 0)
                {
                    arr = new Money[size1];
                    this.Size = size1;
                    for (int i = 0; i < size1; i++)
                    {
                        string buf;
                        int tmp;
                        bool ok;
                        Money tempMoney = new Money();
                        do
                        {
                            Console.Write($"Введите количество рублей {i} элемента массива: ");
                            buf = Console.ReadLine();
                            ok = Int32.TryParse(buf, out tmp);
                            if (!ok || tmp < 0)
                            {
                                Console.WriteLine("Введено некорректное количество рублей!");
                            }
                            tempMoney.Rubles = tmp;
                        } while (!ok || tmp < 0);

                        ok = false;
                        tmp = 0;
                        do
                        {
                            Console.Write($"Введите количество копеек {i} элемента массива: ");
                            buf = Console.ReadLine();
                            ok = Int32.TryParse(buf, out tmp);
                            if (tmp > 99)
                            {
                                tempMoney.Rubles += tmp / 100;

                                tempMoney.Kopeks = tmp - (tmp / 100) * 100;
                            }
                            else if (tmp >= 0)
                            {
                                tempMoney.Kopeks = tmp;
                            }
                            if (!ok || tmp < 0)
                            {
                                Console.WriteLine("Введено некорректное количество копеек!");
                            }
                        } while (!ok || tmp < 0);
                        arr[i] = tempMoney;
                    }
                }
                else
                {
                    Console.WriteLine("Некорректно указан размер массива!");
                    Exception ex = new Exception("Некорректно указан размер массива!");
                    throw ex;
                }
            }
            else
            {
                Console.WriteLine("Неверно передан второй артумент. Для выбора ручного ввода, необходимо указать значение 0!");
                Exception ex = new Exception("Неверно передан второй артумент. Для выбора ручного ввода, необходимо указать значение 0!");
                throw ex;
            }
        }


        public bool Show()
        {
            if (size > 0)
            {
                
                Console.Write("Массив из элементов класса Money: [");
                for (int i = 0; i < Size - 1; i++)
                {
                    Console.Write($"{arr[i].Rubles}.{arr[i].Kopeks}; ");
                }

                Console.WriteLine($"{arr[Size - 1].Rubles}.{arr[Size - 1].Kopeks} ]");
                return true;
            }
            else
            {
                Console.WriteLine("В массиве нет элементов");
                return false;
            }
        }


        public Money FindMax()
        {
            if (this.Size != 0)
            {
                int Maxsum = 0;
                for (int i = 0; i < this.Size; i++)
                {
                    int tmpa = this[i].Rubles * 100 + this[i].Kopeks;
                    if (Maxsum < tmpa)
                    {
                        Maxsum = tmpa;
                    }
                }
                Money Max = new Money();
                int a = Maxsum / 100;
                Max.Rubles = a;
                Max.Kopeks = Maxsum - a * 100;
                return Max;
            }
            else
            {
                Money Max = new Money();
                return Max;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is MoneyArray)
            {
                MoneyArray arr = (MoneyArray)obj;
                bool ok = true;
                for(int i = 0; i < Size && ok; i++)
                {
                    if(this[i].Rubles == arr[i].Rubles && this[i].Kopeks == arr[i].Kopeks)
                    {
                        ok = true;
                    }
                    else
                    {
                        ok = false;
                    }
                }
                return ok;
            }
            return false;
        }
    }
}
