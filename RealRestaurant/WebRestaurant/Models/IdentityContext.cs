using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRestaurant.Models
{
    public class IdentityContext : IdentityDbContext<WebUser,WebRole,int>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) :base(options)
        {

        }
    }
}
