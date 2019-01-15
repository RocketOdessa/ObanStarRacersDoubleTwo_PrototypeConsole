using System;
using System.Threading;

namespace ObanStarRacersDoubleTwo_Prototype
{
    class Aluas : Battle
    {
        Battle battle = new Battle();
        Eva_Molly_Wai eva_Molly_Wai = new Eva_Molly_Wai
        {
            BlockShip = 40.0,
            DamageShip = 120.0,
            EvaDriveLevel = 5.5,
            Friendly = 10,
            _EvaHealth = 1000

        };
        Enemy enemy = new Enemy
        {
            enemyHealth = 1000,
            enemyLevelDrive = 5.5,
            FriendlyLevel = -1,
            EnemyBlock = 40.0,
            EnemyDamage = 120.0
        };

        public Aluas() { }

        public void HelloAluas()
        {
            Random rndAluas = new Random();
            char[] array = "Hello young racer! You chose this map for playing.\nIt will be hard, but I think you can do this".ToCharArray();
             for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
                Thread.Sleep(75);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Okay. Now you need to go to you first race versus Groor");

            Console.WriteLine("1.Go" +
                "\n2.I'm not ready");
            string choose = Console.ReadLine();            
            switch (choose) {
                case "1":
                    if (choose == "1")
                        battle.GetAttackResult(eva_Molly_Wai, enemy);
                    break;
                case "2":
                    Console.WriteLine("Okay, write '1' when you will ready!");
                    Console.ReadLine();
                    if (Console.ReadLine() != "1")
                    {                        
                        while (choose != "1")
                        {
                            Console.WriteLine("Are you ready ?");
                            if (Console.ReadLine() == "1")
                            {
                                battle.GetAttackResult(eva_Molly_Wai, enemy);
                                break;
                            }
                        }
                    }
                    break;                    
            }
        }
    }
}
