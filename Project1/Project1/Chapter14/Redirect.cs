using System;
using System.IO;

namespace Project1.Chapter14
{
    class Redirect
    {
        public void run()
        {
            StreamWriter log_out = null;

            try
            {
                log_out = new StreamWriter("logfile.txt");

                Console.SetOut(log_out);
                Console.WriteLine("Это начало фалйа журнала регистрации.");

                for (int i = 0; i < 10; i++) Console.WriteLine(i);

                Console.WriteLine("Это конец файла журнала регистрации.");
            }
            catch (IOException exc)
            {
                Console.WriteLine("Ошибка ввода-вывода\n" + exc.Message);
            }
            finally
            {
                if (log_out != null) log_out.Close();
            }
        }
    }
}
