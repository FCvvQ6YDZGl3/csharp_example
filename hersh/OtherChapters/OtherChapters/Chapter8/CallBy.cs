using System;

namespace CallBy
{
    class Test
    {
        public void NoChange(int i, int j)
        {
            i = i + j;
            j = -j;
        }
    }

    class CallBy
    {
        public void run()
        {
            Test ob = new Test();

            int a = 15, b = 20;

            Console.WriteLine("a и b до вызова: {0} {1}", a, b);

            ob.NoChange(a, b);

            Console.WriteLine("a и b после вызова: {0} {1}", a, b);
        }
    }

    class TestObject
    {
        public int a, b;

        public TestObject(int i, int j)
        {
            a = i;
            b = j;
        }
        public void change(TestObject ob)
        {
            ob.a = ob.a + ob.b;
            ob.b = -ob.b;
        }
    }
    class CallByRef
    {
        public void run()
        {
            TestObject ob = new TestObject(15, 20);

            Console.WriteLine("a и b до вызова: {0} {1}", ob.a, ob.b);

            ob.change(ob);

            Console.WriteLine("a и b после вызова: {0} {1}", ob.a, ob.b);
        }
    }
}