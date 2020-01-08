using System;
using System.Collections.Generic;
using System.Text;

namespace OmtentaPraugeParking
{
    class Visualize
    {
        private static ParkingLot parkingLot;
        public static void TextColor(ColorType type, string text)
        {
            switch (type)
            {
                case ColorType.Green:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(text);
                    break;
                case ColorType.Black:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(text);
                    break;
                case ColorType.Red:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(text);
                    break;
                case ColorType.Blue:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write(text);
                    break;
                case ColorType.Magenta:
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write(text);
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Something went Wrong!!");
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
            }
        }

        public static void VisualizeMenu()//give color and style to main menu
        {

            //welcome screen
            TextColor(ColorType.Black, ("Welcome to prague parking menu || Added vehicles "));
            TextColor(ColorType.Red, $"{AddedVehicles}");

            //to exit
            TextColor(ColorType.Blue, "\nPress");
            TextColor(ColorType.Red, " 0 ");
            TextColor(ColorType.Green, " : ");
            TextColor(ColorType.Black, "To ");
            TextColor(ColorType.Magenta, "Exit ");


            //button one
            TextColor(ColorType.Blue,"\nPress");
            TextColor(ColorType.Red," 1 ");
            TextColor(ColorType.Green," : ");
            TextColor(ColorType.Black, "To ");
            TextColor(ColorType.Magenta,"Add ");


            //button two
            TextColor(ColorType.Blue, $"\nPress"); 
            TextColor(ColorType.Red, " 2 ");
            TextColor(ColorType.Green, " : ");
            TextColor(ColorType.Black, "To ");
            TextColor(ColorType.Magenta, "Remove ");


            //button three
            TextColor(ColorType.Blue, $"\nPress");
            TextColor(ColorType.Red, " 3 ");
            TextColor(ColorType.Green, " : ");
            TextColor(ColorType.Black, "To ");
            TextColor(ColorType.Magenta, "Show All");

            //button four
            TextColor(ColorType.Blue, $"\nPress");
            TextColor(ColorType.Red, " 4 ");
            TextColor(ColorType.Green, " : ");
            TextColor(ColorType.Black, "To ");
            TextColor(ColorType.Magenta, "Search ");


            //button five
            TextColor(ColorType.Blue, $"\nPress");
            TextColor(ColorType.Red, " 5 ");
            TextColor(ColorType.Green, " : ");
            TextColor(ColorType.Black, "To ");
            TextColor(ColorType.Magenta, "Move ");

            //users input
            TextColor(ColorType.Green,"\n:> ");
            TextColor(ColorType.Black, "");


        }

        private static int AddedVehicles//show how meny vehicles the user has added
        {
            get
            { 
                parkingLot = BackUp.LoadDataFromBin();
                return parkingLot.VehiclesAdded;
            }
        }

        public enum ColorType
        {
            Green,
            Red,
            Black,
            Blue,
            Magenta,
        }
    }
}
