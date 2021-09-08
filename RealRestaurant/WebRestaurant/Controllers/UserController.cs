using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRestaurant.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IDL _repo;

        public UserController(ILogger<UserController> logger, IDL repo)
        {
            _logger = logger;
            _repo = repo;
        }
        public IActionResult Index()
        {

            return View( _repo.ListUser());
        }
        public IActionResult Detailss(string name)   /*DetailsCreate*/
        {

            //get repo implementation to only get one note
            return View(_repo.ListUser().Last(x => x.Name == name));
            
        }
        public IActionResult DetailDelete()
        {


            return View();

        }
        public IActionResult DetailsEachUser(int id)
        {

            var x = _repo.ListUser().FirstOrDefault(x => x.Id == id);

            return View(x);

        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();

        }
        [HttpPost] //form submission
        public IActionResult CreateUser(Customer customer)
        {
      

            _repo.AddUser(customer);

            //return View("details",customer) // not refreshable
            return RedirectToAction("Detailss", new { name = customer.Name });

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var e = _repo.ListUser().FirstOrDefault(x => x.Id == id);

            return View(e);

        }
        [HttpPost]
        public IActionResult Delete(Customer user)
        {

            _repo.DeleteUser(user);
            _logger.LogInformation("Information has been deleted => CustomerDatabase");
            return RedirectToAction(nameof(DetailDelete)); 

        }
    }
}
