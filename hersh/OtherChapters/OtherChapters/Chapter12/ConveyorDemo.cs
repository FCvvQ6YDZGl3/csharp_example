using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Chapter12
{
    class ConveryorControl
    {
        public enum Action { Start, Stop, Forward, Reverse };

        public void Converyor(Action com)
        {
            switch (com)
            {
                case Action.Start:
                    Console.WriteLine("Запустить конвейер.");
                    break;
                case Action.Stop:
                    Console.WriteLine("Остановить конвейер.");
                    break;
                case Action.Forward:
                    Console.WriteLine("Переместить конвейер вперед.");
                    break;
                case Action.Reverse:
                    Console.WriteLine("Переместить конвейер назад.");
                    break;
            }
        }
    }
    class ConveyorDemo
    {
        public void run()
        {
            ConveryorControl c = new ConveryorControl();

            c.Converyor(ConveryorControl.Action.Start);
            c.Converyor(ConveryorControl.Action.Forward);
            c.Converyor(ConveryorControl.Action.Reverse);
            c.Converyor(ConveryorControl.Action.Stop);
        }
    }
}
