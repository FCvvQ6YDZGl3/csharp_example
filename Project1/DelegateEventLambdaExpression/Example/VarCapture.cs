using System;

namespace Project1.Chapter15
{

    class VarCapture
    {
        static CountIt Counter()
        {
            int sum = 0;

            CountIt ctObj = delegate (int end)
            {
                for (int i = 0; i <= end; i++)
                {
                    Console.WriteLine(i);
                    sum += i;
                }
                return sum;
            };
            return ctObj;
        }
        public void run()
        {
            CountIt count = Counter();

            int result;

            result = count(3);
            Console.WriteLine("Сумма 3 равна " + result);
            Console.WriteLine();

            //count = Counter();
            result = count(5);
            Console.WriteLine("Сумма 5 равна " + result);
        }
    }
}
