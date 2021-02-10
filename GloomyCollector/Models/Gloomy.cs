using System;
namespace GloomyCollector.Models
{
    public class Gloomy
    {
        public string SerialNumber { get; set; }

        public string Name { get; set; }

        public string Year { get; set; }

        public string ImageData { get; set; }

        public int Id { get; set; }

        public Gloomy()
        {

        }

        public Gloomy(string serialNumber, string name, string year, string imageData)
        {
            SerialNumber = serialNumber;
            Name = name;
            Year = year;
            ImageData = imageData;
        }

        public Gloomy (string name)
        {
            Name = name;
        }

        public override string ToString()
        {
                return Name;
        }

        public override bool Equals(object obj)
        {
            return obj is Gloomy gloomy &&
                   Id == gloomy.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }

}
