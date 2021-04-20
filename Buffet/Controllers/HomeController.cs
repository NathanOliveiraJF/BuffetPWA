using Buffet.Data;
using Buffet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataBaseContext _dbContext;

        public HomeController(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Terms()
        {
            return View();
        }

        //public IActionResult Register()
        //{
        //    return View();
        //}

        public IActionResult Recovery()
        {
            return View();
        }

    }
}
