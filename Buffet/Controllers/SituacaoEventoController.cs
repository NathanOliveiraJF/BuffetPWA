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
using Buffet.ViewModels.Buffet.SituacaoEvento;
using Buffet.ViewModels.Buffet.SituacaoEvento;

namespace Buffet.Controllers
{
    public class SituacaoEvento : Controller
    {

        private readonly SituacaoEventoService _situacaoEventoService;

        public SituacaoEvento(SituacaoEventoService situacaoEventoService)
        {
            _situacaoEventoService = situacaoEventoService;
        }
        
        [HttpGet]
        public IActionResult SituacaoEventos()
        {
            var viewModel = new SituacaoEventoViewModel
            {
                MensagemSucesso = (string)TempData["formMensagemSucesso"],
                MensagemErro = (string)TempData["formMensagemErro"]
            };

            viewModel.SituacaoEventos = _situacaoEventoService.GetAll();
            return View("~/Views/Admin/SituacaoEvento/SituacaoEventoList.cshtml", viewModel);

        }

        [HttpPost]
        public RedirectToActionResult Create(string descricao)
        {
            _situacaoEventoService.Create(descricao);
            TempData["formMensagemSucesso"] = "Situacao do  Evento criado com sucesso!";
            return RedirectToAction("SituacaoEventos");
        }


        [HttpGet]
        public IActionResult Edit(Guid id)
        {

            var SituacaoEvento = _situacaoEventoService.GetById(id);
            var viewModel = new EditarSituacaoEventoViewModel
            {
                Id = SituacaoEvento.Id.ToString(),
                Descricao = SituacaoEvento.Descricao,
                MensagemSucesso = (string)TempData["formMensagemSucesso"]
            };
            return View("~/Views/Admin/SituacaoEvento/Edit.cshtml", viewModel);
        }

        [HttpPost]
        public RedirectToActionResult Edit(Guid id, string descricao)
        {
            //TODO: TRATAR ERROS
            _situacaoEventoService.Edit(id, descricao);
            TempData["formMensagemSucesso"] = "Situacao do  evento editado com sucesso!";
            return RedirectToAction("SituacaoEventos");
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            //TODO: TRATAR ERROS

            var SituacaoEvento = _situacaoEventoService.GetById(id);
            var viewModel = new DeleteSituacaoEventoViewModel
            {
                Id = SituacaoEvento.Id.ToString(),
                Descricao = SituacaoEvento.Descricao,
            };

            return View("~/Views/Admin/SituacaoEvento/Delete.cshtml", viewModel);

        }

        [HttpPost]
        public RedirectToActionResult DeleteIt(Guid id)
        {
            //TODO: TRATAR ERROS
            _situacaoEventoService.Remove(id);
            TempData["formMensagemSucesso"] = "Situacao do evento deletado com sucesso!";
            return RedirectToAction("SituacaoEventos");
        }

    }
}
