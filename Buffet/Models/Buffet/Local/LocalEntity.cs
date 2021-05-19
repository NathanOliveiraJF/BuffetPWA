using Buffet.Models.Buffet.Evento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.Models.Buffet.Local
{
    public class LocalEntity
    {
        public LocalEntity()
        {
            Id = new Guid();
        }

        public Guid Id { get; private set; }
        public string Descricao { get; set; }
        public string Endereco { get; set; }
        public ICollection<EventoEntity> Events { get; set; } = new List<EventoEntity>();
    }
}
