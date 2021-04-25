using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.Models.Buffet.Situacao
{
    public class SituacaoEventoEntity
    {
        public SituacaoEventoEntity(Guid id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public Guid Id { get; private set; }
        public string Descricao { get; set; }
    }
}
