using System;
using System.IO;

namespace UseTypeof
{
    class Program
    {
        static void Main()
        {
            Type t = typeof(StreamReader);

            Console.WriteLine(t.FullName);

            if (t.IsClass) Console.WriteLine("Относится к класcу.");
            if (t.IsAbstract) Console.WriteLine("Является абстрактным классом.");
            else Console.WriteLine("Является конкретным классом.");
            Console.ReadKey();
        }
    }
}
