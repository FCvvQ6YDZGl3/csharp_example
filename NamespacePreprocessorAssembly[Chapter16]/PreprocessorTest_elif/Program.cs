#define RELEASE
using System;

namespace PreprocessorTest_elif
{
    class Program
    {
        static void Main()
        {
        #if EXPERIMENTAL
            Console.WriteLine("Компилируется для экспериментальной версии");
        #elif RELEASE
            Console.WriteLine("Компилируется для окончательной версии");
        #else
            Console.WriteLine("Компилируется для внутреннего тестирования");
        #endif

        #if TRIAL && !RELEASE
            Console.WriteLine("Пробная версия.");
        #endif
            Console.WriteLine("Присутствует во всех версиях");
        }
    }
}