using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1.Chapter12;
using Project1.Chapter13;
using Project1.Chapter14;
using Project1.Chapter15;
using Project1.fantasticExercise;
using Project1.base_algoritm;
using Project1.graph_extension;

namespace Project1
{
    class Runable
    {
        static void Main(string[] args)
        {
            ProductDemo runableObject = new ProductDemo();
            runableObject.run();
            Console.ReadKey();
        }
    }
}