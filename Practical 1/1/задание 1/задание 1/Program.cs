using System;
using System.Globalization;


namespace задание_1
{
    public class City
    {
        public string Name;

        public override string ToString()
        {
            return Name;
        }

        public GeoLocation Location;
    }
    public class GeoLocation
    {
        public double Location;
        public double Longitude;
        public double Latitude;


    }
    class Program
    {
        static void Main(string[] args)
        {
            var city = new City();
            city.Name = "Ekaterinburg";
            Console.WriteLine(city);
            city.Location = new GeoLocation();
            city.Location.Latitude = 56.50;
            city.Location.Longitude = 60.35;
            Console.WriteLine("I love {0} located at ({1}, {2})",
                city.Name,
                city.Location.Longitude.ToString(CultureInfo.InvariantCulture),
                city.Location.Latitude.ToString(CultureInfo.InvariantCulture));
        }
    }
}




