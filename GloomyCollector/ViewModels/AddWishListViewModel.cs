using System;
using System.Collections.Generic;
using GloomyCollector.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GloomyCollector.ViewModels
{
    public class AddWishListViewModel
    {
        public string UserId { get; set; }
        public GloomyUser GloomyUser { get; set; }

        public List<SelectListItem> Gloomies { get; set; }

        public int GloomyId { get; set; }

        //public string GloomyUserId { get; set; }

        public AddWishListViewModel(GloomyUser gloomyUser, List<Gloomy> possibleGloomies)
        {
            Gloomies = new List<SelectListItem>();

            foreach(var gloomie in possibleGloomies)
            {
                Gloomies.Add(new SelectListItem
                {
                    Value = gloomie.Id.ToString(),
                    Text = gloomie.Name
                });
            }

            GloomyUser = gloomyUser;
        }
        public AddWishListViewModel()
        {
        }
    }
}
