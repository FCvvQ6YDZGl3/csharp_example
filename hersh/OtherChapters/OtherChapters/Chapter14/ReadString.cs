using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Chapter14
{
    class ReadString
    {
        public void run()
        {
            string str;

            Console.WriteLine("Введите несколько символов.");
            str = Console.ReadLine();
            Console.WriteLine("Вы ввели: " + str);
        }
    }
}
