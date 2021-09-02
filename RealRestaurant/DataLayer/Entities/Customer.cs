using System;
using System.Collections.Generic;

#nullable disable

namespace DataLayer.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public double Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
