using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Chapter13
{
    class ExcTest
    {
        public static void GenException()
        {
            int[] nums = new int[4];

            Console.WriteLine("До генерирования исключения.");
            for (int i = 0; i < 10; i++)
            {
                nums[i] = i;
                Console.WriteLine("nums[(0)]: {1}", i, nums[i]);
            }

            Console.WriteLine("Не подлежит выводу");
        }
    }
    class UseExcept
    {
        public void run()
        {
            try
            {
                ExcTest.GenException();
            }
            catch (IndexOutOfRangeException exc)
            {
                Console.WriteLine("Стандартное сообщение таково: ");
                Console.WriteLine(exc);
                Console.WriteLine("Свойство {0}:\n\r {1}", "StackTrace", exc.StackTrace);
                Console.WriteLine("Свойство {0}: {1}", "Message", exc.Message);
                Console.WriteLine("Свойство {0}: {1}", "TargetSite", exc.TargetSite);
            }
        }
    }
}
