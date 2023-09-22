using System;

namespace Project1.Chapter15
{
    delegate void MyEventHandlerLambda(int n);
    class MyEventLambda
    {
        public event MyEventHandlerLambda SomeEvent;

        public void OnSomeEvent(int n)
        {
            if (SomeEvent != null)
            {
                SomeEvent(n);
            }
        }
    }
    class LambdaEventDemo
    {
        public void run()
        {
            MyEventLambda evt = new MyEventLambda();

            evt.SomeEvent += (n) =>
                Console.WriteLine("Событие получено. Значение равно " + n);

            evt.OnSomeEvent(1);
            evt.OnSomeEvent(2);
        }
    }
}