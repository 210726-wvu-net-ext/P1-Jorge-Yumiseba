using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebRestaurant.Models;
using Domain;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace WebRestaurant.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDL _repo;

        public HomeController(ILogger<HomeController> logger, IDL repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {

 
            return View();
        }
        
        //Suggestion in the index page
        public IActionResult SuggestionCreate(Domain.Suggestion x)
        {
            _repo.AddSuggestion(x);

            return RedirectToAction("Index");
        }


        // Redirect to when you can't sign in
        [HttpGet("denied")]
        public IActionResult Denied()
        {

            return View();

        }

        //Does nothing but I did not want to delete it D:

      [Authorize]
        public IActionResult Security()
        {
            return View();
        }


        //Login (claims)
        [HttpGet("login")]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Validate(string username, string password, string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;

            var user = _repo.GetUsers().Find(c => c.Username == username && c.Password == password);

            if (!(user is null))
            {
                var claims = new List<Claim>();
                claims.Add(new Claim("username", username));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, username));
                claims.Add(new Claim(ClaimTypes.Name, username));
                


                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync(claimsPrincipal);

                return Redirect(returnUrl);

            }
            TempData["Error"] = "Error. something went wrong";
            return View("login");
        }

        //Works =D
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");

        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


     
       
    }
}
