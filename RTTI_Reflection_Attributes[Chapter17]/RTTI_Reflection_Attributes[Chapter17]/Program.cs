using System;

namespace RTTI_Reflection_Attributes_Chapter17_
{
    class A { };
    class B { };
    class UseIs
    {
        static void Main()
        {
            A a = new A();
            B b = new B();
            if (a is A)
                Console.WriteLine("а имеет тип A");
            if (b is A)
                Console.WriteLine("b совместим с A, поскольку он производный от A");
            if (a is B)
                Console.WriteLine("Не выводится, посльку a не производный от B");

            if (b is B)
                Console.WriteLine("B имеет тип B");
            if (a is object)
                Console.WriteLine("a имеет тип object");
        }
    }
}
