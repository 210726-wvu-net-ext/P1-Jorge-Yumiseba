using System;
using System.Collections.Generic;

#nullable disable

namespace DataLayer.Entities
{
    public partial class UserInformation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
