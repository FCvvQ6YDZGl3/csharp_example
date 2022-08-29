using System;
using System.IO;

namespace Project1
{
    class WriteToFile
    {
        public void run()
        {
            FileStream fout = null;

            try
            {
                fout = new FileStream("test.txt", FileMode.CreateNew);
                int i = 0;
                while (i < 1)
                {
                    for (char c = 'A'; c <= 'Z'; c++)
                        fout.WriteByte((byte)c);
                    i++;
                }

            }
            catch (IOException exc)
            {
                Console.WriteLine("Ошибка ввода-вывода:\n" + exc.Message);
            }
            finally
            {
                if (fout != null) fout.Close();
            }
        }
    }
}
