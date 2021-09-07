using System;
using System.Collections.Generic;

#nullable disable

namespace DataLayer.Entities
{
    public partial class ReviewSecond
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public decimal Rating { get; set; }
        public int RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}
