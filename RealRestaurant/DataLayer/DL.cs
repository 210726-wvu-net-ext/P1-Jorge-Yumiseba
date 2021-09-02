using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DataLayer.Entities;


namespace DataLayer
{
    public class DL : IDL
    {
        private readonly RetP0Context _context;

        public DL(RetP0Context context)
        {
            _context = context;
        }
        public List<Domain.Restaurant> GetRestaurants()
        {
            return _context.Restaurants

                .Select(n => new Domain.Restaurant
                {
                    Id = n.Id,
                    Name = n.Name,
                    Address = n.Address,
                    City = n.City,
                    State = n.State,
                    Cuisine = n.Cuisine,
                    ZipCode = n.ZipCode,
                    Rating = n.Rating
                })
                .ToList();
        }
        public List<Domain.Customer> ListUser()
        {
            return _context.Customers

                .Select(n => new Domain.Customer
                {
                    Id = n.Id,
                    Name = n.Name,
                    LastName = n.LastName,
                    Phone = n.Phone,
                    Email =  n.Email
                })
                .ToList();
        }
        public Domain.Customer AddUser(Domain.Customer x)
        {

            _context.Customers.Add(
                new Entities.Customer
                {
                    Id = x.Id,
                    Name = x.Name,
                    LastName = x.LastName,
                    Phone = x.Phone,
                    Email = x.Email

                }


            );
            _context.SaveChanges();
            return x;


        }
        public Domain.Customer DeleteUser(Domain.Customer x)
        {
            _context.Customers.Remove(
                new Entities.Customer
                {
                    Id = x.Id,
                    Name = x.Name,
                    LastName = x.LastName,
                    Phone = x.Phone,
                    Email = x.Email
                });
            _context.SaveChanges();
            return x;
        }
        public Domain.Review DeleteReview(Domain.Review x)
        {
            _context.Reviews.Remove(
                new Entities.Review
                {
                    Id= x.Id,
                    UserId = x.UserId,
                    Comments = x.Comments,
                   Rating =  x.Rating,
                   RestaurantId =  x.RestaurantId
                }
           
            );
        
            _context.SaveChanges();
            return x;
        }
        public Domain.Restaurant AddRestaurant(Domain.Restaurant a)
        {
            _context.Restaurants.Add(
               new Entities.Restaurant
               {
                   Id = a.Id,
                   Name = a.Name,
                   Address = a.Address,
                   City = a.City,
                   State = a.State,
                   ZipCode = a.ZipCode,
                   Cuisine = a.Cuisine,
                   Rating = a.Rating
               }
            );
            _context.SaveChanges();
            return a;
        }
        public Domain.Restaurant DeleteRestaurant(Domain.Restaurant x)
        {
            Entities.Restaurant resdel = new Entities.Restaurant
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                City = x.City,
                State = x.State,
                ZipCode = x.ZipCode,
                Cuisine = x.Cuisine,
                Rating = x.Rating
            };
            _context.Restaurants.Remove(resdel);
            _context.SaveChanges();
            return x;
           
        }





        public Domain.Restaurant SearchRestaurant(string x)
        {

            Entities.Restaurant found = _context.Restaurants
            .FirstOrDefault(y => y.Name == x);

            if (found != null)
            {
                return new Domain.Restaurant(found.Id, found.Name, found.Address, found.City, found.State, found.ZipCode, found.Cuisine, found.Rating); // you can also return the ID so it can be used later on
            }
            else
            {
                return new Domain.Restaurant();
            }
        }
    }
}
