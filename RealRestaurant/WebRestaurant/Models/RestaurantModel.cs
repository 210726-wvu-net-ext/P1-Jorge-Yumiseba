using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Domain;


namespace WebRestaurant.Models
{
    public class RestaurantModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string Cuisine { get; set; }
        public decimal Rating { get; set; }
        public List<Review> Reviews { get; set; }


    }
}
