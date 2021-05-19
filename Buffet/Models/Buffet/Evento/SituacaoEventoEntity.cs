using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.Models.Buffet.Evento
{
    public class SituacaoEventoEntity
    {
        public SituacaoEventoEntity()
        {
            Id = new Guid();
        }

        public Guid Id { get; private set; }
        public string Descricao { get; set; }
    }
}
