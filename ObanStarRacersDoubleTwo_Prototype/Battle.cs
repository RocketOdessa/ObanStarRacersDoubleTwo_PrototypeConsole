using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ObanStarRacersDoubleTwo_Prototype
{
    class Battle : ITypeOfRace
    {
        public Battle(){}        
        int Score = 0;


        public string GetAttackResult(Eva_Molly_Wai _Eva, Enemy _Enemy)
        {
            if (Score == 0)
                _Enemy.Name = "Groor";            
                
            if (Score == 1)
            {
                if (_Eva._EvaHealth <= 800 && _Eva._EvaHealth >= 700)
                {
                    DangerMap(_Eva);
                }
            }

            if (Score == 2)
            {
                if (_Eva._EvaHealth <= 800 && _Eva._EvaHealth >= 700)
                {
                    SunMap(_Eva);
                }
            }

            if (Score == 3)
            {
                if (_Eva._EvaHealth <= 800 && _Eva._EvaHealth >= 700)
                {
                    NightMap(_Eva);
                }
            }
            if (Score == 4)
            {
                if (_Eva._EvaHealth <= 800 && _Eva._EvaHealth >= 700)
                {
                    DangerMap(_Eva);
                }
            }
            while (_Eva._EvaHealth > 0 || _Enemy.enemyHealth > 0)
            { 
                Thread.Sleep(500);               

            double dmgEva = _Eva.AttackEva() - _Enemy.BLockEnemy();
            double dmgEnemy = _Enemy.AttackEnemy() -_Eva.BLockEva();

                if (_Eva._EvaHealth <= 800 && _Eva._EvaHealth >= 700)
                {
                    RainMap(_Eva._EvaHealth); 
                }              

                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.White;
                if (dmgEva > 0)
                {
                    _Enemy.enemyHealth = _Enemy.enemyHealth - dmgEva;
                    Console.WriteLine("->{0} Attack {1} and Deal {2} Damage",
                       _Eva.Name,
                       _Enemy.Name,
                       dmgEva);
                }
                else
                {
                    dmgEva = 0;
                    Console.WriteLine("->{0} blocked attack from {1} deal 0 damage",
                        _Enemy.Name,
                        _Eva.Name);
                }
                Console.ForegroundColor = ConsoleColor.Red;
                if (dmgEnemy > 0)
                {
                    _Eva._EvaHealth = _Eva._EvaHealth - dmgEnemy;
                    Console.WriteLine("{0} Attack {1} and deal {2} damage",
                        _Enemy.Name,
                        _Eva.Name,
                        dmgEnemy);
                }
                else
                {
                    dmgEnemy = 0;
                    Console.WriteLine("{0} blocked attack from {1} deal 0 damage",
                        _Eva.Name,
                        _Enemy.Name);
                }
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("//////////////////////////////////////////////////");
                Console.WriteLine("->{0} has {1} health", _Eva.Name, _Eva._EvaHealth);
                Console.WriteLine("{0} has {1} health", _Enemy.Name, _Enemy.enemyHealth);
                Console.WriteLine("//////////////////////////////////////////////////");

                Console.ForegroundColor = ConsoleColor.Gray;

                if (_Enemy.enemyHealth <= 0)
                {
                    ++Score;
                    Console.WriteLine("------------------------------------------------------");
                    Console.WriteLine("{0} lose race, and winner is {1}", _Enemy.Name, _Eva.Name);
                    Console.WriteLine("------------------------------------------------------");
                    NextMatch(_Eva, _Enemy);
                    return "*****Race Over*****";
                }
                else if (_Eva._EvaHealth <= 0)
                {
                    Console.WriteLine("------------------------------------------------------");
                    Console.WriteLine($"{_Eva.Name} lose race, and winner is {_Enemy.Name}");
                    Console.WriteLine("------------------------------------------------------");
                    Console.WriteLine("Do you want to restart this race ? (recomend)");
                    Console.WriteLine("1.Yes\n2.Exit");
                    string rematchChoose = Console.ReadLine();
                    switch (rematchChoose)
                    {
                        case "1":
                            if (rematchChoose == "1")
                            {
                                Rematch(_Eva, _Enemy);
                            }
                            break;
                        case "2":
                            if (rematchChoose == "2")
                            {
                                Environment.Exit(0);
                            }
                            break;
                    }
                    return "*****Race Over*****";
                }                
            }
            return "Race Draw";                    
        }
        public void Rematch(Eva_Molly_Wai molly_Wai, Enemy enemy)
        {
            molly_Wai._EvaHealth = 1000;
            enemy.enemyHealth = 1000;
            GetAttackResult(molly_Wai, enemy);
        }
        public void NextMatch (Eva_Molly_Wai eva, Enemy enemyNext)
        {
            eva._EvaHealth = 1000;
            enemyNext.enemyHealth = 1000;
            if (Score == 1)
                enemyNext.Name = "Flint";
            if (Score == 2)
                enemyNext.Name = "Ceres";
            if (Score == 3)
                enemyNext.Name = "paraDise";
            if (Score == 4)
                enemyNext.Name = "Toros";
            if (Score == 5)
                welcomeToOban();
            Console.WriteLine("Team Earth won. Your score now {0} - 0", Score);
            Console.WriteLine($"Your next opponent is {enemyNext.Name}");
            Console.WriteLine("Start next match ?");
            Console.WriteLine("1. Yes\n2. No (write 1 or 2)");
            string choose = Console.ReadLine();
            switch (choose)
            {
                case "1":
                    if (choose == "1")
                        GetAttackResult(eva, enemyNext);
                    break;
                case "2":
                    if (choose == "2")
                        Environment.Exit(0);
                    break;
            }
        }
        public void welcomeToOban()
        {
            ConsoleColor console = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Well done young racer. You won 5 race and I invite you to the main stage on Oban!!\nTake a rest and wait next update. Thanks for playing!!");
        }

        public void RainMap(object rainEva)
        {
            Random random = new Random();
            Eva_Molly_Wai eva = new Eva_Molly_Wai
            {
                BlockShip = 120,
            };
            

            int randomTrap = random.Next(1, 5);
            if (randomTrap == 1)
            {
                Console.WriteLine("Front of you Wall Trap. Try to dodge it!!!");
                double damageOfWallTrap = eva.BLockEva() - 75.0;
                if (damageOfWallTrap < 0)
                {
                    Console.WriteLine($"Eva. Look out. You almost brake Arrow! (You took {damageOfWallTrap} damage");
                }
                else if (damageOfWallTrap > 0)
                {
                    Console.WriteLine("Great. You dodge this one. GO GO GO");
                }
            }
            if (randomTrap == 2)
            {
                double airTrap = eva.BLockEva() - 50.0;
                Console.WriteLine("Very salient quiet. Dont relax and look front of you.......\nOhhhhh. Shit. This is air trap. GET DOWN");
                if (airTrap < 0)
                {
                    Console.WriteLine($"It was so fast, you can dodge it... (You took {airTrap} damage)");
                }
                else if (airTrap > 0)
                {
                    Console.WriteLine("It's was wonderful Eva. HGHGHGh, keep it up");
                }
            }
            if (randomTrap == 3)
            {
                Console.WriteLine("Front of you tunnel. We don't see nothing on our scanners, but look around");
                Console.WriteLine("******You don't see nothing******");
                Console.WriteLine("******Turn on light******");
                Console.WriteLine("Eva: OMG, Jordan, Stick it !");
                Console.WriteLine("Front of you was big rock");
                double nightTrap = eva.BLockEva() - 25;
                if (nightTrap < 0)
                {
                    Console.WriteLine($"So hard, but we took small of damage (You took {nightTrap} damage)");
                }
                else if (nightTrap > 0)
                {
                    Console.WriteLine("It was hard. But racing is going on. We need to win");
                }
            }
            if (randomTrap == 4)
            {
                Console.WriteLine("You see a saw(Pila) Trap. You try to dodge");
                double sawTrap = eva.BLockEva() - 75;
                if (sawTrap < 0)
                {
                    Console.WriteLine($"We took medium damage. But we can continue race (You took {sawTrap} damage");
                }
                else if (sawTrap > 0)
                {
                    Console.WriteLine("HEHEHEHe, ease for my. Despite the fact that I'm a girl");
                    Console.WriteLine("In your mind (Dad, I can win this event and return our mother to us.\nAnd we can live how in the past)");
                }
            }
            if (randomTrap == 5)
            {
                Console.WriteLine("Jordan: Eva. I can't believe. It's laser trap. What will we do ?\nEva: Jordan. I try to dodge, but don't promise");
                double laserTrap = eva.BLockEva() - 100;
                if (laserTrap < 0)
                {
                    Console.WriteLine($"I tried to dodge this trap. Don't blame me Jordan (You took {laserTrap} damage");
                }
                else if (laserTrap > 0)
                {
                    Console.WriteLine($"Jordan: I believed in you, Eva(NO).\nThanks, stupid beast!)");
                }
            }
        }

        public void SunMap(object sunEva)
        {
            Random random = new Random();
            Eva_Molly_Wai eva = new Eva_Molly_Wai
            {
                BlockShip = 120,
            };


            int randomTrap = random.Next(1, 5);
            if (randomTrap == 1)
            {
                Console.WriteLine("Front of you Wall Trap. Try to dodge it!!!");
                double damageOfWallTrap = eva.BLockEva() - 75.0;
                if (damageOfWallTrap < 0)
                {
                    Console.WriteLine($"Eva. Look out. You almost brake Arrow! (You took {damageOfWallTrap} damage");
                }
                else if (damageOfWallTrap > 0)
                {
                    Console.WriteLine("Great. You dodge this one. GO GO GO");
                }
            }
            if (randomTrap == 2)
            {
                double airTrap = eva.BLockEva() - 50.0;
                Console.WriteLine("Very salient quiet. Dont relax and look front of you.......\nOhhhhh. Shit. This is air trap. GET DOWN");
                if (airTrap < 0)
                {
                    Console.WriteLine($"It was so fast, you can dodge it... (You took {airTrap} damage)");
                }
                else if (airTrap > 0)
                {
                    Console.WriteLine("It's was wonderful Eva. HGHGHGh, keep it up");
                }
            }
            if (randomTrap == 3)
            {
                Console.WriteLine("Front of you tunnel. We don't see nothing on our scanners, but look around");
                Console.WriteLine("******You don't see nothing******");
                Console.WriteLine("******Turn on light******");
                Console.WriteLine("Eva: OMG, Jordan, Stick it !");
                Console.WriteLine("Front of you was big rock");
                double nightTrap = eva.BLockEva() - 25;
                if (nightTrap < 0)
                {
                    Console.WriteLine($"So hard, but we took small of damage (You took {nightTrap} damage)");
                }
                else if (nightTrap > 0)
                {
                    Console.WriteLine("It was hard. But racing is going on. We need to win");
                }
            }
            if (randomTrap == 4)
            {
                Console.WriteLine("You see a saw(Pila) Trap. You try to dodge");
                double sawTrap = eva.BLockEva() - 75;
                if (sawTrap < 0)
                {
                    Console.WriteLine($"We took medium damage. But we can continue race (You took {sawTrap} damage");
                }
                else if (sawTrap > 0)
                {
                    Console.WriteLine("HEHEHEHe, ease for my. Despite the fact that I'm a girl");
                    Console.WriteLine("In your mind (Dad, I can win this event and return our mother to us.\nAnd we can live how in the past)");
                }
            }
            if (randomTrap == 5)
            {
                Console.WriteLine("Jordan: Eva. I can't believe. It's laser trap. What will we do ?\nEva: Jordan. I try to dodge, but don't promise");
                double laserTrap = eva.BLockEva() - 100;
                if (laserTrap < 0)
                {
                    Console.WriteLine($"I tried to dodge this trap. Don't blame me Jordan (You took {laserTrap} damage");
                }
                else if (laserTrap > 0)
                {
                    Console.WriteLine($"Jordan: I believed in you, Eva(NO).\nThanks, stupid beast!)");
                }
            }
        }

        public void NightMap(object nightEva)
        {
            Random random = new Random();
            Eva_Molly_Wai eva = new Eva_Molly_Wai
            {
                BlockShip = 120,
            };


            int randomTrap = random.Next(1, 5);
            if (randomTrap == 1)
            {
                Console.WriteLine("Front of you Wall Trap. Try to dodge it!!!");
                double damageOfWallTrap = eva.BLockEva() - 75.0;
                if (damageOfWallTrap < 0)
                {
                    Console.WriteLine($"Eva. Look out. You almost brake Arrow! (You took {damageOfWallTrap} damage");
                }
                else if (damageOfWallTrap > 0)
                {
                    Console.WriteLine("Great. You dodge this one. GO GO GO");
                }
            }
            if (randomTrap == 2)
            {
                double airTrap = eva.BLockEva() - 50.0;
                Console.WriteLine("Very salient quiet. Dont relax and look front of you.......\nOhhhhh. Shit. This is air trap. GET DOWN");
                if (airTrap < 0)
                {
                    Console.WriteLine($"It was so fast, you can dodge it... (You took {airTrap} damage)");
                }
                else if (airTrap > 0)
                {
                    Console.WriteLine("It's was wonderful Eva. HGHGHGh, keep it up");
                }
            }
            if (randomTrap == 3)
            {
                Console.WriteLine("Front of you tunnel. We don't see nothing on our scanners, but look around");
                Console.WriteLine("******You don't see nothing******");
                Console.WriteLine("******Turn on light******");
                Console.WriteLine("Eva: OMG, Jordan, Stick it !");
                Console.WriteLine("Front of you was big rock");
                double nightTrap = eva.BLockEva() - 25;
                if (nightTrap < 0)
                {
                    Console.WriteLine($"So hard, but we took small of damage (You took {nightTrap} damage)");
                }
                else if (nightTrap > 0)
                {
                    Console.WriteLine("It was hard. But racing is going on. We need to win");
                }
            }
            if (randomTrap == 4)
            {
                Console.WriteLine("You see a saw(Pila) Trap. You try to dodge");
                double sawTrap = eva.BLockEva() - 75;
                if (sawTrap < 0)
                {
                    Console.WriteLine($"We took medium damage. But we can continue race (You took {sawTrap} damage");
                }
                else if (sawTrap > 0)
                {
                    Console.WriteLine("HEHEHEHe, ease for my. Despite the fact that I'm a girl");
                    Console.WriteLine("In your mind (Dad, I can win this event and return our mother to us.\nAnd we can live how in the past)");
                }
            }
            if (randomTrap == 5)
            {
                Console.WriteLine("Jordan: Eva. I can't believe. It's laser trap. What will we do ?\nEva: Jordan. I try to dodge, but don't promise");
                double laserTrap = eva.BLockEva() - 100;
                if (laserTrap < 0)
                {
                    Console.WriteLine($"I tried to dodge this trap. Don't blame me Jordan (You took {laserTrap} damage");
                }
                else if (laserTrap > 0)
                {
                    Console.WriteLine($"Jordan: I believed in you, Eva(NO).\nThanks, stupid beast!)");
                }
            }
        }

        public void DangerMap(object dangerEva)
        {
            Random random = new Random();
            Eva_Molly_Wai eva = new Eva_Molly_Wai
            {
                BlockShip = 120,
            };


            int randomTrap = random.Next(1, 5);
            if (randomTrap == 1)
            {
                Console.WriteLine("Front of you Wall Trap. Try to dodge it!!!");
                double damageOfWallTrap = eva.BLockEva() - 75.0;
                if (damageOfWallTrap < 0)
                {
                    Console.WriteLine($"Eva. Look out. You almost brake Arrow! (You took {damageOfWallTrap} damage");
                }
                else if (damageOfWallTrap > 0)
                {
                    Console.WriteLine("Great. You dodge this one. GO GO GO");
                }
            }
            if (randomTrap == 2)
            {
                double airTrap = eva.BLockEva() - 50.0;
                Console.WriteLine("Very salient quiet. Dont relax and look front of you.......\nOhhhhh. Shit. This is air trap. GET DOWN");
                if (airTrap < 0)
                {
                    Console.WriteLine($"It was so fast, you can dodge it... (You took {airTrap} damage)");
                }
                else if (airTrap > 0)
                {
                    Console.WriteLine("It's was wonderful Eva. HGHGHGh, keep it up");
                }
            }
            if (randomTrap == 3)
            {
                Console.WriteLine("Front of you tunnel. We don't see nothing on our scanners, but look around");
                Console.WriteLine("******You don't see nothing******");
                Console.WriteLine("******Turn on light******");
                Console.WriteLine("Eva: OMG, Jordan, Stick it !");
                Console.WriteLine("Front of you was big rock");
                double nightTrap = eva.BLockEva() - 25;
                if (nightTrap < 0)
                {
                    Console.WriteLine($"So hard, but we took small of damage (You took {nightTrap} damage)");
                }
                else if (nightTrap > 0)
                {
                    Console.WriteLine("It was hard. But racing is going on. We need to win");
                }
            }
            if (randomTrap == 4)
            {
                Console.WriteLine("You see a saw(Pila) Trap. You try to dodge");
                double sawTrap = eva.BLockEva() - 75;
                if (sawTrap < 0)
                {
                    Console.WriteLine($"We took medium damage. But we can continue race (You took {sawTrap} damage");
                }
                else if (sawTrap > 0)
                {
                    Console.WriteLine("HEHEHEHe, ease for my. Despite the fact that I'm a girl");
                    Console.WriteLine("In your mind (Dad, I can win this event and return our mother to us.\nAnd we can live how in the past)");
                }
            }
            if (randomTrap == 5)
            {
                Console.WriteLine("Jordan: Eva. I can't believe. It's laser trap. What will we do ?\nEva: Jordan. I try to dodge, but don't promise");
                double laserTrap = eva.BLockEva() - 100;
                if (laserTrap < 0)
                {
                    Console.WriteLine($"I tried to dodge this trap. Don't blame me Jordan (You took {laserTrap} damage");
                }
                else if (laserTrap > 0)
                {
                    Console.WriteLine($"Jordan: I believed in you, Eva(NO).\nThanks, stupid beast!)");
                }
            }
        }
    }
}


