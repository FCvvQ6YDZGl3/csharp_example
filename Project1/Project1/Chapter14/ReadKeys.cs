using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Chapter14
{
    class ReadKeys
    {
        public void run()
        {
            ConsoleKeyInfo keypress;

            Console.WriteLine("Введите несколько символов, а по окончании - <Q>");

            do
            {
                keypress = Console.ReadKey();
                Console.WriteLine(" Вы нажали клавишу: " + keypress.KeyChar);

                if ((ConsoleModifiers.Alt & keypress.Modifiers) != 0)
                    Console.WriteLine("Нажата клавиша <Alt>.");
                if ((ConsoleModifiers.Control & keypress.Modifiers) != 0)
                    Console.WriteLine("Нажата клавиша <Control>.");
                if ((ConsoleModifiers.Shift & keypress.Modifiers) != 0)
                    Console.WriteLine("НаЙжата клавиша <Shift>.");
            } while (keypress.KeyChar != 'Q');
        }
    }
}
