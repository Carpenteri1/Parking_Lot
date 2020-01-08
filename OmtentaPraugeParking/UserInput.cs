using System;
using System.Collections.Generic;
using System.Text;

namespace OmtentaPraugeParking
{
    class UserInput
    {
        public static string HandleInput(uint input)
        {
            switch (input)
            {
                case 1:
                    return SetRegForVehicle();
                case 2:
                    return SetVehicleType();
                case 3:
                    return MenuInput();
                case 4:
                    return HandleMove();
                default:
                    Console.Clear();
                    throw new ArgumentException("Something went wrong when handling input!");
                    break;
            }
            return null;
        }

        public static string SetRegForVehicle()
        {
            string regnr = Console.ReadLine().ToUpper().Replace(" ", "");
            if (string.IsNullOrEmpty(regnr) || regnr.Length > 10)
                throw new ArgumentException("regnr to long or empty");

            return regnr;
        }

        public static string SetVehicleType()
        {
            string setType = Console.ReadLine().ToUpper();
            if (string.IsNullOrEmpty(setType) || setType.Length > 1)
                throw new ArgumentException("Input to long or empty");
            else
            {
                if (setType.Equals("Y"))
                    return "Y";
                if (setType.Equals("N"))
                    return "N";
                else if (!setType.Equals("Y") || !setType.Equals("N"))
                    throw new ArgumentException("Incorrect input");
            }
            return null;
        }

        public static string HandleMove()
        {
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Input cant be empty");

            int toInt = int.Parse(input);
            if (toInt < 1 || toInt > 100)
                throw new ArgumentException("Input must be between 1 - 100 ");

            return input;
        }
        public static string MenuInput()
        {
            return Console.ReadLine();
        }
    }
}
