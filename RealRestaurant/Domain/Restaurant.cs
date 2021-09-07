using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string Cuisine { get; set; }
        public decimal Rating { get; set; }
        public List<Review> Reviews { get; set; }
        public List<ReviewSecond> Reviewseconds { get; set; }
        public Restaurant()
        {

        }
        public Restaurant(string name)
        {
            this.Name = name;
        }
        public Restaurant(int id, string name)
        {
            this.Name = name;
            this.Id = id;
        }
        public Restaurant(int id, string name, string address, string city, string state, int zipcode, string cuisine, decimal rating)
        {
            this.Name = name;
            this.Id = id;
            this.City = city;
            this.Cuisine = cuisine;
            this.Address = address;
            this.State = state;
            this.ZipCode = zipcode;
            this.Rating = rating;
        }

        public static Task FirstOrDefaultAsync(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }

        public Restaurant(string name, string address, string city, string state, int zipcode, string cuisine, decimal rating)
        {
            this.Name = name;

            this.City = city;
            this.Cuisine = cuisine;
            this.Address = address;
            this.State = state;
            this.ZipCode = zipcode;
            this.Rating = rating;
        }

    }
}
