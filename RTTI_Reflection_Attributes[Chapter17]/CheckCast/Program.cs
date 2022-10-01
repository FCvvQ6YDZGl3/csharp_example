using System;

namespace CheckCast
{
    class A { };
    class B : A { };
    class CheckCast
    {
        static void Main()
        {
            A a = new A();
            B b = new B();

            b = a as B;
            if (b == null)
                Console.WriteLine("Приведение типов b = (B) НЕ допустимо.");
            else
                Console.WriteLine("Приведение типов b = (B) допустмо.");

            Console.ReadKey();
        }
    }
}