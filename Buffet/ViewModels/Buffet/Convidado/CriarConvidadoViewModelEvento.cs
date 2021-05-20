using Buffet.Models.Buffet.Convidado;
using Buffet.Models.Buffet.Evento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.ViewModels.Buffet.Convidado
{
    public class CriarConvidadoViewModelEvento
    {
        public EventoEntity Evento { get; set; }
        public List<SituacaoConvidadoEntity> Situacao { get; set; }
        public string MensagemSucesso { get; set; }
        public string MensagemErro { get; set; }
    }
}
