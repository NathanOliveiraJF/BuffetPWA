using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buffet.Models.Buffet;
using Buffet.Models.Buffet.Cliente;
using Buffet.Models.Buffet.Evento;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Buffet.ViewModels.Buffet.Evento
{
    public class CriarEventoViewModel
    {
        public string MensagemSucesso { get; set; }
        public string MensagemErro { get; set; }

        public ICollection<SelectListItem> Clientes { get; set; }
        public ICollection<SelectListItem> Situacoes { get; set; }
        public ICollection<SelectListItem> TipoEventos { get; set; }
        public ICollection<SelectListItem> LocalEventos { get; set; }

        public CriarEventoViewModel()
        {
            Clientes = new List<SelectListItem>
            {
                new SelectListItem("Selecione", "0")
            };
            Situacoes = new List<SelectListItem>
            {
                new SelectListItem("Selecione", "0")
            };
            TipoEventos = new List<SelectListItem>
            {
                new SelectListItem("Selecione", "0")
            };
            LocalEventos = new List<SelectListItem>
            {
                new SelectListItem("Selecione", "0")
            };
        }
    }
}
