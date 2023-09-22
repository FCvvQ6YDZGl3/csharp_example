using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Chapter14
{
    class ReadChars2
    {
        public void run()
        {
            string str;
            Console.WriteLine("Введите несколько символов.");
            str = Console.In.ReadLine();
            Console.WriteLine("Вы ввели: " + str);
        }
    }
}
