using System;
using System.Collections.Generic;
using System.Linq;

namespace OmtentaPraugeParking
{
    [Serializable()]
    public class ParkingBox
    {
        private List<Vehicle> vehicles = new List<Vehicle>();
        private Vehicle savedVehicleInfo;
        private int slotPosition;
        public ParkingBox(int slotPosition)
        {
            this.slotPosition = slotPosition;
        }

   
        public List<Vehicle> Vehicles
        {
            get { return vehicles;}
        }

        public bool Add(Vehicle newVehicle)
        {
            if (!IsBoxFull(newVehicle))
            {
                vehicles.Add(newVehicle);
                return true;
            }
            return false;
        }

        private bool IsBoxFull(Vehicle newVehicle)
        {
            if (newVehicle.VehicleType == VehicleType.Car)
            {
                if (vehicles.Count < 1)
                {
                    return false;
                }
                return true;
            }

            if (newVehicle.VehicleType == VehicleType.Bike &&
                !Contains(VehicleType.Car))
            {
                if (vehicles.Count < 2)
                {
                    return false;
                }
                return true;
            }
            return true;
        }

        private bool Contains(VehicleType vehicleType)
        {
            savedVehicleInfo = Search(vehicleType);
            if(savedVehicleInfo != null)
                if (savedVehicleInfo.VehicleType == VehicleType.Car)
                    return true;

            return false;
        }

        public bool Contains(string regnr)
        {
            savedVehicleInfo = Search(regnr);
            if(savedVehicleInfo != null)
                if(savedVehicleInfo.Regnr == regnr)
                    return true;
            
            return false;
        }

        public Vehicle Remove(string regnr)
        {
            savedVehicleInfo = Search(regnr);
            if (savedVehicleInfo != null)
            {
                vehicles.Remove(Search(regnr));
                return savedVehicleInfo;
            }
            return null;
        }

        public Vehicle Search(string regnr)
        {
            foreach(var s in vehicles.ToList())
            {
                if (s.Regnr == regnr)
                    return s;
            }
            return null;
        }

        public Vehicle Search(VehicleType vehicleType)
        {
            foreach (var s in vehicles.ToList())
            {
                if (s.VehicleType == VehicleType.Car)
                    return s;
            }
            return null;
        }

        public Vehicle Move(string regnr)
        {
            return Search(regnr);
        }

        public void Print()
        {
            foreach(var s in vehicles)
            {
                Console.Write($"Box Position: {slotPosition+1} {s}\n");
            }
        }

    }
}
