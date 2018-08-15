using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";
        //comment
        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: ");

            var parser = new TacoParser();
            var locations = lines.Select(parser.Parse);

            double distance = 0;
            double maxDistance = 0;
            string store1 = "";
            string store2 = "";

            foreach(var line in locations)
            {
                GeoCoordinate cordA = new GeoCoordinate();

                cordA.Latitude = line.Location.Latitude;
                cordA.Longitude = line.Location.Longitude;

                foreach(var line2 in locations)
                {
                    GeoCoordinate cordB = new GeoCoordinate();

                    cordB.Latitude = line2.Location.Latitude;
                    cordB.Longitude = line2.Location.Longitude;
                    distance = cordA.GetDistanceTo(cordB);

                    if (maxDistance < distance)
                    {
                        store1 = line.Name;
                        store2 = line2.Name;

                        maxDistance = distance;
                    }
                }
            }
            Console.WriteLine($"{store1}, {store2}, {maxDistance}");

            Console.ReadLine();
        }
    }
}