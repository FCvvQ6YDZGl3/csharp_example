using System;
using System.IO;
namespace Project1.Chapter14
{
    class RandomAccessDemo
    {
        public void run()
        {
            FileStream f = null;
            char ch;

            try
            {
                f = new FileStream("random.dat", FileMode.Create);
                for (int i = 0; i < 26; i++)
                    f.WriteByte((byte)('A' + i));

                f.Seek(0, SeekOrigin.Begin);
                ch = (char)f.ReadByte();
                Console.WriteLine("Первая буква: " + ch);

                f.Seek(1, SeekOrigin.Begin);
                ch = (char)f.ReadByte();
                Console.WriteLine("Вторая буква: " + ch);

                f.Seek(4, SeekOrigin.Begin);
                ch = (char)f.ReadByte();
                Console.WriteLine("Пятая буква: " + ch);

                Console.WriteLine();

                Console.WriteLine("Буквы алфавита черезз одну: ");
                for (int i = 0; i < 26; i += 2)
                {
                    f.Seek(i, SeekOrigin.Begin);
                    ch = (char)f.ReadByte();
                    Console.WriteLine(ch + " ");
                }
            }
            catch (IOException exc)
            {
                Console.WriteLine("Ошибка ввода-вывода\n" + exc.Message);
            }
            finally
            {
                if (f != null) f.Close();
            }

            Console.WriteLine();
        }
    }
}
