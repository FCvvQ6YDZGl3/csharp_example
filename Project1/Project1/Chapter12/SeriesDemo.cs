using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Chapter12
{
    public interface ISeries
    {
        int GetNext();
        void Reset();
        void SetStart(int x);
    }

    class ByTwos : ISeries
    {
        int start;
        int val;
        int prev;

        public ByTwos()
        {
            start = 0;
            val = 0;
        }

        public int GetNext()
        {
            val += 2;
            return val;
        }

        public void Reset()
        {
            val = start;
        }

        public void SetStart(int x)
        {
            start = x;
            val = start;
        }
        public int GetPrevious()
        {
            return prev;
        }
    }

    class Primes : ISeries
    {
        int start;
        int val;

        public Primes()
        {
            start = 2;
            val = 2;
        }

        public int GetNext()
        {
            int i, j;
            bool isprime;

            val++;
            for (i = val; i < 1000000; i++)
            {
                isprime = true;
                for (j = 2; j <= i / j; j++)
                {
                    if ((i % j) == 0)
                    {
                        isprime = false;
                        break;
                    }
                }
                if (isprime)
                {
                    val = i;
                    break;
                }
            }
            return val;
        }
        public void Reset()
        {
            val = start;
        }

        public void SetStart(int x)
        {
            start = x;
            val = start;
        }
    }

    class SeriesDemo
    {
        public void run()
        {
            ByTwos twoOb = new ByTwos();
            Primes primeOb = new Primes();
            ISeries ob;

            for (int i = 0; i < 5; i++)
            {
                ob = twoOb;
                Console.WriteLine("Следующее четное число равно " + ob.GetNext());

                ob = primeOb;
                Console.WriteLine("Следующее простое число равно " + ob.GetNext());
            }
        }
    }
}
