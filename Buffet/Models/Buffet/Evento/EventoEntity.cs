using Buffet.Models.Buffet.Cliente;
using Buffet.Models.Buffet.Evento;
using Buffet.Models.Buffet.Local;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.Models.Buffet.Evento
{
    public class EventoEntity
    {

        public EventoEntity()
        {
            Id = new Guid();
        }

        public Guid Id { get; private set; }
        public ClienteEntity Cliente { get; set; }
        public SituacaoEventoEntity Situacao { get; set; }
        public TipoEventoEntity Tipo { get; set; }
        public LocalEntity Local { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public DateTime DataInserido { get; set; }
        public DateTime DataModificacao { get; set; }
        public string TextoObservacao { get; set; }
        public string Nome { get; set; }
      
       

    }
}
