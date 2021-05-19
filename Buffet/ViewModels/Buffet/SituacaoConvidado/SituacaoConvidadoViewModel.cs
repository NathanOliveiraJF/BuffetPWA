using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buffet.Models.Buffet;
using Buffet.Models.Buffet.Evento;
using Buffet.Models.Buffet.Convidado;

namespace Buffet.ViewModels.Buffet.SituacaoConvidado
{
    public class SituacaoConvidadoViewModel
    {
        public string MensagemSucesso { get; set; }
        public string MensagemErro { get; set; }
        public ICollection<SituacaoConvidadoEntity> SituacaoConvidados { get; set; }
    }
}
