using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebRestaurant.Models;
using Microsoft.Extensions.Logging;

namespace WebRestaurant.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly ILogger<RestaurantController> _logger;
        private readonly IDL _repo;

        public RestaurantController(ILogger<RestaurantController> logger, IDL repo)
        {
            _logger = logger;
            _repo = repo;
        }

    
        public IActionResult Index()
        {

            return View(_repo.GetRestaurants());
        }

        //[HttpGet("login")]
        //public IActionResult Login()
        //{
          
        //    return View();
        //}

        //[HttpPost("login")]
        //public IActionResult Validate(string username, string password)
        //{ 
        //    if(username == "bob" && password == "pizza")
        //    {
        //        return Ok();
        //    }
        //    return BadRequest();
        //}


        public IActionResult DetailsCreate(string name)
        {

            //get repo implementation to only get one note
            return View(_repo.GetRestaurants().Last(x => x.Name == name));

        }

        //public IActionResult DetailsDelete(int id)
        //{

            
        //    return View(_repo.GetRestaurants().Last(x => x.Id == id));

        //}

        public IActionResult DetailsSearch(string name)
        {

            //get repo implementation to only get one note
           
            try
            {
                return View(_repo.GetRestaurants().First(x => x.Name.Contains(name)));
            }
                catch(Exception)
            {
                _logger.LogError("Invalid Search was introduced");
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

            _logger.LogInformation("Information has been deleted => RestaurantDatabase");

            return View("DetailsDelete");

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

        [HttpGet]
        public IActionResult CreatSuggestion()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSuggestion(Suggestion suggestion)
        {

            _repo.AddSuggestion(suggestion);

            return View("Index");

        }



    }
}
