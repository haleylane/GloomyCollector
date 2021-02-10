using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace GloomyCollector.Models
{
    public class GloomyUser : IdentityUser
    {
        public string FirstName { get; set; }
        public List<Gloomy> WishList { get; set; }

        //public string Name { get; set; }

        //public int Id { get; set; }


        /*public GloomyUser(List<Gloomy> wishList)
        {
            WishList = wishList;
        }

        public GloomyUser()
        {
         
        }

        public override bool Equals(object obj)
        {
            return obj is GloomyUser user &&
                   Id == user.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }*/

    }
}
