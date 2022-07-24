using System;

namespace MiniGame
{
    public class SuperPowerGenerator
    {
        private int SuperPower;

        public int GetSuperPower()
        {
            do
            {
                int TimeMilli = int.Parse(DateTime.Now.ToString("ffff"));
                int TimeSec = int.Parse(DateTime.Now.ToString("ss"));
                int TimeMin = int.Parse(DateTime.Now.ToString("mm"));

                SuperPower = TimeMilli * TimeMilli % TimeSec;

            } while (SuperPower >= 10 || SuperPower <= 5);

            return SuperPower;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SuperPowerGenerator superPowerGenerator = new SuperPowerGenerator();
            int superPower = superPowerGenerator.GetSuperPower();
            Console.WriteLine(superPower);

        }
    }
}