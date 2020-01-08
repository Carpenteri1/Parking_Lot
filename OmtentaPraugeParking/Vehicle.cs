using System;
using System.Xml.Serialization;

namespace OmtentaPraugeParking
{
    [Serializable()]
    public class Vehicle
    {
        private readonly string regnr;
        private VehicleType vehicleType;
        private DateTime timeArrived;
        private static Vehicle thisVehicle;
        public Vehicle(string regnr,VehicleType vehicleType)
        {
            this.regnr = regnr;
            this.vehicleType = vehicleType;
            timeArrived = DateTime.Now;
        }
        public bool Contains(VehicleType type)
        {
            if (this.VehicleType == type)
                return true;
            return false;
        }

        public Vehicle ThisVehicle
        {
            get { return thisVehicle;}
        }


        public VehicleType VehicleType
        {
            get { return vehicleType; }
        }

        public string Regnr
        {
            get { return regnr;}
        }

        public DateTime TimeArrived
        {
            get { return timeArrived; }
        }

        public string TimeParked
        {
            get
            {
                TimeSpan duration;
                TimeSpan timespan = DateTime.Now.Subtract(Convert.ToDateTime(TimeArrived));
                string formatted = timespan.ToString(@"dd\.hh\:mm\:ss");

                return formatted;
            }
        }

        public override string ToString()
        {
            return $"Vehicle Regnr: {regnr} Vehicle is: {VehicleType}";
        }
    }
}
