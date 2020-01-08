using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace OmtentaPraugeParking
{
    class BackUp
    {
        private static string backUpPath = @"..\..\..\..\";
        private static string backUpFile = "backup.bin";
        private static string serializationFile = Path.Combine(backUpPath, backUpFile);

        public static object Open { get; private set; }

        //Serialize and creates file.
        public static void SaveDataToBin(ParkingLot boxes)
        {
            using (Stream stream = File.Open(serializationFile, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, boxes);
                stream.Close();
            }
        }
        //deserialize file from binary format
        public static ParkingLot LoadDataFromBin()
        {
            ParkingLot po = new ParkingLot();
            try
            {
                using (Stream stream = File.Open(serializationFile, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    po = (ParkingLot)formatter.Deserialize(stream);
                    stream.Close();
                }
            }
            catch (FileNotFoundException)//if backup file doesnt excist, call the serialize method do create one
            {
                SaveDataToBin(po);
            }
            return po;
        }
    }
}
