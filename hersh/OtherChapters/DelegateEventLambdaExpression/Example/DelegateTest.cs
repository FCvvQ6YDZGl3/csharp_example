using System;
using System.Collections.Generic;

namespace Project1.Chapter15
{
    public delegate void StrMod(ref string str);
    class MultiCastDemo
    {
        static public void ReplaceSpaces(ref string s)
        {
            Console.WriteLine("Замена пробелов деффисами.");
            s = s.Replace(' ', '-');
        }

        static public void RemoveSpaces(ref string s)
        {
            string temp = "";
            int i;

            Console.WriteLine("Удаление пробелов.");
            for (i = 0; i < s.Length; i++)
                if (s[i] != ' ') temp += s[i];
            s = temp;
        }

        static public void Reverse(ref string s)
        {
            string temp = "";
            int i, j;

            Console.WriteLine("Обращение строки.");
            for (j = 0, i = s.Length - 1; i >= 0; i--, j++)
                temp += s[i];

            s = temp;
        }
        
    }

    class DelegateTestRunable
    {
        public void run()
        {
            StrMod strOp;
            StrMod replaceSp = MultiCastDemo.ReplaceSpaces;
            StrMod removeSp = MultiCastDemo.RemoveSpaces;
            StrMod reverseStr = MultiCastDemo.Reverse;
            string str = "Это простой тест.";

            strOp = replaceSp;
            strOp += reverseStr;

            strOp(ref str);
            Console.WriteLine("Результирующая строка: " + str);
            Console.WriteLine();

            strOp -= replaceSp;
            strOp += removeSp;
            str = "Это простой тест.";

            strOp(ref str);
            Console.WriteLine("Результирующая строка: " + str);
            Console.WriteLine();
        }        
    }
}
