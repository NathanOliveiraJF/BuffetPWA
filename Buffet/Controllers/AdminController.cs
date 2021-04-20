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
    public class AdminController : Controller
    {
        private readonly DataBaseContext _dbContext;

        public AdminController(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Help()
        {
            return View();
        }

        public IActionResult PanelUser()
        {
            return View();
        }

        public IActionResult Session()
        {
            return View();
        }
    }
}
