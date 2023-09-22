using System;
using Project1.Chapter15;

namespace DelegateEventLambdaExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            VarCapture runableObject = new VarCapture();
            runableObject.run();
            Console.ReadKey();
        }
    }
}
