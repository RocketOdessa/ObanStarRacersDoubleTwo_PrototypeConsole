using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ObanStarRacersDoubleTwo_Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            // levelOfDrive less than 2, else 200%
            //in other words 0.1 = 10%
            Eva_Molly_Wai eva_Molly_Wai = new Eva_Molly_Wai();

            
            Aluas aluas = new Aluas();
            Dangrar dangrar = new Dangrar();
            Sangrar sangrar = new Sangrar();
            Battle battle = new Battle();
            ConsoleColor colorForegroung = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("                   __________________________________________________________________________________________");
            Console.WriteLine("                  /¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤" +
                "¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤\\" +
                "                           |            |\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//|            |  ");
            Console.WriteLine("                  \\                         Hello, Dude. You play in Oban: Star Racers                       /");
            Console.WriteLine("                   |                               Good luck and have fun!XD                                 |");

            Console.WriteLine("                   |_________________________________________________________________________________________|");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Tap to the console only Digits and no more. Game have a bugs which get fix soon.\nThanks for you patient");
            Console.WriteLine("Where you want to start game ?" +
                "\n1. Aluas" +
                "\n2. Dangrar" +
                "\n3. Sangrar" +
                "\n4. Exit");
            string choose = Console.ReadLine();
            switch (choose)
                    {
                        case "1":
                            if (choose.ToString() == "1")
                            {
                                aluas.HelloAluas();
                            }
                            break;
                        case "2":
                            if (choose.ToString() == "2")
                            {
                                dangrar.HelloDangrar();
                            }
                            break;
                        case "3":
                            if (choose.ToString() == "3")
                            {
                                sangrar.HelloSangrar();
                            }
                            break;                        
                        case "4":
                            if (choose.ToString() == "4")
                            {
                                Environment.Exit(0);
                            }
                            break;
            }
            Console.ReadLine();
            Console.ReadLine();
        }
    }
}


   

