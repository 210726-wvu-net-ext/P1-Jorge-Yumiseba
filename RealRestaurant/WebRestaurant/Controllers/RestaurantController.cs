using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRestaurant.Controllers
{
    public class RestaurantController : Controller
    {
      
        private readonly IDL _repo;

        public RestaurantController( IDL repo)
        {
         
            _repo = repo;
        }
        public IActionResult Index()
        {

            return View(_repo.GetRestaurants());
        }

        public IActionResult DetailsCreate(string name)
        {

            //get repo implementation to only get one note
            return View(_repo.GetRestaurants().Last(x => x.Name == name));

        }

        public IActionResult DetailsSearch(string name)
        {

            //get repo implementation to only get one note
           
            try
            {
                return View(_repo.GetRestaurants().First(x => x.Name.Contains(name)));
            }
                catch(Exception)
            {
                return View("ErrorMessage", model: "There is not Restaurant with the parameters you specified!");
            }
            
        }

      
        public IActionResult Details(int id)
        {

            var res = _repo.GetRestaurants().FirstOrDefault(x => x.Id  == id);
          
            return View(res);
    
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var delbefore = _repo.GetRestaurants().FirstOrDefault(x => x.Id == id);

            return View(delbefore);

        }
        [HttpPost]
        public IActionResult Delete(Restaurant restaurant)
        {

              _repo.DeleteRestaurant(restaurant);

            
            return View("DetailsDelete", new { id = restaurant.Id });

        }
        [HttpGet]
        public IActionResult SearchRestaurant()
        {
            return View();

        }
        [HttpPost]
        public IActionResult SearchRestaurant(string SearchRes)
       {

            if(SearchRes == null)
            {
                return View("ErrorMessage", model: "Please insert something");
            }
         
             _repo.SearchRestaurant(SearchRes);

            return RedirectToAction("DetailsSearch", new { name = SearchRes});
        }

        [HttpGet]
        public IActionResult CreateRestaurant()
        {
            return View();

        }
        [HttpPost] //form submission
        public IActionResult CreateRestaurant(Restaurant restaurant)
        {
            //ASP.NET "model binding"
            //-fill in action method parameters with data from the request
            // (ULR  path, URL query string, form data, etc - autimatically
            //based on compatible data type and name
            // _repo = AddUser(customer);

            _repo.AddRestaurant(restaurant);

            //return View("details",customer) // not refreshable
            return RedirectToAction("DetailsCreate", new { name = restaurant.Name });

        }
    }
}
