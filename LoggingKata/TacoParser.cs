using System;
namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            var cells = line.Split(',');

            if (cells.Length < 3)
            {
                return null;
            }

            //TacoBell company = new TacoBell();
            //Point localtacobell = new Point();

            //for (int i = 0; i < cells.Length; i++)
            //{
            //    if(string.IsNullOrWhiteSpace(cells[i]))
            //    {
            //        return null;
            //    }
            //    if (i == 0)
            //    {
            //        localtacobell.Latitude = double.Parse(cells[i]);
            //    }
            //    else if (i == 1)
            //    {
            //        localtacobell.Longitude = double.Parse(cells[i]);
            //    }
            //    else if (i == 2)
            //    {
            //        company.Name = cells[i];
            //    }
            //}
            //return company;



            string lat = cells[0];
            string lon = cells[1];
            string city = cells[2];

            double _lat = double.Parse(lat);
            double _lon = double.Parse(lon);

            TacoBell bell1 = new TacoBell();
            bell1.Name = city;
            bell1.Location = new Point { Latitude = _lat, Longitude = _lon };

            return bell1;
        }
    }
}