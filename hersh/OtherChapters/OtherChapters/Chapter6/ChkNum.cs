using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Chapter6
{
    class ChkNum
    {
        public bool IsPrime(int x)
        {
            if (x <= 1) return false;

            for (int i = 2; i <= x / i; i++)
            {
                if ((x % i) == 0) return false;
            }
            return true;
        }
        public int LeastComFactor(int a, int b)
        {
            int max;

            if (IsPrime(a) || IsPrime(b)) return 1;

            max = a < b ? a : b;

            for (int i = 2; i <= max / 2; i++)
                if (((a % i) == 0) && ((b % i) == 0)) return i;
            return 1;
        }

        public void checkAndWriteLeastComFactor(int a, int b)
        {
            Console.WriteLine("Наименьший общий множитель чисел " +
                a + " и " + b + " равен " + this.LeastComFactor(a, b));
        }
    }
}
