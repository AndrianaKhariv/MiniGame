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
            superPower.AddSuperPower(this, powerCount);
        }

        public override string ToString()
        {
            return "Archers";
        }
    }


    public class Magician : Warrior
    {
        public Magician() : base(life: 100, armor: 15, impactForce: 5)
        {
        }
        public override void AddSuperPower(ISuperPower superPower, int powerCount)
        {
            base.AddSuperPower(superPower, powerCount);
        }
        public override string ToString()
        {
            return "Magician";
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
        public override string ToString()
        {
            return "Barbarian";
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
        public override string ToString()
        {
            return "Rider";
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


        public static void StartBattle(Warrior warrior1, Warrior warrior2, Warrior warrior3, Warrior warrior4)
        {
            int roundCounter = 0;
            while (warrior1.IsAlive && warrior2.IsAlive)
            {
                roundCounter++;

                int enemyImpactForce = warrior1.Attack();
                warrior2.Protection(enemyImpactForce);

                enemyImpactForce = warrior2.Attack();
                warrior1.Protection(enemyImpactForce);


                Console.WriteLine("Round {0}", roundCounter);
                Console.WriteLine("Warrior 1: {0} {1} {2}", warrior1.Life, warrior1.Armor, warrior1.ImpactForce);
                Console.WriteLine("Warrior 2: {0} {1} {2}", warrior2.Life, warrior2.Armor, warrior2.ImpactForce);
            }

            roundCounter = 0;
            while (warrior3.IsAlive && warrior4.IsAlive)
            {
                roundCounter++;
                int enemyImpactForce = warrior3.Attack();
                warrior4.Protection(enemyImpactForce);

                enemyImpactForce = warrior4.Attack();
                warrior3.Protection(enemyImpactForce);


                Console.WriteLine("Round {0}", roundCounter);
                Console.WriteLine("Warrior 1: {0} {1} {2}", warrior3.Life, warrior3.Armor, warrior3.ImpactForce);
                Console.WriteLine("Warrior 2: {0} {1} {2}", warrior4.Life, warrior4.Armor, warrior4.ImpactForce);
            }

            if (warrior1.IsAlive)

                Console.WriteLine("Winner player 1:  {0} Looser: {1} Life: {2}  Round count: {3} ", warrior1.ToString(), warrior2.ToString(),
                    warrior1.Life, roundCounter);
            else
                Console.WriteLine("Winner player 2: {0} Looser: {1} Life: {2} Round count: {3}", warrior2.ToString(), warrior1.ToString(),
                    warrior2.Life, roundCounter);

            if (warrior3.IsAlive)
                Console.WriteLine("Winner player 3:  {0} Looser: {1} Life: {2}  Round count: {3} ", warrior3.ToString(), warrior4.ToString(),
                    warrior3.Life, roundCounter);
            else
                Console.WriteLine("Winner player 4: {0} Looser: {1} Life: {2} Round count: {3}", warrior4.ToString(), warrior3.ToString(),
                    warrior4.Life, roundCounter);
        }
    }


    class Program
    {
        static Warrior ChooseWarrior()
        {
            Console.WriteLine("Choose a  warrior: 1. Archers 2. Magician 3. Barbarian 4. Rider ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    return new Archers();
                case 2:
                    return new Magician();
                case 3:
                    return new Barbarian();
                case 4:
                    return new Rider();
            }

            return null;

        }

        static ISuperPower ChooseSuperPower(int superPower)
        {
            Console.WriteLine("Your SuperPower: {0}. \n Choose what to improve: 1. Life 2. Armor 3. ImpactForce ", superPower);
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    return new AddSuperLife();
                case 2:
                    return new AddSuperArmor();
                case 3:
                    return new AddSuperImpactForce();
            }

            return null;

        }
        static void Main(string[] args)
        {
            int choiceExit;

            do
            {
                Warrior warrior1 = ChooseWarrior();
                Warrior warrior2 = ChooseWarrior();
                Warrior warrior3 = ChooseWarrior();
                Warrior warrior4 = ChooseWarrior();


                SuperPowerGenerator superPowerGenerator = new SuperPowerGenerator();
                int spCount1 = superPowerGenerator.GetSuperPower();
                ISuperPower superPower1 = ChooseSuperPower(spCount1);
                warrior1.AddSuperPower(superPower1, spCount1);

                int spCount2 = superPowerGenerator.GetSuperPower();
                ISuperPower superPower2 = ChooseSuperPower(spCount2);
                warrior2.AddSuperPower(superPower2, spCount2);

                int spCount3 = superPowerGenerator.GetSuperPower();
                ISuperPower superPower3 = ChooseSuperPower(spCount3);
                warrior1.AddSuperPower(superPower3, spCount3);

                int spCount4 = superPowerGenerator.GetSuperPower();
                ISuperPower superPower4 = ChooseSuperPower(spCount4);
                warrior2.AddSuperPower(superPower4, spCount4);

                Console.WriteLine("Warrior 1: {0} {1} {2}", warrior1.Life, warrior1.Armor, warrior1.ImpactForce);
                Console.WriteLine("Warrior 2: {0} {1} {2}", warrior2.Life, warrior2.Armor, warrior2.ImpactForce);
                Console.WriteLine("Warrior 3: {0} {1} {2}", warrior3.Life, warrior3.Armor, warrior3.ImpactForce);
                Console.WriteLine("Warrior 4: {0} {1} {2}", warrior4.Life, warrior4.Armor, warrior4.ImpactForce);

                Battle.StartBattle(warrior1, warrior2, warrior3, warrior4);

                Console.WriteLine("Enter 1 to repeat, press 0 to exit");
                choiceExit = Convert.ToInt32(Console.ReadLine());

            } while (choiceExit != 0);


        }
    }
}
