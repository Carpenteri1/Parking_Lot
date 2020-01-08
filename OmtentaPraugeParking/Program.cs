using System;
/*
 * Author:Niclas Timle
 * 01-08-2020
 * School:Campus Varberg - SUT19 
 */

namespace OmtentaPraugeParking
{
    class Program
    {
        private const uint Handle_Menu = 3;
        Orgenizer orgenize = new Orgenizer();
        private bool isRunning = true;
        Program()
        {
            Console.Title = "Prauge Parking <3";
            Console.BackgroundColor = ConsoleColor.Yellow;
            orgenize.Parking = BackUp.LoadDataFromBin();
            while (isRunning)
            {
                Console.Clear();
                Visualize.VisualizeMenu();
                switch (UserInput.HandleInput(Handle_Menu))
                {
                    case "1":
                        orgenize.AddNewVehicle();
                        break;
                    case "2":
                        orgenize.RemoveVehicle();
                        break;
                    case "3":
                        orgenize.ShowAllVehicles();
                        break;
                    case "4":
                        orgenize.SearchForVehicle();
                        break;
                    case "5":
                        orgenize.MoveVehicle();
                        break;
                    case"0":
                        Console.Clear();
                        Visualize.TextColor(Visualize.ColorType.Magenta, "\nClosing....\n\n");
                        Visualize.TextColor(Visualize.ColorType.Black, "");
                        isRunning = false;
                        break;
                    default:
                        Visualize.TextColor(Visualize.ColorType.Red, "Error! Wrong input!");
                        Console.ReadKey();
                        Visualize.TextColor(Visualize.ColorType.Black,"");
                        break;
                }
            }
        }

        public static void Main(string[] args)
        {
            new Program();
        }
    }
}
