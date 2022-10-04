using System;

namespace GenericsDemo
{
    class Gen<T>
    {
        T ob;

        public Gen(T o)
        {
            ob = o;
        }
        public T GetOb()
        {
            return ob;
        }
        public void ShowType()
        {
            Console.WriteLine("К типу T относится " + typeof(T));
        }
    }
    class Program
    {
        static void Main()
        {
            Gen<int> iOb;

            iOb = new Gen<int>(102);

            iOb.ShowType();

            int v = iOb.GetOb();
            Console.WriteLine("Значение: " + v);

            Console.WriteLine();

            Gen<string> strOb = new Gen<string>("Обобщения повышают эффективность.");

            strOb.ShowType();

            string str = strOb.GetOb();
            Console.WriteLine("Значение: " + str);

            Console.ReadKey();
        }
    }
}
