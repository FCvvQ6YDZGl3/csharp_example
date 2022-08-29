using System;

class Factor
{
    public int[] FindFactor(int num, out int numfactors)
    {
        int[] facts = new int[80];
        int i, j;

        for (i = 2, j = 0; i < num / 2 + 1; i++)
        {
            if ((num % i) == 0)
            {
                facts[j] = i;
                j++;
            }
        }
        numfactors = j;
        return facts;
    }
}

class FindFactors
{
    public void run()
    {
        Factor f = new Factor();
        int numfactors;
        int[] factors;

        factors = f.FindFactor(1000, out numfactors);

        Console.WriteLine("Множители числа 1000: ");
        foreach (int value in factors)
            Console.Write(value + " ");

        Console.WriteLine();
    }
}