using System;
using System.Collections.Generic;
using System.Text;

namespace OmtentaPraugeParking
{
    class CalculatePrice
    {
        private static int cost;
        private const uint fiveMin = 5;
        private const uint sixtyMin = 60;

        public static int Price(Vehicle vehicle)
        {
            if (vehicle.VehicleType == VehicleType.Car)
            {
                if (TimeParked(vehicle).TotalMinutes > fiveMin && TimeParked(vehicle).TotalMinutes < ((sixtyMin * 2)-fiveMin))
                {
                    return cost = 40;
                }
                else if (TimeParked(vehicle).TotalMinutes > ((sixtyMin*2) + fiveMin))
                {
                    int hours = (int)TimeParked(vehicle).TotalHours;
                    return cost = hours*20;
                }
            }

            if (vehicle.VehicleType == VehicleType.Bike)
            {
                if (TimeParked(vehicle).TotalMinutes > fiveMin && TimeParked(vehicle).TotalMinutes < ((sixtyMin*2)-fiveMin))
                {
                        return cost = 20; 
                }
                else if (TimeParked(vehicle).TotalMinutes > ((sixtyMin*2) + fiveMin))
                {
                    int hours = (int)TimeParked(vehicle).TotalHours;
                    return  cost = hours*10;
                }
            }
            return cost;
        }

        public static TimeSpan TimeParked(Vehicle vehicle)
        {
            return DateTime.Now.Subtract(vehicle.TimeArrived);
        }
    }
}
