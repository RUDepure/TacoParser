using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    public class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            //logger.LogInfo("Log initialized");

            
            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            //logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();



            ////First distance we are comparing
            //double firstDistance = 0;
            ////Second distance we are comparing
            //double secondDistance = 0;
            ////Distance we are returning
            //double maxDistance = 0;

            ////First Taco Bell name we are returning
            //int firstTaco = 0;
            ////Second Taco Bell name we are returning
            //int secondTaco = 1;

            ////Initializing distance Coordinates
            //var firstCoord = new GeoCoordinate(locations[0].Location.Latitude, locations[0].Location.Longitude);
            //var secondCoord = new GeoCoordinate(locations[1].Location.Latitude, locations[1].Location.Longitude);

            //firstDistance = firstCoord.GetDistanceTo(secondCoord);


            //for (int i = 0; i < locations.Length; i++)
            //{
            //    for (int j = 0; j < locations.Length; j++)
            //    {
            //        firstCoord.Latitude = locations[i].Location.Latitude;
            //        firstCoord.Longitude = locations[i].Location.Longitude;

            //        secondCoord.Latitude = locations[j].Location.Latitude;
            //        secondCoord.Longitude = locations[j].Location.Longitude;

            //        secondDistance = firstCoord.GetDistanceTo(secondCoord);

            //        if (secondDistance > firstDistance)
            //        {
            //            //returning distance
            //            maxDistance = secondDistance;

            //            //returning taco distances
            //            firstTaco = i;
            //            secondTaco = j;

            //            //makes second distance the next highest value to compare
            //            firstDistance = secondDistance;
            //        }
            //        else
            //            maxDistance = firstDistance;

            //        //Console.WriteLine(firstCoord.GetDistanceTo(secondCoord));
            //    }
            //}

            ITrackable tacoBellA = null;
            ITrackable tacoBellB = null;

            double distance = 0;

            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i].Name; //Ashworth
                var CorA = locations[i].Location;

                for (int j = 0; j < locations.Length; j++)
                {
                    var locB = locations[j].Name;
                    var CorB = locations[j].Location;

                    var spot1 = new GeoCoordinate(CorA.Longitude, CorA.Latitude);
                    var spot2 = new GeoCoordinate(CorB.Longitude, CorB.Latitude);

                    double distanceBetween = spot1.GetDistanceTo(spot2);

                    if (distanceBetween > distance)
                    {
                        tacoBellA = locations[i];
                        tacoBellB = locations[j];
                        distance = distanceBetween;
                    }

                }
            }

            Console.WriteLine("-------------------");
            var milesDistance = distance * 0.000621371192;
            Console.WriteLine(milesDistance);
            Console.WriteLine($"First location: {tacoBellA.Name}, ({tacoBellA.Location.Latitude}, {tacoBellA.Location.Longitude})");
            Console.WriteLine($"Second location: {tacoBellB.Name}, ({tacoBellB.Location.Latitude}, {tacoBellB.Location.Longitude})");




            // DON'T FORGET TO LOG YOUR STEPS

            // Now that your Parse method is completed, START BELOW ----------

            // TODO: Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the farthest from each other.
            // Create a `double` variable to store the distance

            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`

            //HINT NESTED LOOPS SECTION---------------------
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)

            // Create a new corA Coordinate with your locA's lat and long

            // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)

            // Create a new Coordinate with your locB's lat and long

            // Now, compare the two using `.GetDistanceTo()`, which returns a double
            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.

            // TODO: Print out how far the distance is in miles not meters

        }
    }
}
