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
            var viewModel = new LoginViewModel();
            viewModel.ErrorLogin = (string)TempData["error-login"];
            viewModel.Mensagem = (string)TempData["msg-login"];

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(AcessoLoginRequestModel request)
        {
            if(request.Email == null || request.Senha == null)
            {
                TempData["msg-login"] = "Por favor informe o email e senha";
                return Redirect("/Acesso/Login");
            }

            try
            {
                await _acessoService.UserAuthentication(request.Email, request.Senha);
                return Redirect("/Admin/Index");


            }
            catch (Exception ex)
            {
                TempData["error-login"] = ex.Message;
                return Redirect("/Acesso/Login");
            }
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
                return RedirectToAction("Register");
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
