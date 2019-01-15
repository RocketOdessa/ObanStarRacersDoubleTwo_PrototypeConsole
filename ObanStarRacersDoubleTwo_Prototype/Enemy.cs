using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObanStarRacersDoubleTwo_Prototype
{
    class Enemy
    {
        Random random = new Random();

        private string enemyName;
        private int friendlyEnemy;
        private double enemyLevelOfDrive;
        private double enemyDamage;
        private double enemyBlockDamage;
        private double Health;

        public Enemy()
        {

        }
        public Enemy(string enemyName, int friendlyEnemy,
            double enemyLevelOfDrive, double enemyDamage, double enemyBlockDamage,
            double health)
        {
            this.enemyName = enemyName;
            this.friendlyEnemy = friendlyEnemy;
            this.enemyLevelOfDrive = enemyLevelOfDrive;
            this.enemyDamage = enemyDamage;
            this.enemyBlockDamage = enemyBlockDamage;
            Health = health;
        }

        public string Name
        {
            get => enemyName;
            set
            {
                enemyName = value;
            }
        }
        public int FriendlyLevel { get; set; }
        public double enemyLevelDrive { get; set; }
        public double enemyHealth { get; set; }
        public double EnemyDamage { get => enemyDamage; set => enemyDamage = value; }
        public double EnemyBlock { get => enemyBlockDamage; set => enemyBlockDamage = value; }


        public double AttackEnemy()
        {
            return random.Next(1, (int)EnemyDamage);
        }

        public double BLockEnemy()
        {
            return random.Next(1, (int)EnemyBlock);
        }
    }
    
}

