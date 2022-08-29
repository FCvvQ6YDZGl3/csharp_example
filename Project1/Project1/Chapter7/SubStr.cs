using System;
class SubStr
{
    public void run()
    {
        string orgstr = "В C# упрощается обращение со строками.";
        string substr = orgstr.Substring(5, 20);
        Console.WriteLine("orgstr: " + orgstr);
        Console.WriteLine("substr: " + substr);
    }
}