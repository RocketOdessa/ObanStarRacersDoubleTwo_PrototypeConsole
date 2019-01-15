using System;
using System.Threading;


namespace ObanStarRacersDoubleTwo_Prototype
{
    class Eva_Molly_Wai
    {
        public string Name { get; set;} = "Eva";
        private int friendly;
        private double levelOfDrive;
        private double damage;
        private double blockDamage;
        private double evaHealth;

        public Eva_Molly_Wai()
        {
            Name = "Eva";
            friendly = 5;
            levelOfDrive = 0.0;
            damage = 0.0;
            blockDamage = 0.0;
            evaHealth = 0.0;
        }
        public Eva_Molly_Wai(string Name, int FriendlyLevel)
            : this ("Eva",0,0.0,0.0,0.0,0.0) { }                 
        
        public Eva_Molly_Wai (double DriveLevel, double AirShipDamage, double AirShieldBlock)
           : this ("Eva",0, 0.0,0.0,0.0,0.0) { }           
               
        public Eva_Molly_Wai (string name, int friendly, double level, double damageShip, 
            double blockShip,double health)
        {
            Name = name;
            this.friendly = friendly;
            levelOfDrive = level;
            damage = damageShip;
            blockDamage = blockShip;
            evaHealth = health;
        }
        public int Friendly { get; set; } 
        public double EvaDriveLevel
        {
            get => levelOfDrive;
            set => levelOfDrive = value;            
        }
        public double DamageShip { get; set; }
        public double BlockShip { get; set; } 
        public double _EvaHealth { get; set; }

        Random rnd = new Random();

        public double AttackEva()
        {
            return rnd.Next(1, (int)DamageShip);
        }

        public double BLockEva()
        {
            return rnd.Next(1, (int)BlockShip);
        }
        public void GetHistoryAboutEva()
        {
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            char[] array = "15-year-old girl from Earth. At five, her father, Don Wei, left her at the Stern boarding school, where she spent ten years.\nOn her fifteenth birthday, she waited for a call from her father,who had never called her and had not visited her in all ten years.\nShe introduced herself to him under the assumed name of Molly (which she saw on a poster hanging nearby)".ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
                Thread.Sleep(0);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
