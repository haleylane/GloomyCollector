using System;
using System.Collections.Generic;
using GloomyCollector.Models;

namespace GloomyCollector.ViewModels
{
    public class MyWishListViewModel
    {
        
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
