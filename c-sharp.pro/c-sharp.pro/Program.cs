using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp.pro
{
    class Tabulator
    {
        int rowLength;

        public void viewTable (string[] elements)
        {
            int rowIndex = 1;
            Console.WriteLine();
            foreach(string n in elements)
            {
                Console.Write(n + " ");
                if (rowIndex == rowLength)
                {
                    Console.WriteLine();
                    rowIndex = 0;
                }
                rowIndex++;
            }
        }
        public Tabulator(int rl)
        {
            rowLength = rl;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Tabulator t;

            t = new Tabulator(2);
            string answer;
            string query;
            double number;
            answer = "";
            string[] numbers = { "2", "кг", "13", "17"};


            /*
            foreach(string n in numbers)
            {
                //answer += n.ToString() + " ";
                Console.WriteLine(n);
            }*/
            t.viewTable(numbers);
            //Console.WriteLine(answer);

            answer = Console.ReadLine();

            if (double.TryParse(answer, out number))
                answer = number.ToString() + " — вот какое число Вы  ввели";
            else
                answer = "Вы ввели не число!";

            Console.WriteLine(answer);
        }
    }
}
