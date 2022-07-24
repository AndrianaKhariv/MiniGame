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

    abstract public class Warrior
    {
        public int Life = 100;
        public int Armor;
        public int ImpactForce;
    }

    public class Archers : Warrior
    {

        public int Life;
        public int Armor = 5;
        public int ImpactForce = 15;

    }
    public class Magician : Warrior
    {
        public int Life;
        public int Armor = 15;
        public int ImpactForce = 5;
    }

    public class Barbarian : Warrior
    {

        public int Life;
        public int Armor = 10;
        public int ImpactForce = 10;

    }
    public class Rider : Warrior
    {

        public int Life;
        public int Armor = 12;
        public int ImpactForce = 8;
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