using System;
namespace GloomyCollector.Models
{
    public class WishList
    {
        public int UserId { get; set; }
        public GloomyUser GloomyUser { get; set; }

        public int GloomyId { get; set; }
        public Gloomy Gloomy { get; set; }


        //this links a user to multiple gloomy objects
        public WishList()
        {
            
        }
    }
}
