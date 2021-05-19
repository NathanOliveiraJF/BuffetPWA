using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buffet.Models.Buffet;
using Buffet.Models.Buffet.Evento;

namespace Buffet.ViewModels.Buffet.TipoEvento
{
    public class TipoEventoViewModel
    {
        public string MensagemSucesso { get; set; }
        public string MensagemErro { get; set; }
        public ICollection<TipoEventoEntity> TipoEventos { get; set; }
    }
}
