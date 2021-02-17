using System;
using System.Collections.Generic;
using GloomyCollector.Models;

namespace GloomyCollector.ViewModels
{
    public class MyWishListViewModel
    {
        public int GloomyId { get; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string Year { get; set; }
        public string ImageData { get; set; }

        public MyWishListViewModel(Gloomy theGloomy)
        {
            GloomyId = theGloomy.Id;
            Name = theGloomy.Name;
            SerialNumber = theGloomy.SerialNumber;
            Year = theGloomy.Year;
            ImageData = theGloomy.ImageData;
        }
        //public List<Wishist>
        //gloomy info

        /*public MyWishListViewModel(List<int> gloomyIds){
            for (var i = 0; i < gloomyIds.Count; i++) {
            }*/
        public string TagText { get; set; }
            public MyWishListViewModel(List<WishList> gloomyIds)
            {

                TagText = "";

                for (var i = 0; i < gloomyIds.Count; i++)
                {
                    TagText += "#" + gloomyIds[i].GloomyId;

                    if (i < gloomyIds.Count - 1)
                    {
                        TagText += ", ";
                    }
                }
            
        }
    }
}
