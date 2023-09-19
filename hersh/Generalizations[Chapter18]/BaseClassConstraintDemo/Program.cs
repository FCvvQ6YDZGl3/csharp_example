using System;

namespace BaseClassConstraintDemo
{
    class A
    {
        public void Hello()
        {
            Console.WriteLine("Hello");
        }
    }
    class B : A { }

    class C { }

    class Test<T> where T : A
    {
        T obj;

        public Test(T o)
        {
            obj = o;
        }

        public void SayHello()
        {
            obj.Hello();
        }
    }

    class BaseClassConstraintDemo
    {
        static void Main()
        {
            A a = new A();
            B b = new B();
            C c = new C();

            Test<A> t1 = new Test<A>(a);

            t1.SayHello();

            Test<B> t2 = new Test<B>(b);

            t2.SayHello();

            //Test<C> t3 = new Test<C>(c);
            //t3.SayHello();
            Console.ReadKey();
        }
    }
}
