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

                SuperPower = TimeMilli * TimeMilli % (TimeSec + 1);

            } while (SuperPower > 10 || SuperPower < 5);

            return SuperPower;
        }
    }

    abstract public class Warrior
    {
        public int Life;
        public int Armor;
        public int ImpactForce;

        public virtual void AddSuperPower(ISuperPower superPower, int powerCount)
        {

            superPower.AddSuperPower(this, powerCount);
        }
    }

    public class Archers : Warrior
    {

        public new int Life = 100;
        public new int Armor = 5;
        public new int ImpactForce = 15;

        public override void AddSuperPower(ISuperPower superPower, int powerCount)
        {
            base.AddSuperPower(superPower, powerCount);
        }
    }


    public class Magician : Warrior
    {
        public new int Life = 100;
        public new int Armor = 15;
        public new int ImpactForce = 5;
    }

    public class Barbarian : Warrior
    {

        public new int Life = 100;
        public new int Armor = 10;
        public new int ImpactForce = 10;

        public override void AddSuperPower(ISuperPower superPower, int powerCount)
        {
            base.AddSuperPower(superPower, powerCount);
        }
    }
    public class Rider : Warrior
    {

        public new int Life = 100;
        public new int Armor = 12;
        public new int ImpactForce = 8;

        public override void AddSuperPower(ISuperPower superPower, int powerCount)
        {
            base.AddSuperPower(superPower, powerCount);
        }
    }

    public interface ISuperPower
    {
        public void AddSuperPower(Warrior warrior, int powerCount);

    }

    public class AddSuperLife : ISuperPower
    {
        public void AddSuperPower(Warrior warrior, int powerCount)
        {
            warrior.Life += powerCount;
        }
    }

    public class AddSuperArmor : ISuperPower
    {
        public void AddSuperPower(Warrior warrior, int powerCount)
        {
            warrior.Armor += powerCount;
        }
    }

    public class AddSuperImpactForce : ISuperPower
    {
        public void AddSuperPower(Warrior warrior, int powerCount)
        {
            warrior.ImpactForce += powerCount;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SuperPowerGenerator superPowerGenerator = new SuperPowerGenerator();
            int superPower = superPowerGenerator.GetSuperPower();

            Barbarian barbarian = new Barbarian();
            Console.WriteLine(barbarian.Armor);
            new AddSuperArmor().AddSuperPower(barbarian, superPower);
            //new AddSuperArmor().AddSuperPower(barbarian, superPower);
            Console.WriteLine(barbarian.Armor + superPower);

        }
    }
}