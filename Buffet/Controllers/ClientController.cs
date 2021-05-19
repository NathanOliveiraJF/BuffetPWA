using Buffet.Models.Acesso.Exceptions;
using Buffet.Models.Acesso.Services;
using Buffet.RequestModels;
using Buffet.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buffet.Models.Acesso;
using Buffet.Models.Buffet;
using Buffet.RequestModels.Buffet;
using Buffet.ViewModels.Buffet;

namespace Buffet.Controllers
{
    public class ClientController : Controller
    {

        private readonly ClientService _clientService;

        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }
        
        /**
         * Controller to register user.
         */
        [HttpPost]
        public IActionResult Register(ClienteRegisterRequestModel clientDto)
        {
            _clientService.ClientRegister(clientDto);
            TempData["msg-register"] = "Cadastro efeutado com sucesso!";
            return RedirectToAction("Register");
        }

        [HttpGet]
        public IActionResult Register()
        {
            string msg = (string)TempData["msg-register"];

            return View("~/Views/Admin/Client/Register.cshtml", msg);
        }


        /*
         * Controller to return client list
         */
        [HttpGet]
        public IActionResult ClientList()
        {
            var listaDeClient = _clientService.GetAll();
            ListClientViewModel viewModel = new ListClientViewModel();

            foreach (ClienteEntity clienteEntity in listaDeClient)
            {
                viewModel.Clients.Add(new Cliente 
                { 
                    Id = clienteEntity.Id.ToString(),
                    Nome = clienteEntity.Nome,
                    Email = clienteEntity.Email,
                    DataInserido = clienteEntity.DataInserido.ToShortDateString(),
                    DataModificacao = clienteEntity.DataModificacao.ToShortDateString(),
                    DataNascimento = clienteEntity.DataNascimento.ToShortDateString()
                });
            }

            return View("~/Views/Admin/Client/ClientList.cshtml", viewModel);;
        }
        
        [HttpGet]
        public IActionResult ClientFilter(string descricao)
        {
            var list = _clientService.GetByFilter(descricao);
            ClientViewModel viewModel = new ClientViewModel {Clients = list};
            return View("~/Views/Admin/Client/ClientList.cshtml", viewModel);;
        }

        [HttpGet]
        public IActionResult ClientEdit(Guid id)
        {
            var client = _clientService.GetById(id);
            ClientViewModel viewModel = new ClientViewModel
            {
                Nome = client.Nome,
                Email = client.Email,
                Endereco = client.Endereco,
                Cpf = client.Cpf,
                Cnpj = client.Cnpj,
                DataNascimento = client.DataNascimento,
                TextoObservacao = client.TextoObservacao,
                Events = client.Events
            };

            return View("~/Views/Admin/Client", viewModel);
        }
    }
}
