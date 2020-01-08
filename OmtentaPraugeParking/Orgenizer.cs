using System;
using System.Collections.Generic;
using System.Text;

namespace OmtentaPraugeParking
{
    class Orgenizer
    {
        private const uint Want_To_SetRegnr = 1;
        private const uint Want_To_setVehicleType = 2;
        private const int Not_Same_RegNr = -1;
        private const uint Want_To_MoveVehicle = 4;
        private ParkingLot parkingLot;

        public ParkingLot Parking
        {
            get{ return parkingLot;}
            set { parkingLot = value;}
        }

        public void AddNewVehicle()
        {
            Console.Write("Enter Regnr for the vehicle you want to add");
            Visualize.TextColor(Visualize.ColorType.Green, ":>_ ");
            Visualize.TextColor(Visualize.ColorType.Black, "");

            string regnr = SendToUserInput(Want_To_SetRegnr);

            if (!string.IsNullOrEmpty(regnr))
            {
                if (parkingLot.Contains(regnr) == Not_Same_RegNr)
                {
                    Console.Write("Is it a Car ");
                    Visualize.TextColor(Visualize.ColorType.Red, "Y");
                    Visualize.TextColor(Visualize.ColorType.Black, "/");
                    Visualize.TextColor(Visualize.ColorType.Red, "N ");
                    Visualize.TextColor(Visualize.ColorType.Green, ":>_ ");
                    Visualize.TextColor(Visualize.ColorType.Black, "");

                    string type = SendToUserInput(Want_To_setVehicleType);

                    if (!string.IsNullOrEmpty(type))
                    {
                        if (type == "Y")
                          parkingLot.CreateNewVehicle(regnr, VehicleType.Car);
                        if (type == "N")
                           parkingLot.CreateNewVehicle(regnr, VehicleType.Bike);
                            

                        BackUp.SaveDataToBin(parkingLot);
                    }
                }
                else
                {
                    Visualize.TextColor(Visualize.ColorType.Red, $"\nVehicle {regnr} already excist");
                    Visualize.TextColor(Visualize.ColorType.Black, "");
                    Console.ReadKey();
                }
                
            }

        }

        public static string SendToUserInput(uint n)
        {
            string input = null;
            try
            {
                return input = UserInput.HandleInput(n);
            }
            catch (ArgumentException e)
            {
                Visualize.TextColor(Visualize.ColorType.Red,e.Message);
                Visualize.TextColor(Visualize.ColorType.Black, "");
                Console.ReadKey();
            }
            finally
            {

            }
            return null;
        }

        public void ShowAllVehicles()
        {
            Console.Clear();
            parkingLot.Print();
            Console.ReadKey();
        }

        public void RemoveVehicle()
        {
            Console.Write("Enter Regnr for the vehicle you want to remove");
            Visualize.TextColor(Visualize.ColorType.Green, ":>_ ");
            Visualize.TextColor(Visualize.ColorType.Black, "");

            string regnr = SendToUserInput(Want_To_SetRegnr);
            if (!string.IsNullOrEmpty(regnr))
            { 
                    Console.Write(parkingLot.Remove(regnr));
                    BackUp.SaveDataToBin(parkingLot);
                    Console.ReadKey();
            }
        }

        public void SearchForVehicle()
        {
            Console.Write("Enter Regnr for the vehicle you want to search for");
            Visualize.TextColor(Visualize.ColorType.Green, ":>_ ");
            Visualize.TextColor(Visualize.ColorType.Black, "");
            string regnr = SendToUserInput(Want_To_SetRegnr);
            if (!string.IsNullOrEmpty(regnr))
            {
                Console.WriteLine(parkingLot.SearchForVehicle(regnr));
                Console.ReadKey();
            }
        }
        //borked
        public void MoveVehicle()
        {
            Console.Write("Enter Regnr for the vehicle you want to search for");
            Visualize.TextColor(Visualize.ColorType.Green, ":>_ ");
            Visualize.TextColor(Visualize.ColorType.Black, "");

            string regnr = SendToUserInput(Want_To_SetRegnr);
            if (!string.IsNullOrEmpty(regnr))
            {
                if (parkingLot.Contains(regnr) != -1)
                {
                    Console.Write("Enter a new box number between");
                    Visualize.TextColor(Visualize.ColorType.Red, " 1-100");
                    Visualize.TextColor(Visualize.ColorType.Green, ":>_ ");
                    Visualize.TextColor(Visualize.ColorType.Black, "");

                    string input = SendToUserInput(Want_To_MoveVehicle);
                    if (!string.IsNullOrEmpty(input))
                    {
                        int toInt = int.Parse(input);
                        Console.Write(parkingLot.CreateNewBox(regnr,toInt-1));
                        BackUp.SaveDataToBin(parkingLot);
                        Console.ReadKey();
                    }
                }
                else
                {
                    Visualize.TextColor(Visualize.ColorType.Red, $"\nVehicle { regnr} not found!");
                    Visualize.TextColor(Visualize.ColorType.Black, "");
                    Console.ReadKey();
                }
              
            
            }

        }

    }
}
