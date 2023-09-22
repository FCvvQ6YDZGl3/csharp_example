using System;

namespace DelegateEventLambdaExpression.Example
{
    class KeyEventArgs : EventArgs
    {
        public char ch;
    }
    class KeyEvent
    {
        public event EventHandler<KeyEventArgs> KeyPress;

        public void OnKeyPress(char key)
        {
            KeyEventArgs k = new KeyEventArgs();

            if (KeyPress != null)
            {
                k.ch = key;
                KeyPress(this, k);
            }
        }
    }

    class KeyEventDemo
    {
        public void run()
        {
            KeyEvent kevt = new KeyEvent();
            ConsoleKeyInfo key;
            int count = 0;

            kevt.KeyPress += (sender, e) =>
            Console.WriteLine(" Получено сообщение о нажатии клавиши: {0}", e.ch);

            kevt.KeyPress += (sender, e) =>
            count++;

            Console.WriteLine("Введите несколько символов. По завершении введите точку.");
            do
            {
                key = Console.ReadKey();
                kevt.OnKeyPress(key.KeyChar);
            } while (key.KeyChar != '.');

            Console.WriteLine("Было нажато " + count + " клавиш.");
            Console.ReadKey();
        }
    }
}
