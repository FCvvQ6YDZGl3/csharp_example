using System;
class StringArrays
{
    public void run()
    {
        string[] str = { "Это", "очень", "простой", "тест." };
        Console.WriteLine("Исходный массив: ");
        for (int i = 0; i < str.Length; i++)
        {
            Console.Write(str[i] + " ");
        }
        Console.WriteLine("\n");
        str[1] = "тоже";
        str[3] = "до предела тест!";

        Console.WriteLine("Видоизмененный массив: ");
        for (int i = 0; i < str.Length; i++)
        {
            Console.WriteLine(str[i] + " ");
        }
    }
}