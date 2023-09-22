using System;

class Num
{
    public bool HasComFactor(int x, int y, out int least, out int greatest)
    {
        int i;
        int max = x < y ? x : y;
        bool first = true;

        least = 1;
        greatest = 1;

        for (i = 2; i <= max / 2 + 1; i++)
        {
            if (((y % i) == 0 & ((x % i) == 0)))
            {
                if (first)
                {
                    least = i;
                    first = false;
                }
                greatest = i;
            }
        }
        if (least != 1) return true;
        else return false;
    }
}

class DemoOut
{
    public void run()
    {
        Num ob = new Num();
        int lcf, gcf;

        if (ob.HasComFactor(231, 105, out lcf, out gcf))
        {
            Console.WriteLine("Наименьший общий множитель чисел 231 и 105 равен {0}", lcf);
            Console.WriteLine("Наибольший общий множитель чисел 231 и 105 равен {0}", gcf);
        }
        else
            Console.WriteLine("Общий множитель у чисел 231 и 105 отсутсвует.");

        if (ob.HasComFactor(35, 51, out lcf, out gcf))
        {
            Console.WriteLine("Наименьший общий множитель чисел 35 и 51 равен {0}", lcf);
            Console.WriteLine("Наибольший общий множитель чисел 35 и 51 равен {0}", gcf);
        }
        else
            Console.WriteLine("Общий множитель у чисел 35 и 51 отсутсвует.");
    }
}
