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
        public int Life { get; set; }
        public int Armor { get; set; }
        public int ImpactForce { get; set; }

        public bool IsAlive
        {
            get { return (Life > 0); }
        }
        public Warrior(int life, int armor, int impactForce)
        {
            Life = life;
            Armor = armor;
            ImpactForce = impactForce;
        }
        public virtual void AddSuperPower(ISuperPower superPower, int powerCount)
        {
            Console.WriteLine("This Warrior should not have super power.");
        }

        public int Attack()
        {
            if (Armor > 0)
                return ImpactForce;
            else
                return ImpactForce == 1 ? ImpactForce : ImpactForce--;
        }

        public void Protection(int enemyImpactForce)
        {
            if (Armor > 0)
                if (Armor > (enemyImpactForce / 2))
                {
                    enemyImpactForce /= 2;
                    Armor -= enemyImpactForce;
                    Life -= enemyImpactForce;
                }
                else
                {
                    enemyImpactForce -= Armor;
                    Armor = 0;
                    Life -= enemyImpactForce;
                }
            else
            {
                Life -= enemyImpactForce;
            }

        }
    }

    public class Archers : Warrior
    {

        public Archers() : base(life: 100, armor: 5, impactForce: 15)
        {
        }

        public override void AddSuperPower(ISuperPower superPower, int powerCount)
        {
            base.AddSuperPower(superPower, powerCount);
        }
    }


    public class Magician : Warrior
    {
        public Magician() : base(life: 100, armor: 15, impactForce: 5)
        {
        }
    }

    public class Barbarian : Warrior
    {

        public Barbarian() : base(life: 100, armor: 10, impactForce: 10)
        {
        }

        public override void AddSuperPower(ISuperPower superPower, int powerCount)
        {
            superPower.AddSuperPower(this, powerCount);
        }
    }
    public class Rider : Warrior
    {

        public Rider() : base(life: 100, armor: 12, impactForce: 8)
        {
        }

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


    public static class Battle
    {
        public static void StartBattle(Warrior warrior1, Warrior warrior2)
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SuperPowerGenerator superPowerGenerator = new SuperPowerGenerator();
            int superPower = superPowerGenerator.GetSuperPower();
            Barbarian barbarian = new Barbarian();
            Console.WriteLine(barbarian.Life);
            barbarian.AddSuperPower(new AddSuperLife(), superPower);
            Console.WriteLine(barbarian.Life);

        }
    }
}