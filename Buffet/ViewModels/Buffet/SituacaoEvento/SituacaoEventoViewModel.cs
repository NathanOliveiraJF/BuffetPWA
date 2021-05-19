using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buffet.Models.Buffet;
using Buffet.Models.Buffet.Evento;
using Buffet.Models.Buffet.Situacao;

namespace Buffet.ViewModels.Buffet.SituacaoEvento
{
    public class SituacaoEventoViewModel
    {
        public string MensagemSucesso { get; set; }
        public string MensagemErro { get; set; }
        public ICollection<SituacaoEventoEntity> SituacaoEventos { get; set; }
    }
}
