using System;

namespace Project1.fantasticExercise
{
    class Capacity
    {
        protected double value;
        protected double liquid;
        public Capacity(double cap)
        {
            Console.WriteLine("Capacity");
            value = cap;
        }
        private double FreeVolumeDiff(Capacity capacity)
        {
            return FreeVolume - capacity.FreeVolume;
        }
        public void pourInto(Capacity capacity)
        {
            capacity.liquid = capacity.liquid + liquid;
            Console.WriteLine("Перелили {0} л.", liquid);
            liquid = 0.0;
            capacity.pourOutExcess();
        }
        private void pourOutExcess()
        {
            if (liquid > value)
            {
                double diff = liquid - value;
                liquid = value;
                Console.WriteLine("Емкость переполнилась и {0} л. жидкости утеряно.", Math.Round(diff, 2));
            }
        }
        protected double FreeVolume
        {
            get
            {
                return value - liquid;
            }
        }
        public static void FillFromTheEndlessChute(Capacity capacity)
        {
            double freeVolume = capacity.FreeVolume;
            capacity.liquid += freeVolume;
            Console.WriteLine("Волшебный желоб наполнил емкость до краев на {0} л.! ", Math.Round(freeVolume, 2));
        }
    }
    class Cup : Capacity
    {
        public Cup(double capacity) : base(capacity)
        {

        }
        protected void notifyCreation()
        {
            Console.WriteLine("Создан стакан");
        }
    }
    class OrdinaryGlass
    {
        public void run()
        {
            Cup cupA = new Cup(0.2);
            Cup cupB = new Cup(0.25);
            Capacity.FillFromTheEndlessChute(cupB);
            cupB.pourInto(cupA);
        }
    }
}