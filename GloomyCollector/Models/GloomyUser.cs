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
        //changed from public override string Id {Get; set;}
        public int Id { get; set; }

        //public string Id { get; set; }

      /*public GloomyUser(string Id)
        {
            this.Id = Id;
        }*/

    }
}

        //public string Name { get; set; }

        


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
        }

    }
}*/
