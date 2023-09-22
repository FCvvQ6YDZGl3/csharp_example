using System;
using System.Globalization;

namespace stringExample
{
    class StrOps
    {
        string str1 = "Программировать в .NET лучше всего на C#.";
        string str2 = "Программировать в .NET лучше всего на C#.";
        string str3 = "Строки в C# весьма эффективны.";
        string strUp, strLow;
        int idx;

        public void run()
        {
            string output;
            Console.WriteLine("str1: " + str1);
            Console.WriteLine("Длина строки str1: " + str1.Length);

            strLow = str1.ToLower(CultureInfo.CurrentCulture);
            strUp = str1.ToUpper(CultureInfo.CurrentCulture);
            output = string.Format("Вариант строки str1, {0} набранный строчными буквами: \n {1}",
                str1,
                strLow);
            Console.WriteLine(output);
            output = string.Format("Вариант строки str1, {0} набранный прописными буквами: \n {1}",
                str1,
                strUp);
            Console.WriteLine(output);

            for (int i = 0; i < str1.Length; i++)
            {
                Console.Write(str1[i]);
            }
            Console.WriteLine();
            bool compareResult;
            compareResult = str1 == str2;
            if (compareResult)
                output = "str1 == str2";
            else
                output = "str1 != str2";
            Console.WriteLine(output);

            compareResult = str1 == str3;
            if (compareResult)
                output = "str1 == str3";
            else
                output = "str1 != str3";
            Console.WriteLine(output);

            int resultCompareOnCulture;
            resultCompareOnCulture = string.Compare(str3, str1, StringComparison.CurrentCulture);
            switch (resultCompareOnCulture) {
                case 0:
                    output = "Строки str1 и str3 равны";
                        break;
                case -1:
                    output = "Строка str1 меньше строки str3";
                    break;
                case 1:
                    output = "Строка str1 больше строки str3";
                    break;
            }
            Console.WriteLine(output);

            str2 = "Один Два Три Один";
            idx = str2.IndexOf("Один", StringComparison.Ordinal);
            output = string.Format("Индекс первого вхождения подстроки <Один>: {0}", idx);
            Console.WriteLine(output);
            idx = str2.LastIndexOf("Один", StringComparison.Ordinal);
            output = string.Format("Индекс последнего вхождения подстроки <Один>: {0}", idx);
            Console.WriteLine(output);

        }
    }
}