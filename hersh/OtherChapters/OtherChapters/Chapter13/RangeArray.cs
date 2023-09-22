using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Chapter13
{
    class RangeArrayException : Exception
    {
        public RangeArrayException() : base() { }
        public RangeArrayException(string str) : base(str) { }
        public RangeArrayException(string str, Exception inner) : base(str, inner) { }
        protected RangeArrayException(
            System.Runtime.Serialization.SerializationInfo si,
            System.Runtime.Serialization.StreamingContext sc) :
                base(si, sc)
        { }
        public override string ToString()
        {
            return Message;
        }
    }
    class RangeArray
    {
        int[] a;
        int lowerBound;
        int upperBound;

        public int Length { get; private set;}
        public RangeArray(int low, int high)
        {
            high++;
            if (high <= low)
            {
                throw new RangeArrayException("Нижний индекс не меньше верхнего.");
            }
            a = new int[high - low];
            Length = high - low;

            lowerBound = low;
            upperBound = --high;
        }

        public int this[int index]
        {
            get
            {
                if (ok(index))
                {
                    return a[index - lowerBound];
                }
                else
                {
                    throw new RangeArrayException("Ошибка нарушения границ.");
                }
            }
            set
            {
                if (ok(index))
                {
                    a[index - lowerBound] = value;
                }
                else throw new RangeArrayException("Ошибка нарушения границ.");
            }
        }
        private bool ok(int index)
        {
            if (index >= lowerBound & index <= upperBound) return true;
            return false;
        }
    }
    class RangeArrayDemo
    {
        public void run()
        {
            try
            {
                RangeArray ra = new RangeArray(-5, 5);
                RangeArray ra2 = new RangeArray(1, 10);

                Console.WriteLine("Длина массива ra: " + ra.Length);
                for (int i = -5; i <= 5; i++)
                    ra[i] = i;

                Console.Write("Содержимое массива ra: ");
                for (int i = -5; i <= 5; i++)
                    Console.Write(ra[i] + " ");

                Console.WriteLine("\n");

                Console.WriteLine("Длина массива ra2: " + ra2.Length);
                for (int i = 1; i <= 10; i++)
                    ra2[i] = i;

                Console.Write("Содержимое массива ra2: ");
                for (int i = 1; i <= 10; i++)
                    Console.Write(ra2[i] + " ");

                Console.WriteLine("\n");
            }
            catch (RangeArrayException exc)
            {
                Console.WriteLine(exc);
            }

            Console.WriteLine("Сгенерировать ошибки нарушения границ.");

            try
            {
                RangeArray ra3 = new RangeArray(100, -10);
            }
            catch (RangeArrayException exc) {
                Console.WriteLine(exc);
            }

            try
            {
                RangeArray ra3 = new RangeArray(-2, 2);

                for (int i = -2; i <= 2; i++)
                    ra3[i] = i;

                Console.Write("Содержимое массива ra3: ");
                for (int i = -2; i <= 10; i++)
                    Console.Write(ra3[i] + " ");
            }
            catch (RangeArrayException exc)
            {
                Console.WriteLine(exc);
            }
            try
            {
                RangeArrayException excExample = new RangeArrayException();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
        }
    }
}