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
using Microsoft.AspNetCore.Http;

namespace WebRestaurant.Controllers
{
    public class SuggestionController : Controller
    {

        private readonly ILogger<SuggestionController> _logger;
        private readonly IDL _repo;

        public SuggestionController(ILogger<SuggestionController> logger, IDL repo)
        {
            _logger = logger;
            _repo = repo;
        }

  
     
    }
}
