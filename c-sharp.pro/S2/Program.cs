//https://c-sharp.pro
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace S2
{
    delegate void RunProgrammExercise(List<double> args);

    class Exercise
    {
        public RunProgrammExercise runProgrammExercise;
        public List<string> inputText;
        public List<double> args;
        private void getArgs()
        {
            args = new List<double>();
            foreach(string t in inputText)
            {
                Console.WriteLine("{0}:", t);
                args.Add(getNumberAndCheckFromConsole());
            }
        }

        private double getNumberAndCheckFromConsole()
        {
            string answer;
            double number;
            answer = Console.ReadLine();

            if (!double.TryParse(answer, out number))
            {
                getArgs();
                Console.WriteLine("Вы ввели не число!");
                number = getNumberAndCheckFromConsole();
            }
            return number;
        }

        public void run()
        {
            getArgs();
            runProgrammExercise(args);
        }
    }

    class Program
    {
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

            Console.Clear();

            Dictionary<string, Exercise> exercices = new Dictionary<string, Exercise>();

            //Хороший паттерн как не надо использовать делегаты)
            Exercise exr = new Exercise();
            exr.inputText = new List<string>{ "Введите значение x"};
            exr.runProgrammExercise +=
                new RunProgrammExercise((a) =>
                {
                    Console.WriteLine("y=7x^2+3x+6 при {0} равен {1}", a[0], (7 * Math.Pow(a[0], 2) + 3 * a[0] + 6) );
                });
            exercices.Add("S2.1a", exr);


            exr = new Exercise();
            exr.inputText = new List<string> { "Введите значение y" };
            exr.runProgrammExercise += new RunProgrammExercise( (a) => {
                Console.WriteLine("x=12a^2+7a+12 при {0} равен {1}", a[0], (12 * Math.Pow(a[0], 2) + 7 * a[0] + 12));
            }
            );
            exercices.Add("S2.1b", exr);

            exr = new Exercise();
            exr.inputText = new List<string> { "Введите длину стороны квадрата" };
            exr.runProgrammExercise += new RunProgrammExercise((a) => {
                Console.WriteLine("Периметр квадрата при стороне {0} равен {1}", a[0], a[0] * 4);
            }
            );
            exercices.Add("S2.2", exr);

            exr = new Exercise();
            exr.inputText = new List<string> { "Введите значение радиуса" };
            exr.runProgrammExercise += new RunProgrammExercise((a) => {
                Console.WriteLine("Диаметр окружности с радиусом {0} равен {1}", a[0], a[0] * 2);
            }
            );
            exercices.Add("S2.3", exr);

            exr = new Exercise();
            exr.inputText = new List<string> { "Введите высоту предмета над поверхностью земли" };
            exr.runProgrammExercise += new RunProgrammExercise((a) => {
                Console.WriteLine("Эта задача оказалась мне не под силу");
            }
            );
            exercices.Add("S2.4", exr);

            exr = new Exercise();
            exr.inputText = new List<string> { "Введите длину стороны куба" };
            exr.runProgrammExercise += new RunProgrammExercise((a) => {
                Console.WriteLine("Куб с длинной ребра {0} имеет объем {1} и площадь поверхности {2}", a[0], Math.Pow(a[0], 3)
                    , Math.Pow(a[0], 2));
            });
            exercices.Add("S2.5", exr);



            exr = new Exercise();
            exr.inputText = new List<string> { "Введите радиус окружности"};
            exr.runProgrammExercise += new RunProgrammExercise((a) => {
                Console.WriteLine("Окружность радиусом {0} имеет длину {1} и площадь {2}", a[0], 2 * Math.PI * a[0], Math.PI * Math.Pow(a[0], 2));
            });
            exercices.Add("S2.6", exr);

            exr = new Exercise();
            exr.inputText = new List<string> { "Введите число", "Введите число" };
            exr.runProgrammExercise += new RunProgrammExercise((a) => {
                Console.WriteLine("Среднее арифметическое чисел {0} и {1} равно {2}", a[0], a[1], (a[0] + a[1]) / 2);
                Console.WriteLine("Среднее геометрическое чисел {0} и {1} равно {2}", a[0], a[1], Math.Sqrt(a[0] * a[1]));
            });
            exercices.Add("S2.7", exr);

            exr = new Exercise();
            exr.inputText = new List<string> { "Введите объем", "Введите массу" };
            exr.runProgrammExercise += new RunProgrammExercise((a) => {
                Console.WriteLine("Плотность тела с объемом {0} и массой {1} равна {2}", a[0], a[1], a[0] / a[1]);
            });
            exercices.Add("S2.8", exr);

            exr = new Exercise();
            exr.inputText = new List<string> { "Введите количество людей", "Введите площадь страны" };
            exr.runProgrammExercise += new RunProgrammExercise((a) => {
                Console.WriteLine("Плотность населения на территории площадью {0} с количеством человек {1} равна {2}", a[0], a[1], a[0] / a[1]);
            });
            exercices.Add("S2.9", exr);


            exr = new Exercise();
            exr.inputText = new List<string> { "Введите значение a", "Введите значение b" };
            exr.runProgrammExercise += new RunProgrammExercise((a) => {
                Console.WriteLine("{0}x+{1}=0, x = {2}", a[0], a[1], -a[1]/a[0]);
            });
            exercices.Add("S2.10", exr);

            foreach (var kvp in exercices)
            {
                Console.WriteLine(kvp.Key);
            }
            exrecise_number = getExerciseNumberAndCheckFromConsole();

            if (exercices.ContainsKey(exrecise_number))
            {
                try
                {
                    exercices[exrecise_number].run();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Что-то пошло не так: {0}", e);
                }
            }
            else
            {
                Console.WriteLine("Упражнение не найдено");
            }
        }
    }
}