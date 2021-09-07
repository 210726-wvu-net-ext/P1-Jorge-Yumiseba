using System;
using System.Collections.Generic;

#nullable disable

namespace DataLayer.Entities
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            ReviewSeconds = new HashSet<ReviewSecond>();
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string Cuisine { get; set; }
        public decimal Rating { get; set; }

        public virtual ICollection<ReviewSecond> ReviewSeconds { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
