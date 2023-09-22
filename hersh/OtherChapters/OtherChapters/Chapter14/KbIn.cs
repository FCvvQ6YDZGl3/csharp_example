using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Chapter14
{
    class KbIn
    {
        public void run()
        {
            int ch;
            ch = 0;
            while (ch != 97)
            {
                Console.Write("Нажмите клавишу, а затем - <ENTER>: ");
                ch = Console.Read();
                Console.WriteLine("Вы нажали клавишу: " + ch);
            }
        }
    }
}
