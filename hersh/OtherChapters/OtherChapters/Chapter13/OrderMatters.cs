using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Chapter13
{
    class ExceptA : Exception
    {
        public ExceptA(string str) : base(str) { }
        public override string ToString()
        {
            return Message;
        }
    }
    class ExceptB : ExceptA
    {
        public ExceptB(string str) : base(str) { }
    }
    class ExceptA_A : ExceptA
    {
        public ExceptA_A(string str) : base(str) { }
    }
    class OrderMatters
    {
        public void run()
        {
            for (int x = 0; x < 3; x++)
                try
                {
                    if (x == 0) throw new ExceptA("Перехват исключения типа ExceptA");
                    else if (x == 1) throw new ExceptB("Перехват исключения типа ExceptB");
                    else throw new Exception();
                }
                catch (ExceptA_A exc)
                {
                    Console.WriteLine(exc);
                }
                catch (ExceptB exc)
                {
                    Console.WriteLine(exc);
                }
                catch (ExceptA exc)
                {
                    Console.WriteLine(exc);
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc);
                }
        }
    }
}
