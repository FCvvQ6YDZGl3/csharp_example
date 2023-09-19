#define EXPERIMENTAL

using System;

class Test
{
    static void Main()
    {
#if EXPERIMENTAL
        Console.WriteLine("Компилируется для экспериментальной версии.");
#endif
        Console.WriteLine("Присутствует во всех версиях");
    }
}