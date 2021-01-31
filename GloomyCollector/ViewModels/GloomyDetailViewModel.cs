using System;
using GloomyCollector.Models;
using System.Collections.Generic;

namespace GloomyCollector.ViewModels
{
    public class GloomyDetailViewModel
    {
        public int GloomyId { get; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string Year { get; set; }
        public string ImageData { get; set; }

        public GloomyDetailViewModel(Gloomy theGloomy)
        {
            GloomyId = theGloomy.Id;
            Name = theGloomy.Name;
            SerialNumber = theGloomy.SerialNumber;
            Year = theGloomy.Year;
            ImageData = theGloomy.ImageData;
        }
    }
}
