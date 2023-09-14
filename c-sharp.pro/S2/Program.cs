using System;

namespace S2
{
    class Program
    {
        static double getNumberAndCheckFromConsole()
        {
            string answer;
            double number;
            answer = Console.ReadLine();

            if (!double.TryParse(answer, out number))
            {
                Console.WriteLine( "Вы ввели не число!");
                number = getNumberAndCheckFromConsole();
            }
            return number;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("S2.1");
            double xVar = 1.2;
            double yVar = 7 * Math.Pow(xVar, 2) + 3*xVar + 6;
            Console.WriteLine("y=7x^2+3x+6 при {0} равен {1}", xVar, yVar);

            Console.WriteLine();

            double aVar = 3;
            xVar = 12 * Math.Pow(aVar, 2) + 7 * aVar + 12;
            Console.WriteLine("x=12a^2+7a+12 при {0} равен {1}", aVar, xVar);

            Console.WriteLine("S2.2");
            double sideSquare = 3;
            Console.WriteLine("Периметр квадрата при стороне {0} равен {1}", sideSquare, sideSquare * 4);

            Console.WriteLine("S2.3");
            double rad = 3;
            Console.WriteLine("Диаметр окружности с радиусом {0} равен {1}", rad, rad * 2);

            Console.WriteLine("S2.4");
            const double earthRadius = 6350;
            double height = 200;

            Console.WriteLine("S2.5");
            double cubeEdge = 9;
            Console.WriteLine("Куб с длинной ребра {0} имеет объем {1} и площадь поверхности {2}", cubeEdge, Math.Pow(cubeEdge, 3)
                , Math.Pow(cubeEdge, 2));

            Console.WriteLine("S2.6");
            Console.WriteLine("Окружность радиусом {0} имеет длину {1} и площадь {2}", rad, 2 * Math.PI * rad, Math.PI * Math.Pow(rad, 2));

            Console.WriteLine("S2.7");
            xVar = getNumberAndCheckFromConsole();
            yVar = getNumberAndCheckFromConsole();
            Console.WriteLine("Среднее арифметическое чисел {0} и {1} равно {2}", xVar, yVar, (xVar + yVar) / 2);
            Console.WriteLine("Среднее геометрическое чисел {0} и {1} равно {2}", xVar, yVar, Math.Sqrt(xVar * yVar));

        }
    }
}
