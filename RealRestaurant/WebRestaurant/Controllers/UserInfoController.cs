using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRestaurant.Controllers
{
    public class UserInfoController : Controller
    {
        private readonly ILogger<UserInfoController> _logger;
        private readonly IDL _repo;

        public UserInfoController(ILogger<UserInfoController> logger, IDL repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {

            return View(_repo.GetUsers());
        }
        public IActionResult Detailss(string name)   
        {

            //get repo implementation to only get one note
            return View(_repo.GetUsers().Last(x => x.Name == name));

        }
        public IActionResult DetailDelete()
        {

            return View();

        }
        public IActionResult DetailsEachUser(int id)
        {

            var x = _repo.GetUsers().FirstOrDefault(x => x.Id == id);

            return View(x);

        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();

        }
        [HttpPost] //form submission
        public IActionResult CreateUser(UserInformation customer)
        {
          

            _repo.AddUserInfo(customer);

          
            return RedirectToAction("Detailss", new { name = customer.Name });

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var e = _repo.GetUsers().FirstOrDefault(x => x.Id == id);

            return View(e);

        }
        [HttpPost]
        public IActionResult Delete(UserInformation user)
        {

            _repo.DeleteUserInfo(user);
            _logger.LogInformation("Information has been deleted => CustomerDatabase");
            return RedirectToAction(nameof(DetailDelete));

        }
    }
}

