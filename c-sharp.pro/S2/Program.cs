using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace S2
{
    delegate void RunProgrammExercise();
    delegate void Calculate();

    class Exercise
    {
        private Calculate calculate;
        private RunProgrammExercise runProgrammExercise;
        List<double> args;
        public Exercise(Calculate calc)
        {
            
            calculate = calc;
        }
    }

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

        static string getExerciseNumberAndCheckFromConsole()
        {
            string answer;
            Console.WriteLine("Укажите номер упражнения в формате S<номер_пункта>.<номер_подпункта>");
            answer = Console.ReadLine();
            Regex regex = new Regex(@"S[0-9]+.[0-9]+");
            if (!regex.Match(answer).Success)
            {
                answer = getExerciseNumberAndCheckFromConsole();
            }
            return answer;
        }
        static void Main(string[] args)
        {
            string exrecise_number;
            exrecise_number = getExerciseNumberAndCheckFromConsole();
            double xVar;
            double yVar;
            double aVar;

            Console.Clear();


            Dictionary<string, RunProgrammExercise> exercices = new Dictionary<string, RunProgrammExercise>();
            
            exercices.Add("S2.1", new RunProgrammExercise(() => {
                xVar = 1.2;
                yVar = 7 * Math.Pow(xVar, 2) + 3 * xVar + 6;
                Console.WriteLine("y=7x^2+3x+6 при {0} равен {1}", xVar, yVar);

                aVar = 3;
                xVar = 12 * Math.Pow(aVar, 2) + 7 * aVar + 12;
                Console.WriteLine("x=12a^2+7a+12 при {0} равен {1}", aVar, xVar);
            }
            ));
            exercices.Add("S2.2", new RunProgrammExercise(() =>
            {
                double sideSquare = 3;
                Console.WriteLine("Периметр квадрата при стороне {0} равен {1}", sideSquare, sideSquare * 4);
            }));
            exercices.Add("S2.3", new RunProgrammExercise(() =>
            {
                double rad = 3;
                Console.WriteLine("Диаметр окружности с радиусом {0} равен {1}", rad, rad * 2);
            }));
            exercices.Add("S2.4", new RunProgrammExercise(() =>
            {
                const double earthRadius = 6350;
                double height = 200;
            }));
            exercices.Add("S2.5", new RunProgrammExercise(() =>
            {
                double cubeEdge = 9;
                Console.WriteLine("Куб с длинной ребра {0} имеет объем {1} и площадь поверхности {2}", cubeEdge, Math.Pow(cubeEdge, 3)
                    , Math.Pow(cubeEdge, 2));
            }));
            exercices.Add("S2.6", new RunProgrammExercise(() =>
            {
                double rad = 3;
                Console.WriteLine("Окружность радиусом {0} имеет длину {1} и площадь {2}", rad, 2 * Math.PI * rad, Math.PI * Math.Pow(rad, 2));
            }));
            exercices.Add("S2.7", new RunProgrammExercise(() =>
            {
                xVar = getNumberAndCheckFromConsole();
                yVar = getNumberAndCheckFromConsole();
                Console.WriteLine("Среднее арифметическое чисел {0} и {1} равно {2}", xVar, yVar, (xVar + yVar) / 2);
                Console.WriteLine("Среднее геометрическое чисел {0} и {1} равно {2}", xVar, yVar, Math.Sqrt(xVar * yVar));
            }));
            exercices.Add("S2.8", new RunProgrammExercise(() =>
            {
                double volume = getNumberAndCheckFromConsole();
                double massa = getNumberAndCheckFromConsole();
                Console.WriteLine("Плотность тела с объемом {0} и массой {1} равна {2}", volume, massa,  massa/volume);
            }));
            exercices.Add("S2.9", new RunProgrammExercise(() =>
            {
                double square = getNumberAndCheckFromConsole();
                double numberOfPerson = getNumberAndCheckFromConsole();
                Console.WriteLine("Плотность населения тела на территории площадью {0} с количеством человек {1} равна {2}", square, numberOfPerson,  square/numberOfPerson);
            }));

            if(exercices.ContainsKey(exrecise_number))
            {
                exercices[exrecise_number]();
            }
            else
            {
                Console.WriteLine("Упражнение не найдено");
            }
        }
    }
}