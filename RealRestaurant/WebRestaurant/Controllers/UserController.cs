﻿using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRestaurant.Controllers
{
    public class UserController : Controller
    {
        private readonly IDL _repo;

        public UserController(IDL repo)
        {

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
            //ASP.NET "model binding"
            //-fill in action method parameters with data from the request
            // (ULR  path, URL query string, form data, etc - autimatically
            //based on compatible data type and name
            // _repo = AddUser(customer);

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

            return View("DetailDelete"); ;

        }
    }
}
