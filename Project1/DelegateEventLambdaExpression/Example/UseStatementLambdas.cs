using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Chapter15
{
    class UseStatementLambdas
    {
        public delegate string StrMod(string s);
        public void run()
        {
            StrMod ReplaceSpaces = s =>
            {
                Console.WriteLine("Замена пробелов деффисами.");
                return s.Replace(' ', '-');
            };

            StrMod RemoveSpaces = s =>
            {
                string temp = "";
                int i;

                Console.WriteLine("Удаление пробелов.");
                for (i = 0; i < s.Length; i++)
                    if (s[i] != ' ') temp += s[i];
                return temp;
            };

            StrMod Reverse = s =>
            {
                string temp = "";
                int i, j;

                Console.WriteLine("Обращение строки.");
                for (j = 0, i = s.Length - 1; i >= 0; i--, j++)
                    temp += s[i];

                return temp;
            };

            string str;

            StrMod strOp = ReplaceSpaces;
            str = strOp("Это простой тест.");
            Console.WriteLine("Результирующая строка: " + str);
            Console.WriteLine();

            strOp = RemoveSpaces;
            str = strOp("Это простой тест.");
            Console.WriteLine("Результирующая строка: " + str);
            Console.WriteLine();

            strOp = Reverse;
            str = strOp("Это простой тест.");
            Console.WriteLine("Результирующая строка: " + str);
            Console.WriteLine();
        }
    }
}
