using System;
class ConvertDigitsToWords
{
    public void run()
    {
        int num;
        int nextdigit;
        int numdigits;
        int[] n = new int[20];

        string[] digits = {"нуль","один","два","три",
            "четыре","пять","шесть","семь","восемь","девять" };
        num = 1908;

        Console.WriteLine("Число: " + num);
        Console.Write("Число словами: ");

        nextdigit = 0;
        numdigits = 0;

        do
        {
            nextdigit = num % 10;
            n[numdigits] = nextdigit;
            numdigits++;
            num = num / 10;
        } while (num > 0);
        numdigits--;
        for (; numdigits >= 0; numdigits--)
            Console.Write(digits[n[numdigits]] + " ");
        Console.WriteLine();
    }
}