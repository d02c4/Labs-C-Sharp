using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class Money
    {
        static public int count = 0;

        private int rubles;

        private int kopeks;


        public int Count
        {
            get
            {
                return count;
            }
        }


        public int Rubles
        {
            get
            {
                return rubles;
            }

            set
            {
                if (value > 0)
                    rubles = value;
                else
                    rubles = 0;
            }
        }

        public int Kopeks
        {
            get
            {
                return kopeks;
            }
            set
            {
                if (value < 0)
                    kopeks = 0;
                else if (value >= 100)
                {
                    rubles += value / 100;
                    kopeks = value - value / 100 * 100;
                }
                else
                {
                    kopeks = value;
                }
            }
        }

        public Money()
        {
            count++;
            this.rubles = 0;
            this.kopeks = 0;
        }

        static public Money Minus1(Money this1, Money other)
        {
            int tmpThis = this1.Rubles * 100 + this1.Kopeks;
            int tmpOther = other.Rubles * 100 + other.Kopeks;
            tmpThis -= tmpOther;
            this1.Rubles = 0;
            this1.Kopeks = tmpThis;
            return this1;
        }

        public Money Minus(Money this1, Money other)
        {
            Money a = Minus1(this1, other);
            return a;
        }

        public Money(double money)
        {
            count++;
            int tmp = (int)(money * 100);
            this.Rubles = 0;
            this.Kopeks = tmp;
        }

        public Money(int rubles, int kopeks)
        {
            count++;
            this.Rubles = rubles;
            this.Kopeks = kopeks;
        }

      
        public string Show()
        {
            Console.WriteLine($"{this.rubles} рублей {this.kopeks} копеек");
            string buf = $"{this.rubles} рублей {this.kopeks} копеек";
            return buf;
        }


        public static Money operator -(Money a, int b)
        {
            int tmp = a.Rubles * 100 + a.Kopeks;
            tmp -= b;
            a.Rubles = 0;
            a.Kopeks = tmp;
            return a;
        }


        public static Money operator -(Money a, Money b)
        {
            int tmpa = a.Rubles * 100 + a.Kopeks;
            int tmpb = b.Rubles * 100 + b.Kopeks;
            tmpa -= tmpb;
            a.Rubles = 0;
            a.Kopeks = tmpa;
            return a;
        }

        public static Money operator ++(Money a)
        {
            a.Kopeks++;
            return a;
        }

        public static Money operator --(Money a)
        {
            if (a.kopeks == 0)
            {
                if (a.Rubles != 0)
                {
                    a.Kopeks = 99;
                    a.Rubles--;
                }
                else
                {
                    a.Kopeks = 0;
                    a.Kopeks = 0;
                }
            }
            else
            {
                a.Kopeks--;
            }
            return a;
        }


        public static implicit operator int(Money a)
        {
            return a.rubles;
        }

        public static explicit operator double(Money a)
        {
            double tmp = (double)a.Kopeks / 100;
            return tmp;
        }

        public override bool Equals(object obj)
        {
            if(obj is Money)
            {
                Money m = (Money)obj;
                return Rubles == m.Rubles && Kopeks == m.Kopeks;
            }
            return false;
        }
    }

}
