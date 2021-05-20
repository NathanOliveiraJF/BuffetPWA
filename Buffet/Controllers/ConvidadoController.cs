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
//using Buffet.Models.Buffet.LocalEntity;
//using Buffet.ViewModels.Buffet.LocalEntity;
//using Buffet.RequestModels.Buffet.LocalEntity;
using Buffet.Models.Buffet.Local;
//using Buffet.RequestModels.Buffet.Local;
//using Buffet.ViewModels.Buffet.Local;
using Buffet.ViewModels.Buffet.Evento;
using Buffet.Models.Buffet.Cliente;
using Microsoft.AspNetCore.Mvc.Rendering;
using Buffet.Models.Buffet.Evento;
using Buffet.RequestModels.Buffet.Evento;
using Buffet.Models.Buffet.Convidado;

namespace Buffet.Controllers
{
    public class ConvidadoController : Controller
    {

        private readonly LocalService _localService;
        private readonly ClientService _clientService;
        private readonly SituacaoEventoService _situacaoService;
        private readonly TipoEventoService _tipoEventoService;
        private readonly EventoService _eventoService;
        private readonly ConvidadoService _convidadoService;




        public ConvidadoController(LocalService localService, ClientService clientService, 
            SituacaoEventoService situacaoService, TipoEventoService tipoEventoService,
            EventoService eventoService, ConvidadoService convidadoService)
        {
            _localService = localService;
            _clientService = clientService;
            _situacaoService = situacaoService;
            _tipoEventoService = tipoEventoService;
            _eventoService = eventoService;
            _convidadoService = convidadoService;
        }

        /**
         * Controller to register Eventos.
         */
        [HttpPost]
        public RedirectToActionResult Create(EventoRegisterRequestModel evento)
        {
            _eventoService.Create(evento);
            TempData["MensagemSucesso"] = "Cadastro efetuado com sucesso!";
            return RedirectToAction("Eventos");
        }

        [HttpGet]
        public IActionResult Create()
        {
            CriarEventoViewModel viewModel = new CriarEventoViewModel
            {
                MensagemErro = (string)TempData["MensagemErro"]
            };

            var clientes = _clientService.GetAll();
            var situacoes = _situacaoService.GetAll();
            var tipoEventos = _tipoEventoService.GetAll();
            var locais = _localService.GetAll();

            //comobox de cliente
            foreach (var clienteEntity in clientes)
            {
                viewModel.Clientes.Add(new SelectListItem()
                {
                    Value = clienteEntity.Id.ToString(),
                    Text = clienteEntity.Nome
                });
            }

            //combobox de situacao dos eventos
            foreach (var situacaoEntity in situacoes)
            {
                viewModel.Situacoes.Add(new SelectListItem()
                {
                    Value = situacaoEntity.Id.ToString(),
                    Text = situacaoEntity.Descricao
                });
            }

            //combobox de tipo de eventos
            foreach (var tipoEventoEntity in tipoEventos)
            {
                viewModel.TipoEventos.Add(new SelectListItem()
                {
                    Value = tipoEventoEntity.Id.ToString(),
                    Text = tipoEventoEntity.Descricao
                });
            }

            //combobox de locais
            foreach (var localEntity in locais)
            {
                viewModel.LocalEventos.Add(new SelectListItem()
                {
                    Value = localEntity.Id.ToString(),
                    Text = localEntity.Descricao
                });
            }


            return View("~/Views/Admin/Evento/Register.cshtml", viewModel);
        }


        /*
         * Controller to return Eventos list
         */
        [HttpGet]
        public IActionResult Eventos()
        {
            var listaDeEventos = _eventoService.GetAll();
            ListEventoViewModel viewModel = new ListEventoViewModel
            {
                MensagemSucesso = (string)TempData["MensagemSucesso"]
            };
            
            foreach (EventoEntity evento in listaDeEventos)
            {
                
                viewModel.Eventos.Add(new Evento
                {
                    Id = evento.Id.ToString(),
                    Cliente = evento.Cliente.Nome,
                    Nome = evento.Nome,
                    DataInserido = evento.DataInserido.ToShortDateString(),
                    DataModificado = evento.DataModificacao.ToShortDateString(),
                    Local = evento.Local.Descricao,
                    Tipo = evento.Tipo.Descricao,
                    Situacao = evento.Situacao.Descricao
                });

            }

            return View("~/Views/Admin/Evento/EventoList.cshtml", viewModel);;
        }

        //[HttpGet]
        //public IActionResult LocalFilter(string descricao)
        //{
        //    var list = _localService.GetByFilter(descricao);
        //    LocalViewModel viewModel = new LocalViewModel {Locals = list};
        //    return View("~/Views/Admin/LocalEntity/LocalList.cshtml", viewModel);;
        //}

        [HttpGet]
        public IActionResult EventoEdit(Guid id)
        {
            //LocalEntity local = _localService.GetById(id);
            var evento = _eventoService.GetById(id);
            var convidados = _convidadoService.GetAll().
                Where(x => x.Evento.Id == id).ToList();

            EditarEventoViewModel viewModel = new EditarEventoViewModel
            {
                Id = evento.Id.ToString(),
                Descricao = evento.Descricao,
                Nome = evento.Nome
            };

            foreach (var item in convidados)
            {
                viewModel.Convidados.Add(new Convidado
                {
                    Id = item.Id.ToString(),
                    Nome = item.Nome,
                    Cpf = item.Cpf,
                    DataInserido = item.DataInserido.ToShortDateString(),
                    DataModificacao = item.DataModificacao.ToShortDateString(),
                    DataNascimento = item.DataNascimento.ToShortDateString(),
                    Email = item.Email
                });
            }

            return View("~/Views/Admin/Evento/EventoEdit.cshtml", viewModel);
        }

        [HttpPost]
        public RedirectToActionResult EventoEdit(Guid id, EditEventoRegisterRequestModel request)
        {
            //TODO FAZER TRY COM ERROS QUE VIER DO REQUET
            _eventoService.Edit(id, request);
            TempData["MensagemSucesso"] = "Evento editado com sucesso";
            return RedirectToAction("Eventos");
        }

        [HttpGet]
        public IActionResult EventoDelete(Guid id)
        {
            var evento = _eventoService.GetById(id);

            DeleteEventoViewModel viewModel = new DeleteEventoViewModel
            {
                Id = evento.Id.ToString(),
                Descricao = evento.Descricao,
                Nome = evento.Nome
            };

            return View("~/Views/Admin/Evento/EventoDelete.cshtml", viewModel);
        }

        [HttpPost]
        public RedirectToActionResult EventoDeleteIt(Guid id)
        {
            //TODO FAZER TRATAMENTOS
            _eventoService.Delete(id);

            TempData["MensagemSucesso"] = "Local deletado com sucesso!";
            return RedirectToAction("Eventos");
        }
    }
}
