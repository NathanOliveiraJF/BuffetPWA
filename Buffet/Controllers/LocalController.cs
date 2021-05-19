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
using Buffet.RequestModels.Buffet.Local;
using Buffet.ViewModels.Buffet.Local;

namespace Buffet.Controllers
{
    public class LocalController : Controller
    {

        private readonly LocalService _localService;

        public LocalController(LocalService localService)
        {
            _localService = localService;
        }
        
        /**
         * Controller to register local.
         */
        [HttpPost]
        public RedirectToActionResult Create(LocalRegisterRequestModel local)
        {
            _localService.Create(local);
            TempData["MensagemSucesso"] = "Cadastro efetuado com sucesso!";
            return RedirectToAction("Locais");
        }

        [HttpGet]
        public IActionResult Create()
        {
            CriarLocalViewModel viewModel = new CriarLocalViewModel
            {
                MensagemErro = (string)TempData["MensagemErro"]
            };
            
            return View("~/Views/Admin/Local/Register.cshtml", viewModel);
        }


        /*
         * Controller to return LocalEntity list
         */
        [HttpGet]
        public IActionResult Locais()
        {
            var listaDeLocais = _localService.GetAll();
            ListLocalViewModel viewModel = new ListLocalViewModel
            {
                MensagemSucesso = (string)TempData["MensagemSucesso"]
            };
            
            foreach (LocalEntity local in listaDeLocais)
            {
                viewModel.Locais.Add(new Local 
                { 
                    Id = local.Id.ToString(),
                    Descricao = local.Descricao,
                    Endereco = local.Endereco
                });
            }

            return View("~/Views/Admin/Local/LocalList.cshtml", viewModel);;
        }
        
        //[HttpGet]
        //public IActionResult LocalFilter(string descricao)
        //{
        //    var list = _localService.GetByFilter(descricao);
        //    LocalViewModel viewModel = new LocalViewModel {Locals = list};
        //    return View("~/Views/Admin/LocalEntity/LocalList.cshtml", viewModel);;
        //}

        [HttpGet]
        public IActionResult LocalEdit(Guid id)
        {
            LocalEntity local = _localService.GetById(id);
            EditarLocalViewModel viewModel = new EditarLocalViewModel
            {
                Id = local.Id.ToString(),
                Endereco = local.Endereco,
                Descricao = local.Descricao
            };

            foreach (var item in local.Events)
            {
                viewModel.Eventos.Add(new Evento
                {
                    Id = item.Id.ToString(),
                    Descricao = item.Descricao,
                    Situacao = item.Situacao.Descricao,
                    TipoEvento = item.Tipo.Descricao
                });
            }
            return View("~/Views/Admin/Local/LocalEdit.cshtml", viewModel);
        }

        [HttpPost]
        public RedirectToActionResult LocalEdit(Guid id, EditLocalRequestModel request)
        {
            //TODO FAZER TRY COM ERROS QUE VIER DO REQUET
            _localService.Edit(id, request);
            TempData["MensagemSucesso"] = "LocalEntity editado com sucesso";
            return RedirectToAction("Locais");
        }

        [HttpGet]
        public IActionResult LocalDelete(Guid id)
        {
            LocalEntity local = _localService.GetById(id);
            if(local.Events.Count > 0)
            {
                TempData["MensagemErro"] = "Não é possível deletar(LocalEntity possui eventos) deletar eles primeiro.";
                return RedirectToAction("Locais");
            }

            DeletarLocalViewModel viewModel = new DeletarLocalViewModel
            {
                Id = local.Id.ToString(),
                Descricao = local.Descricao,
                Endereco = local.Endereco
            };

            return View("~/Views/Admin/Local/LocalDelete.cshtml", viewModel);
        }

        [HttpPost]
        public RedirectToActionResult LocalDeleteIt(Guid id)
        {
            //TODO FAZER TRATAMENTOS
            _localService.Delete(id);

            TempData["MensagemSucesso"] = "Local deletado com sucesso!";
            return RedirectToAction("Locais");
        }
    }
}
