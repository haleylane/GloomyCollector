using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GloomyCollector.Models
{
    [Table("WishLists")]
    public class WishList
    {
        public string UserId { get; set; }
        public GloomyUser GloomyUser { get; set; }

        public int GloomyId { get; set; }
        public Gloomy Gloomy { get; set; }


        //this links a user to multiple gloomy objects
        public WishList()
        {
            
        }
    }
}
