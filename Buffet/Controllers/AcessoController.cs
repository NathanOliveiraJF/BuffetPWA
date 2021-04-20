using Buffet.Models.Acesso.Exceptions;
using Buffet.Models.Acesso.Services;
using Buffet.RequestModels;
using Buffet.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.Controllers
{
    public class AcessoController : Controller
    {

        private readonly AcessoService _acessoService;

        public AcessoController(AcessoService acessoService)
        {
            _acessoService = acessoService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {

            var viewModel = new CadastrarViewModel();
            viewModel.Mensagem = (string)TempData["msg-cadastro"];
            viewModel.ErrorsRegister = (string[])TempData["errors-cadastro"];
            return View(viewModel);
        }

        [HttpPost]
        public async Task<RedirectToActionResult> Register(AcessoCadastrarRequestModel request)
        {
            if (request.Email == null || request.Senha == null)
            {
                TempData["msg-cadastro"] = "Por favor informe o email e senha";

                return RedirectToAction("Register");
            }

            try
            {
                await _acessoService.UserRegister(request.Email, request.Senha);
                TempData["msg-cadastro"] = "Cadastro realizado com sucesso faça o login";
                return RedirectToAction("Login");
            } catch(CadastrarUsuarioException ex)
            {
                var listErros = new List<string>();
                foreach (var identityError in ex.Errors)
                {
                    listErros.Add(identityError.Description);
                }

                TempData["errors-cadastro"] = listErros;
                return RedirectToAction("Register");

            }
        }
    }
}
