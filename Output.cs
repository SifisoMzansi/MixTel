using MixAssessment2.Calculator;
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixAssessment2
{
    public class CalcEngine
    {
        public static void DoVehiclePositionCalculation()
        {
            using (var MyCalc = new DistanceCalc())
            {
                var InputData = FileProcessor.ReadFile();
                int Offset = 0, Counter = 0; int ID = 0;
                float Latitude = 0, Longitude = 0; 

                StringBuilder SBRegistration = new StringBuilder();

                while (Offset < InputData.Length)
                {
                    Counter++;
                    ID = BitConverter.ToInt32(InputData, Offset);
                    Offset += 4;
                    while (InputData[Offset] != 0)
                    {
                        SBRegistration.Append(InputData[Offset]);
                        Offset++;
                    }
                    Offset++;
                    Latitude = BitConverter.ToSingle(InputData, Offset);
                    Offset += 4;
                    Longitude = BitConverter.ToSingle(InputData, Offset);
                    Offset += 4;              
                    Offset += 8;

                    var Result =  MyCalc.CalculateClosestDistance(new Coordinate() { Latitude = Latitude, Longitude = Longitude });
                    Logger.WriteMessage($"Car Latt {Latitude} Car Long {Longitude}");
                    Logger.WriteMessage($"Closest coordinate {Result.ClosestCoordinates.Latitude}, {Result.ClosestCoordinates.Longitude}", Counter);
                }
            }
        }

        
      
    }


}
