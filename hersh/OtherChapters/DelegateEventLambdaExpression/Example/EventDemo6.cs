using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateEventLambdaExpression.Example
{
    class MyEventArgs : EventArgs
    {
        public int EventNum;
    }
    delegate void MyEventHandler(object source, MyEventArgs arg);
    class MyEvent
    {
        static int count = 0;
        public event MyEventHandler SomeEvent;

        public void OnSomeEvent()
        {
            MyEventArgs arg = new MyEventArgs();
            if (SomeEvent != null)
            {
                arg.EventNum = count++;
                SomeEvent(this, arg);
            }
        }
    }
    class X
    {
        public void Handler(object source, MyEventArgs arg)
        {
            Console.WriteLine("Событие {0} получено объектом класса X.", arg.EventNum);
            Console.WriteLine("Источник: {0}", source);
            Console.WriteLine();
        }
    }
    class Y
    {
        public void Handler(object source, MyEventArgs arg)
        {
            Console.WriteLine("Событие {0} получено объектом класса Y.", arg.EventNum);
            Console.WriteLine("Источник: {0}", source);
            Console.WriteLine();
        }
    }
    class EventDemo6
    {
        public void run()
        {
            X ob1 = new X();
            Y ob2 = new Y();
            MyEvent evt = new MyEvent();

            evt.SomeEvent += ob1.Handler;
            evt.SomeEvent += ob2.Handler;

            evt.OnSomeEvent();
            evt.OnSomeEvent();

            Console.ReadKey();
        }
    }
}
