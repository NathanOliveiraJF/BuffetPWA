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
using Buffet.Models.Buffet.Cliente;
using Buffet.ViewModels.Buffet.Cliente;
using Buffet.RequestModels.Buffet.Cliente;

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
        public RedirectToActionResult Create(ClienteRegisterRequestModel clientDto)
        {
            _clientService.ClientRegister(clientDto);
            TempData["MensagemSucesso"] = "Cadastro efetuado com sucesso!";
            return RedirectToAction("Clientes");
        }

        [HttpGet]
        public IActionResult Create()
        {

            CriarClientViewModel viewModel = new CriarClientViewModel
            {
                MensagemErro = (string)TempData["MensagemErro"]
            };
            
            return View("~/Views/Admin/Client/Register.cshtml", viewModel);
        }


        /*
         * Controller to return client list
         */
        [HttpGet]
        public IActionResult Clientes()
        {
            var listaDeClient = _clientService.GetAll();
            ListClientViewModel viewModel = new ListClientViewModel
            {
                MensagemSucesso = (string)TempData["MensagemSucesso"]
            };
            
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
            ClienteEntity client = _clientService.GetById(id);
            EditarClientViewModel viewModel = new EditarClientViewModel
            {
                Id = client.Id.ToString(),
                Nome = client.Nome,
                Email = client.Email,
                Endereco = client.Endereco,
                Cpf = client.Cpf,
                Cnpj = client.Cnpj,
                DataNascimento = client.DataNascimento.ToString("yyyy-MM-dd"),
                TextoObservacao = client.TextoObservacao,
            };

            foreach (var item in client.Events)
            {
                viewModel.Eventos.Add(new Evento
                {
                    Id = item.Id.ToString(),
                    Descricao = item.Descricao,
                    Local = item.Local.Endereco,
                    Situacao = item.Situacao.Descricao,
                    TipoEvento = item.Tipo.Descricao
                });
            }
            return View("~/Views/Admin/Client/ClientEdit.cshtml", viewModel);
        }

        [HttpPost]
        public RedirectToActionResult ClientEdit(Guid id, EditClientRequestModel request)
        {
            //TODO FAZER TRY COM ERROS QUE VIER DO REQUET
            _clientService.Edit(id, request);
            TempData["MensagemSucesso"] = "Cliente editado com sucesso";
            return RedirectToAction("Clientes");
        }
    }
}
