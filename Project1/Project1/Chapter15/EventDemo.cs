using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Chapter15
{

    class MyEvent
    {
        public event MyEventHandler SomeEvent;

        public void OnSomeEvent()
        {
            if (SomeEvent != null)
                SomeEvent();
        }
    }
    class EventDemo
    {
        static void Handler()
        {
            Console.WriteLine("Произошло событие");
        }

        public void run()
        {
            MyEvent evt = new MyEvent();

            evt.SomeEvent += Handler;

            evt.OnSomeEvent();
        }
    }
}
