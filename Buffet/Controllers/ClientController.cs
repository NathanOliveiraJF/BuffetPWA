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
using Buffet.Models.Buffet.Evento;

namespace Buffet.Controllers
{
    public class ClientController : Controller
    {

        private readonly ClientService _clientService;
        private readonly EventoService _eventoService;

        public ClientController(ClientService clientService, EventoService eventoService)
        {
            _clientService = clientService;
            _eventoService = eventoService;
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
            List<EventoEntity> ev = _eventoService.GetAll().Where(x => x.Cliente.Id == id).ToList();
           // EventoEntity eventto = _eventoService.
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

            foreach (var item in ev)
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

        [HttpGet]
        public IActionResult ClientDelete(Guid id)
        {
            ClienteEntity cliente = _clientService.GetById(id);
            if(cliente.Eventos.Count > 0)
            {
                TempData["MensagemErro"] = "Não é possível deletar(cliente possui eventos) deletar eles primeiro.";
                return RedirectToAction("Clientes");
            }

            DeletarClientViewModel viewModel = new DeletarClientViewModel
            {
                Id = cliente.Id.ToString(),
                Email = cliente.Email,
                Cpf = cliente.Cpf,
                Cnpj = cliente.Cnpj,
                Nome = cliente.Nome,
                Endereco = cliente.Endereco,
                DataNascimento = cliente.DataNascimento.ToString("yyyy-MM-dd")
            };

            return View("~/Views/Admin/Client/ClientDelete.cshtml", viewModel);
        }

        [HttpPost]
        public RedirectToActionResult ClientDeleteIt(Guid id)
        {
            //TODO FAZER TRATAMENTOS
            _clientService.Delete(id);

            TempData["MensagemSucesso"] = "Cliente deletado com sucesso!";
            return RedirectToAction("Clientes");
        }
    }
}
