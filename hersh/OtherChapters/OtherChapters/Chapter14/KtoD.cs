using System;
using System.IO;

namespace Project1.Chapter14
{
    class KtoD
    {
        public void run()
        {
            string str;
            FileStream fout;

            try
            {
                fout = new FileStream("test.txt", FileMode.Create);
            }
            catch (IOException exc)
            {
                Console.WriteLine("Ошибка откртия файла:\n{0}", exc.Message);
                return;
            }

            StreamWriter fstr_out = new StreamWriter(fout);

            try
            {
                Console.WriteLine("Введите текст, а по окончании - 'стоп'.");
                do
                {
                    Console.Write(": ");
                    str = Console.ReadLine();

                    if (str != "стоп")
                    {
                        str = str + "\r\n";
                        fstr_out.Write(str);
                    }
                } while (str != "стоп");
            }
            catch (IOException exc)
            {
                Console.WriteLine("Ошибка ввода-вывода:\n" + exc.Message);
            }
            finally
            {
                fstr_out.Close();
            }
        }
    }
}
