using System;
using System.IO;

namespace Project1.Chapter14
{
    class ShowFile
    {
        public void run(string[] args)
        {
            int i;
            FileStream fin;

            if (args.Length != 1)
            {
                Console.WriteLine("Применение: ShowFile Файл");
                return;
            }
            try
            {
                fin = new FileStream(args[0], FileMode.Open);
            }
            catch (IOException exc)
            {
                Console.WriteLine("Не удается открыть файл");
                Console.WriteLine(exc.Message);
                return;
            }

            try
            {
                do
                {
                    i = fin.ReadByte();
                    if (i != -1) Console.Write((char)i);
                } while (i != -1);
            }
            catch (IOException exc)
            {
                Console.WriteLine("Ошибка чтения файла");
                Console.WriteLine(exc.Message);
            }
            finally
            {
                fin.Close();
            }
        }
    }
}