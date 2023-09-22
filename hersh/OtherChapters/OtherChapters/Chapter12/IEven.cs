using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Chapter12
{
    interface IEven
    {
        bool IsOdd(int x);
        bool IsEven(int x);
    }
    class MyClass : IEven
    {
        bool IEven.IsOdd(int x)
        {
            if ((x % 2) != 0) return true;
            else return false;
        }

        public bool IsEven(int x)
        {
            IEven o = this;
            return !o.IsOdd(x);
        }
    }
}
