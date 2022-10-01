using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectAssemblyDemo
{
    class MyClass
    {
        int x;
        int y;

        public MyClass(int i, int j)
        {
            x = i;
            y = j;
        }

        public int Sum()
        {
            return x + y;
        }
        public bool IsBetween(int i)
        {
            if (x < i && i < y) return true;
            else return false;
        }

        public void Set(int a, int b)
        {
            Console.Write("В методе Set(int, int). ");

            x = a;
            y = b;
            Show();
        }

        public void Set(double a, double b)
        {
            Console.Write("В методе Set(double, double). ");
            x = (int)a;
            y = (int)b;
            Show();
        }
        public void Show()
        {
            Console.WriteLine("Значение x: {0}, значение y: {1}", x, y);
        }
    }

    class AnotherClass
    {
        string msg;
        public AnotherClass(string str)
        {
            msg = str;
        }
        public void Show()
        {
            Console.WriteLine(msg);
        }
    }
    class Demo
    {
        /*static void Main()
        {
            Console.WriteLine("Это заполнитель.");
        }*/
    }
}
