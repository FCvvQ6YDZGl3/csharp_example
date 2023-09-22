using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Chapter7
{
    class Array
    {
        public void array_simple()
        {
            const int offset = 1;
            int array_size = 128;
            int[] array;
            array = new int[array_size];
            Console.WriteLine("Объявили массив целых чисел");
            Console.WriteLine("Вывод массива целых чисел");
            for (int i = 0; i < array.Length; i++) array[i] = i + offset;
            foreach (int value in array) Console.Write(value + " ");
        }

        public void array_two_dimensional()
        {
            const int offset = 1;
            int size_a = 40;
            int size_b = 40;
            int[,] array = new int[size_a, size_b];
            int left_padding = ((size_a -  offset) * (size_b - offset) - (size_b - offset) / (size_a) + (size_a - offset) + (size_b - offset)).ToString().Length;
            /*Console.WriteLine("Объявили двумерный массив целых чисел");
            Console.WriteLine("Вывод двумерного массива целых чисел");*/
            string value;
            for (int a = 0, b = 0; a < size_a; a = (b == size_b - offset) ? ++a : a, b = (b < size_b - offset) ? ++b : 0) array[a, b] = a * b - b / (a+offset) + a + b;
            for (int a = 0, b = 0; a < size_a; a = (b == size_b - offset) ? ++a : a, b = (b < size_b - offset) ? ++b : 0)
            {
                value = array[a, b].ToString().PadLeft(left_padding, '0') + " ";

                if (!(b < size_b - offset))
                {
                    Console.WriteLine(value);
                    Console.WriteLine();
                }
                else Console.Write(value);
            }
        }

        public void array_jagged()
        {
            const int offset = 1;
            int[] array_size_x = { 5, 6, 7, 8, 3, 5, 4, 9, 9, 4, 2, 9, 7, 7, 5, 6, 7, 8, 3, 5, 4, 9, 9, 4, 2, 9, 7, 7, 5, 6, 7, 8, 3, 5, 4, 9, 9, 4, 2, 9, 7, 7 };
            int size_y = array_size_x.Length;
            int[][] array_jagged = new int[size_y][];
            for (int i = 0; i < array_size_x.Length; i++) array_jagged[i] = new int[array_size_x[i]];
            for (int a = 0, b = 0, size_b = array_size_x[a], size_a = size_y; a < size_a; a = (b == size_b - offset) ? ++a : a, b = (b < size_b - offset) ? ++b : 0)
            {
                array_jagged[a][b] = a * b - b / (a + offset) + a + b;
                size_b = array_size_x[a];
            }
            string value;
            for (int a = 0, b = 0, size_b = array_size_x[a], size_a = size_y; a < size_a; a = (b == size_b - offset) ? ++a : a, b = (b < size_b - offset) ? ++b : 0)
            {
                value = array_jagged[a][b].ToString().PadLeft(3, '0') + " ";

                if (!(b < size_b - offset))
                {
                    Console.WriteLine(value);
                    Console.WriteLine();
                }
                else Console.Write(value);
                size_b = array_size_x[a];
            }
        }
    }
}
