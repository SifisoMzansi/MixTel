namespace MixAssessment2.Calculator
{
    public class DistanceCalc: IDisposable
    {
        static List<ICoordinate> _defaultCoordinates;

        //This is so that we only create the constants once. When creating the class .
        //Alternative is to implement singleton. But I prefer this for this implementation. 
        public DistanceCalc()
        { 
            _defaultCoordinates = new List<ICoordinate>()
            {
                new Coordinate() { Latitude = 34.544909, Longitude = -102.100843 },
                new Coordinate() { Latitude = 32.345544, Longitude = -99.123124 },
                new Coordinate() { Latitude = 33.234235, Longitude = -100.214124 },
                new Coordinate() { Latitude = 35.195739, Longitude = -95.348899 },
                new Coordinate() { Latitude = 31.895839, Longitude = -97.789573 },
                new Coordinate() { Latitude = 32.895839, Longitude = -101.78957 },
                new Coordinate() { Latitude = 34.115839, Longitude = -100.22573 },
                new Coordinate() { Latitude = 32.335839, Longitude = -99.992232 },
                new Coordinate() { Latitude = 33.535339, Longitude = -94.792232 },
                new Coordinate() { Latitude = 32.234235, Longitude = -100.22222 }
            };
        }

        /// <summary>
        /// Retuns a result of the closest coordinate. 
        /// </summary>
        /// <param name="carCoordinates"></param>
        /// <returns></returns>
        public  Result CalculateClosestDistance(ICoordinate carCoordinates)
        {
            //Logger.WriteMessage("---Begin---");
            //Avoid for loop.                     
            //This will agregate the results for the whole collection instead of instead of looping through each record. 
            var results = _defaultCoordinates
                .Select(coordinate =>
                {  
                    double DistanceSquared = CalculateDistanceSquared(carCoordinates , coordinate);
                    //Leaving this so that you can uncomment to compate the output with the result. I am only output the 
                    //You will also have to remove the Task.Run
                    //Console.WriteLine($"carCoordinates - {carCoordinates.Latitude} {carCoordinates.Longitude}");
                    //Console.WriteLine($"Default coordinate - {coordinate.Latitude} {coordinate.Longitude}");
                    return new Result { Distance = DistanceSquared, ClosestCoordinates = coordinate };
                })
                .MinBy(result => result.Distance);

            double distance = Math.Sqrt(results.Distance);

            //Leaving this so that you can uncomment to compate the output with the result. I am only output the 
            //You will also have to remove the Task.Run
            //Console.WriteLine($"Default coordinate - {results.ClosestCoordinates.Latitude} {results.ClosestCoordinates.Longitude}");
            //Console.WriteLine($"------------------------End---------------------------");
            return new Result { Distance = distance, ClosestCoordinates = results.ClosestCoordinates };
        }

        double CalculateDistanceSquared(ICoordinate carCoordinates , ICoordinate defaultCoordinate)
        {
            double latitudeDiff = defaultCoordinate.Latitude - carCoordinates.Latitude;
            double longitudeDiff = defaultCoordinate.Longitude - carCoordinates.Longitude;
            return latitudeDiff * latitudeDiff + longitudeDiff * longitudeDiff;          

        }

        // Leaving this so that you can see how I was doing the calcs before. This is how I was looping before. 
        //Looping through the 10 coordinates
        //       

        //    List<Result> Results = new List<Result>();
        //            for (int Count = 0; Count<_defaultCoordinates.Count; ++Count)
        //            {
        //              double LatitudeDiff = _defaultCoordinates[Count].Latitude - carCoordinates.Latitude;
        //    double LongitudeDiff = _defaultCoordinates[Count].Longitude - carCoordinates.Longitude;
        //    double Distance = Math.Sqrt(LatitudeDiff * LatitudeDiff + LongitudeDiff * LongitudeDiff);
        //    Results.Add(new Result() { Distance = Distance, ClosestCoordinates = _defaultCoordinates[Count] });
        //            }
        //return Results.Min(x => x);          
        //        }
        public void Dispose()
        { 
        }
    }
}
