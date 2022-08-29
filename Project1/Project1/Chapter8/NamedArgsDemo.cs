using System;

class NamedArgsDemo
{
    private bool IsFactor(int val, int divisor)
    {
        if ((val % divisor) == 0) return true;
        return false;
    }
    private void IfIsFactorShowResult(int val, int divisior)
    {
        if (IsFactor(val, divisior))
            Console.WriteLine("{0} - множитель {1}.", divisior, val);
    }
    public void run()
    {
        IfIsFactorShowResult(10, 2);
        IfIsFactorShowResult(val: 10, divisior: 2);
        IfIsFactorShowResult(divisior: 2, val: 10);
        IfIsFactorShowResult(10, divisior: 2);
    }
}