using System;
using System.Linq;

namespace LinqSelect
{
    class ChrPair
    {
        public char First;
        public char Second;
        public ChrPair(char c, char c2)
        {
            First = c;
            Second = c2;
        }
    }
    internal class MultipleFroms
    {
        public static void main()
        {
            char[] chrs = { 'A', 'B', 'C' };
            char[] chrs2 = { 'X', 'Y', 'Z' };

            var pairs = from ch1 in chrs
                        from ch2 in chrs2
                        select new ChrPair(ch1, ch2);

            Console.WriteLine("Все сочетания букв ABC и XYZ: ");
            foreach(var p in pairs)
            {
                Console.WriteLine("{0} {1}", p.First, p.Second);
            }
        }
    }
}
