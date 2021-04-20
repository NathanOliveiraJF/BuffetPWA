using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.Models.Buffet
{
    public class EventoEntity
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public ClienteEntity Cliente { get; set; }
        public EventoEntity()
        {
            Id = new Guid();
        }

    }
}
