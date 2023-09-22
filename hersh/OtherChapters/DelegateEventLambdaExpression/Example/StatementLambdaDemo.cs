using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Chapter15
{
    class StatementLambdaDemo
    {
        delegate int IntOp(int end);
        public void run()
        {
            IntOp fact = n =>
            {
                int r = 1;
                for (int i = 1; i <= n; i++)
                    r = i * r;
                return r;
            };

            Console.WriteLine("Факториал 3 равен " + fact(3));
            Console.WriteLine("Факториал 5 равен " + fact(5));
        }
    }
}
