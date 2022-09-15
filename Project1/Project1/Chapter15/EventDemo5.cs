using System;

namespace Project1.Chapter15
{
    delegate void MyEventHandler();
    class MyEventAccessor
    {
        MyEventHandler[] evnt = new MyEventHandler[3];

        public event MyEventHandler SomeEvent
        {
            add
            {
                int i;
                for (i = 0; i < 3; i++)
                    if (evnt[i] == null)
                    {
                        evnt[i] = value;
                        break;
                    }
                if (i == 3) Console.WriteLine("Список событий заполнен.");
            }
            remove
            {
                int i;

                for (i = 0; i < 3; i++)
                    if (evnt[i] == value)
                    {
                        evnt[i] = null;
                        break;
                    }
                if (i == 3) Console.WriteLine("Обработчик событий не найден.");
            }
        }
        public void OnSomeEvent()
        {
            for (int i = 0; i < 3; i++)
                if (evnt[i] != null) evnt[i]();
        }
    }
    class W
    {
        public void Whandler()
        {
            Console.WriteLine("Событие получено объектом W");
        }
    }
    class G
    {
        public void Ghandler()
        {
            Console.WriteLine("Событие получено объектом G");
        }
    }
    class J
    {
        public void Jhandler()
        {
            Console.WriteLine("Событие получно объектом J");
        }
    }
    class Z
    {
        public void Zhandler()
        {
            Console.WriteLine("Событие получено объектом Z");
        }
    }

    class EventDemo5
    {
        public void run()
        {
            MyEventAccessor evt = new MyEventAccessor();
            W wOb = new W();
            G gOb = new G();
            J jOb = new J();
            Z zOb = new Z();

            Console.WriteLine("Добавление событий.");
            evt.SomeEvent += wOb.Whandler;
            evt.SomeEvent += gOb.Ghandler;
            evt.SomeEvent += jOb.Jhandler;

            evt.SomeEvent += zOb.Zhandler;
            Console.WriteLine();

            evt.OnSomeEvent();
            Console.WriteLine();

            Console.WriteLine("Удаление обработчика gOb.Ghandler");
            evt.SomeEvent -= gOb.Ghandler;
            evt.OnSomeEvent();

            Console.WriteLine();

            Console.WriteLine("Попытка удалить обработчик еще раз gOb.ghandler еше раз.");
            evt.SomeEvent -= gOb.Ghandler;
            evt.OnSomeEvent();

            Console.WriteLine();

            Console.WriteLine("Добавление обработчика zOb.Zhandler.");
            evt.SomeEvent += zOb.Zhandler;
            evt.OnSomeEvent();
        }
    }
}
