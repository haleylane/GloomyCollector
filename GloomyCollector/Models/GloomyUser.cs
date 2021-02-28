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
        
        public int Id { get; set; }

   

    }
}

       
