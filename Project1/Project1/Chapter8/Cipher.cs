using System;

class Chiper
{
    static int Main_(string[] args)
    {
        if (args == null | args.Length == 0)
            return 1;
        if (args.Length < 2)
        {
            Console.WriteLine("ПРИМЕНЕНИЕ: " +
                "слово1: <зашифровать>/<расшифровать> " +
                "[слово2... словоN]");
        }
        if (args[0] != "зашифровать" & args[0] != "расшифровать")
        {
            Console.WriteLine("Первым аргументом должно быть слово " +
                "<зашифровать> или <расшифровать>");
            return 1;
        }
        for (int n = 1; n < args.Length; n++)
        {
            for (int i = 0; i < args[n].Length; i++)
            {
                if (args[0] == "зашифровать")
                    Console.Write((char)(args[n][i] + 1));
                else
                    Console.Write((char)(args[n][i] - 1));
            }
            Console.WriteLine(" ");
        }

        Console.WriteLine();

        return 0;
    }
}