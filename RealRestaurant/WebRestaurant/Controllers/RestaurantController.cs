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
using Microsoft.AspNetCore.Mvc.Rendering;

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

        //Make even more css
        public IActionResult Index()
        {
            var x = _repo.GetRestaurants();

           

            return View(x);
        }

        //Great 
        [HttpGet]
        public IActionResult Register()
        {
            return View();

        }

        [HttpPost] 
     
        public IActionResult Register(UserInformation customer)
        {

  
            var y = _repo.GetUsers().Find(t => t.Username == customer.Username);


            if (y == null)
            {
                    _repo.AddUserInfo(customer);
                return RedirectToAction(nameof(DetailsRegistration));
                
            }
            
            else 
                {
                return View("ErrorMessage", "The username is taken");

            }

        }


        //I totally did not need that many views, temps were enough
        public IActionResult DetailsCreate(string name)
        {

            //get repo implementation to only get one note
            return View(_repo.GetRestaurants().Last(x => x.Name == name));

        }
        public IActionResult DetailsDelete()
        {


            return View();

        }
        public IActionResult DetailsReview()
        {


            return View();

        }

        public IActionResult DetailsRegistration()
        {
             return View();

        }

        public IActionResult DetailsSearch(string name)
        {

            //get repo implementation to only get one note

            try
            {
                return View(_repo.GetRestaurants().First(x => x.Name.Contains(name)));
            }
            catch (Exception)
            {
                _logger.LogError("Invalid Search was introduced");
                return View("ErrorMessage", model: "There is not Restaurant with the parameters you specified!");

            }

        }

        // Connecting Details with restaurant table
        public IActionResult Details(int id)
        {

            Restaurant res = _repo.GetRestaurants().FirstOrDefault(x => x.Id == id); // shows and select restaurant

            res.Reviewseconds = _repo.GetReviews().FindAll(x => x.RestaurantId == id); // finds all the reviews with the restaurat selected

            return View(res);

        }

        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var delbefore = _repo.GetRestaurants().FirstOrDefault(x => x.Id == id);

            return View(delbefore);

        }
        [HttpPost]
        public IActionResult Delete(Restaurant restaurant)
        {

            try
            {
                _repo.DeleteRestaurant(restaurant);

                _logger.LogInformation("Information has been deleted => RestaurantDatabase");

                return RedirectToAction(nameof(DetailsDelete));
            }
            catch
            {
                return View(nameof(Index));
            }

        }


        [HttpGet]
        public IActionResult SearchRestaurant()
        {
            return View();

        }
        [HttpPost]
        public IActionResult SearchRestaurant(string SearchRes)
        {

            if (SearchRes == null)
            {
                return View("ErrorMessage", model: "Please insert something");
            }

            _repo.SearchRestaurant(SearchRes);

            return RedirectToAction("DetailsSearch", new { name = SearchRes });
        }



        [Authorize(Roles = "Admin")]
        
        public IActionResult CreateRestaurant()
        {
            return View();

        }
        [HttpPost] //form submission
       
        public IActionResult CreateRestaurant(Restaurant restaurant)
        {


            _repo.AddRestaurant(restaurant);
            return RedirectToAction("DetailsCreate", new { name = restaurant.Name });

        }

        [Authorize]
        [HttpGet]
        public IActionResult CreateReview()
        {
            var x = _repo.GetRestaurants();

            ViewBag.ResList = new SelectList(x, "Id", "Name");
            return View();

        }

        [HttpPost] //form submission
        [ValidateAntiForgeryToken]
        public IActionResult CreateReview( ReviewSecond x)
        {
            
            _repo.AddReviewSecond(x);

            //return View("details",customer) // not refreshable
            return RedirectToAction(nameof(DetailsReview));

        }




    }
}
