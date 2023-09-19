using System;

namespace DefaultDemo
{
    class MyClass
    {

    }

    class Test<T>
    {
        public T obj;

        public Test()
        {
            //obj = null; не годится

            //obj = 0; не годится

            obj = default(T);
        }
    }

    class DefaultDemo
    {
        static void Main()
        {
            Test<MyClass> x = new Test<MyClass>();

            if (x.obj == null)
                Console.WriteLine("Переменная x.obj имеет значение <null>.");

            Test<int> y = new Test<int>();

            if (y.obj == 0)
                Console.WriteLine("Переменная y.obj имеет значение 0.");

            Console.ReadKey();
        }
    }
}
