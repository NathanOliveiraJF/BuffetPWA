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
using Buffet.ViewModels.Buffet.SituacaoConvidado;

using Buffet.Models.Buffet.Convidado;


namespace Buffet.Controllers
{
    public class SituacaoConvidado : Controller
    {


        private readonly SituacaoConvidadoService _situacaoConvidadoService;

        public SituacaoConvidado(SituacaoConvidadoService situacaoConvidadoService)
        {
            _situacaoConvidadoService = situacaoConvidadoService;
        }
        
        [HttpGet]
        public IActionResult SituacaoConvidados()
        {
            var viewModel = new SituacaoConvidadoViewModel
            {
                MensagemSucesso = (string)TempData["formMensagemSucesso"],
                MensagemErro = (string)TempData["formMensagemErro"]
            };

            viewModel.SituacaoConvidados = _situacaoConvidadoService.GetAll();
            return View("~/Views/Admin/SituacaoConvidado/SituacaoConvidadoList.cshtml", viewModel);

        }

        [HttpPost]
        public RedirectToActionResult Create(string descricao)
        {
            _situacaoConvidadoService.Create(descricao);
            TempData["formMensagemSucesso"] = "Situacao do convidado criado com sucesso!";
            return RedirectToAction("SituacaoConvidados");
        }


        [HttpGet]
        public IActionResult Edit(Guid id)
        {

            var SituacaoConvidado = _situacaoConvidadoService.GetById(id);
            var viewModel = new EditarSituacaoConvidadoViewModel
            {
                Id = SituacaoConvidado.Id.ToString(),
                Descricao = SituacaoConvidado.Descricao,
                MensagemSucesso = (string)TempData["formMensagemSucesso"]
            };
            return View("~/Views/Admin/SituacaoConvidado/Edit.cshtml", viewModel);
        }

        [HttpPost]
        public RedirectToActionResult Edit(Guid id, string descricao)
        {
            //TODO: TRATAR ERROS
            _situacaoConvidadoService.Edit(id, descricao);
            TempData["formMensagemSucesso"] = "Situacao do convidado editado com sucesso!";
            return RedirectToAction("SituacaoConvidados");
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            //TODO: TRATAR ERROS

            var SituacaoConvidado = _situacaoConvidadoService.GetById(id);
            var viewModel = new DeleteSituacaoConvidadoViewModel
            {
                Id = SituacaoConvidado.Id.ToString(),
                Descricao = SituacaoConvidado.Descricao,
            };

            return View("~/Views/Admin/SituacaoConvidado/Delete.cshtml", viewModel);

        }

        [HttpPost]
        public RedirectToActionResult DeleteIt(Guid id)
        {
            //TODO: TRATAR ERROS
            _situacaoConvidadoService.Remove(id);
            TempData["formMensagemSucesso"] = "Situacao do convidado deletado com sucesso!";
            return RedirectToAction("SituacaoConvidados");
        }

    }
}
