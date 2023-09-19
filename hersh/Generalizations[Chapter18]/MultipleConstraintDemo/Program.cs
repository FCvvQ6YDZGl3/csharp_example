using System;

namespace MultipleConstraintDemo
{
    class Gen<T, V> where T : class where V : struct
    {
        T ob1;
        V ob2;

        public Gen(T t, V v)
        {
            ob1 = t;
            ob2 = v;
        }
    }

    class MultipleConstraintDemo
    {
        static void Main()
        {
            Gen<string, int> obj = new Gen<string, int>("тест", 11);
        }

    }
}
