using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Review
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Comments { get; set; }
        public int Rating { get; set; }
        public int RestaurantId { get; set; }
        public Review()
        {

        }
        public Review(int userid)
        {
            this.UserId = userid;
        }
        // public Review(string user)
        // {
        //  this.Users=user;
        // }
        public Review(int userid, string comments, int rating, int restauraintid)
        {
            this.UserId = userid;
            this.RestaurantId = restauraintid;
            this.Comments = comments;
            this.Rating = rating;
        }
    }
}
