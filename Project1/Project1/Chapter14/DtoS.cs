using System;
using System.IO;

namespace Project1.Chapter14
{
    class DtoS
    {
        public void run()
        {
            FileStream fin;
            string s;

            try
            {
                fin = new FileStream("test.txt", FileMode.Open);
            }
            catch (IOException exc)
            {
                Console.WriteLine("Ошибка открытия файла:\n" + exc.Message);
                return;
            }

            StreamReader fstr_in = new StreamReader(fin);

            try
            {
                while ((s = fstr_in.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
            catch (IOException exc)
            {
                Console.WriteLine("Ошибка ввода-вывода:\n" + exc.Message);
            }
            finally
            {
                fstr_in.Close();
            }
        }
    }
}