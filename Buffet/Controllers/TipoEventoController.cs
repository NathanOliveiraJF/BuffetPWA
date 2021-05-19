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
        public IActionResult Create(string descricao)
        {
            _tipoEventoService.Create(descricao);
            TempData["formMensagemSucesso"] = "Tipo Evento criado com sucesso!";
            return RedirectToAction("TipoEventos");
        }


    }
}
