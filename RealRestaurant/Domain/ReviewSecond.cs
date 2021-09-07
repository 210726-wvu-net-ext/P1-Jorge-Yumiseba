using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ReviewSecond
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Comment { get; set; }
        public decimal Rating { get; set; }
        public int RestaurantId { get; set; }

        public ReviewSecond()
        {

        }
        public ReviewSecond(int id)
        {
            this.Id = id;
        }


        public ReviewSecond(string name, string comment, decimal rating, int restaurantid)
        {
            
            this.Name = name;
            this.Comment = comment;
            this.Rating = rating;
            this.RestaurantId = restaurantid;


        }



    }
}
