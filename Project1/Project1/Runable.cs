﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1.base_algoritm;


namespace Project1
{
    class Runable
    {
        static void Main(string[] args)
        {
            OrdinaryGlass runableObject = new OrdinaryGlass();
            runableObject.run();
            Console.ReadKey();
        }
    }
}