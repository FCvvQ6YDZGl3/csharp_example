using System;
using System.Linq;

namespace LinqSelect
{
    internal class SelectDemo
    {
        public static void main()
        {
            double[] nums =
            {-10.0, 16.4, 12.125, 100.85, -2.2, 25.25, -3.5};

            var sqrRoots = from n in nums
                           where n > 0
                           select Math.Sqrt(n);

            Console.WriteLine("Квадратные корни положительных значений,\n" +
                "округление до двух десятичных цифр:");
            foreach (double r in sqrRoots)
                Console.WriteLine("{0:#.##}", r);
        }
    }
}
