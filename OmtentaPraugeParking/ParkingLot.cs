using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace OmtentaPraugeParking
{
    [Serializable()]
    public class ParkingLot 
    {
        private ParkingBox[] boxes = new ParkingBox[100];
        private int slotPosition = 0;
        private bool result;
        private int boxElement;
        private int vehicleCount;
        private int slotsLeft;

        
        public ParkingBox[] Boxes
        {
            get { return boxes;}
        }

 
        public int VehiclesAdded
        {
            get
            {
                return vehicleCount;
            }

        }

        public void CreateNewVehicle(string regnr,VehicleType vehicleType)
        {
            Vehicle newVehicle = new Vehicle(regnr,vehicleType);

            if (IsSlotNullOrEmpty())
            {
                boxes[slotPosition] = new ParkingBox(slotPosition);
            }
            slotPosition = AddNewVehicleToSlot(newVehicle);
        }

        private bool IsSlotNullOrEmpty()//checks if a vehicle object excist in any element of the array boxes and if the parkinglot is full
        {
            for(int i = slotPosition;i<boxes.Length;i++)
            {
                try
                {
                    if (boxes[i] == null)
                    {
                        return true;
                    }
                    if (boxes[i].Vehicles.Count > 0)
                    {
                        return false;
                    }
                }catch(IndexOutOfRangeException)
                {
                    Console.Clear();
                    Visualize.TextColor(Visualize.ColorType.Red, "The parkinglot is full, remove a vehicle to make space!");
                    Visualize.TextColor(Visualize.ColorType.Black, "");
                    Console.ReadKey();
                }
                finally
                {
                    
                }
                
            }
            return false;
        }

        private bool IsSlotNullOrEmpty(int slot)
        {
            for (int i = slot; i < boxes.Length; i++)
            {
                if (boxes[i] == null)
                {
                    return true;
                }
                if (boxes[i].Vehicles.Count > 0)
                {
                    return false;
                }
            }
            return false;
        }


        private int AddNewVehicleToSlot(Vehicle newVehicle)
        {
            foreach (var s in boxes)
            {
                result = s.Add(newVehicle);//if result is true, vehicle was successfully added, if not true a new box instance will be created
                if (!result)
                {
                    slotPosition++;
                  
                    if (IsSlotNullOrEmpty())
                    {
                        boxes[slotPosition] = new ParkingBox(slotPosition);
                    }
                }
                else
                {
                    vehicleCount++;
                    Visualize.TextColor(Visualize.ColorType.Green, "\nAdding ");
                    Visualize.TextColor(Visualize.ColorType.Black, "Vehicle Regnr: ");
                    Visualize.TextColor(Visualize.ColorType.Magenta, $"{newVehicle.Regnr} ");
                    Visualize.TextColor(Visualize.ColorType.Black, "");
                    Console.ReadKey();
                    return slotPosition;
                }
                    
            }
            return -1;
        }

        public void Print()
        {
            for (int i = 0; i < boxes.Length; i++)
            {
                if (boxes[i] != null)
                { 
                    boxes[i].Print();//calls print method in parkingboxes
                }      
            }          
        }

        public int Contains(string regnr)//checks if the regnumer is in the database
        {
            for(int i = 0; i < boxes.Length; i++)
            {
                if(boxes[i] != null)
                {
                   if(boxes[i].Contains(regnr))//calls method in parkingbox
                        return i;
                }
               
            }
            return -1;
        }

        public string SearchForVehicle(string regnr)
        {
            boxElement = Contains(regnr);
            if (boxElement != -1)
                return $"Cost: {CalculatePrice.Price(boxes[boxElement].Search(regnr))}$" +
                    $"\nArrivel: {boxes[boxElement].Search(regnr).TimeArrived}" +
                    $"\nTime parked: {boxes[boxElement].Search(regnr).TimeParked}" +
                    $"\nBox Position {boxElement + 1} {boxes[boxElement].Search(regnr)}";

            return $"Vehicle {regnr} not found!";
        }

        public string Remove(string regnr)
        {
            boxElement = Contains(regnr); 
            if(boxElement != -1)
            {
                //Shows all info including cost then remove it
                vehicleCount--;
                return $"Cost: {CalculatePrice.Price(boxes[boxElement].Search(regnr))}$" +
                    $"\nArrivel: {boxes[boxElement].Search(regnr).TimeArrived}" +
                    $"\nTime parked: {boxes[boxElement].Search(regnr).TimeParked}" +
                    $"\nBox Position {boxElement + 1} {boxes[boxElement].Remove(regnr)}" +
                    $"\nWill be removed: ";
            }
            return $"Vehicle {regnr} not found!";
        }

        public string MoveVehicle(string regnr, int input)
        {
            boxElement = Contains(regnr);
            if(boxElement != -1)// kolla om new position är tom eller full
            {
                Vehicle saveVehicleInfo = Boxes[boxElement].Search(regnr);
                result = boxes[input].Add(saveVehicleInfo);
                if (!result)
                {
                    return $"Box Position {input+1} already full";
                }
                saveVehicleInfo = Boxes[boxElement].Remove(regnr);
                return $"Moving Vehicle {saveVehicleInfo.Regnr} from Box Position: {boxElement+1} to Box Position: {input+1}";
            } 
            return $"Vehicle {regnr} not found!";
        }

        public string CreateNewBox(string regnr,int input)
        {

            if (IsSlotNullOrEmpty(input))
            {
                boxes[input] = new ParkingBox(input);
            }
            return MoveVehicle(regnr,input);
        }

    }
}
