using Buffet.Data;
using Buffet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Buffet.Models.Acesso;
using Buffet.Models.Acesso.Services;
using Buffet.ViewModels;

namespace Buffet.Controllers
{
    public class AdminController : Controller
    {
        private readonly DataBaseContext _dbContext;
        private readonly AcessoService _acessoService;

        public AdminController(DataBaseContext dbContext, AcessoService acessoService)
        {
            _dbContext = dbContext;
            _acessoService = acessoService;
        }

        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult Help()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PanelUser()
        { 
            string email = "";
            if (HttpContext.User.Identity != null)
            {
                 email = HttpContext.User.Identity.Name;
            }

            Usuario u = _dbContext.Users.Where(x => x.Email == email).FirstOrDefault();
            var viewModel = new LoginViewModel { Email = u.Email } ;
            
            return View(viewModel);
        }
        
      
        
   
        public IActionResult Session()
        {
            return View();
        }

    
    }
}
