using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRestaurant.Models
{
    public class WebUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
