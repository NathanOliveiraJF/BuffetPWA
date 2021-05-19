using Buffet.Models.Acesso.Exceptions;
using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Buffet.Data;
using Microsoft.AspNetCore.Authentication;

namespace Buffet.Models.Acesso.Services
{
    public class AcessoService
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly DataBaseContext _dbContext;

        public AcessoService(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, DataBaseContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
        }


        public async Task UserAuthentication(string username, string senha)
        {
            var result = await _signInManager.PasswordSignInAsync(username, senha, false, false);
           
            if (!result.Succeeded)
                throw new Exception("Usuário ou senha inválidos");
        }

        public async Task UserRegister(string email, string senha)
        {
            var newUser = new Usuario()
            {
                UserName = email,
                Email = email,
            };

            var result = await _userManager.CreateAsync(newUser, senha);
        
            if(!result.Succeeded)
            {
                throw new CadastrarUsuarioException(result.Errors);
            }
        }

        public String User()
        {
            return _userManager.GetUserId(ClaimsPrincipal.Current);
        }

        

        

       
    }
}
