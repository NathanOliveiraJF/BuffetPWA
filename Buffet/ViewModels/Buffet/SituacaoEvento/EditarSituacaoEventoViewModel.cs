using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buffet.Models.Buffet;
using Buffet.Models.Buffet.Evento;

namespace Buffet.ViewModels.Buffet.SituacaoEvento
{
    public class EditarSituacaoEventoViewModel
    {
        public string MensagemSucesso { get; set; }
        public string MensagemErro { get; set; }
        public string Descricao { get; set; }
        public string Id { get; set; }
    }
}
