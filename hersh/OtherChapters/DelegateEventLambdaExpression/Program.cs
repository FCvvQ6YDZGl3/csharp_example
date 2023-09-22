using System;
using Project1.Chapter15;
using DelegateEventLambdaExpression.Example;

namespace DelegateEventLambdaExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            KeyEventDemo runableObject = new KeyEventDemo();
            runableObject.run();
            Console.ReadKey();
        }
    }
}
