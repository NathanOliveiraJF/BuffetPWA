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
using Buffet.Models.Buffet.Evento;
using Buffet.ViewModels.Buffet.TipoEvento;

namespace Buffet.Controllers
{
    public class TipoEvento : Controller
    {

        private readonly TipoEventoService _tipoEventoService;

        public TipoEvento(TipoEventoService tipoEventoService)
        {
            _tipoEventoService = tipoEventoService;
        }
        
        [HttpGet]
        public IActionResult TipoEventos()
        {
            var viewModel = new TipoEventoViewModel
            {
                MensagemSucesso = (string)TempData["formMensagemSucesso"],
                MensagemErro = (string)TempData["formMensagemErro"]
            };

            viewModel.TipoEventos = _tipoEventoService.GetAll();
            return View("~/Views/Admin/TipoEvento/TipoEventoList.cshtml", viewModel);

        }

        [HttpPost]
        public RedirectToActionResult Create(string descricao)
        {
            _tipoEventoService.Create(descricao);
            TempData["formMensagemSucesso"] = "Tipo Evento criado com sucesso!";
            return RedirectToAction("TipoEventos");
        }


        [HttpGet]
        public IActionResult Edit(Guid id)
        {

            var tipoEvento = _tipoEventoService.GetById(id);
            var viewModel = new EditarTipoEventoViewModel
            {
                Id = tipoEvento.Id.ToString(),
                Descricao = tipoEvento.Descricao,
                MensagemSucesso = (string)TempData["formMensagemSucesso"]
            };
            return View("~/Views/Admin/TipoEvento/Edit.cshtml", viewModel);
        }

        [HttpPost]
        public RedirectToActionResult Edit(Guid id, string descricao)
        {
            //TODO: TRATAR ERROS
            _tipoEventoService.Edit(id, descricao);
            TempData["formMensagemSucesso"] = "Tipo evento editado com sucesso!";
            return RedirectToAction("TipoEventos");
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            //TODO: TRATAR ERROS

            var tipoEvento = _tipoEventoService.GetById(id);
            var viewModel = new DeleteTipoEventoViewModel
            {
                Id = tipoEvento.Id.ToString(),
                Descricao = tipoEvento.Descricao,
            };

            return View("~/Views/Admin/TipoEvento/Delete.cshtml", viewModel);

        }

        [HttpPost]
        public RedirectToActionResult DeleteIt(Guid id)
        {
            //TODO: TRATAR ERROS
            _tipoEventoService.Remove(id);
            TempData["formMensagemSucesso"] = "Tipo evento deletado com sucesso!";
            return RedirectToAction("TipoEventos");
        }

    }
}
