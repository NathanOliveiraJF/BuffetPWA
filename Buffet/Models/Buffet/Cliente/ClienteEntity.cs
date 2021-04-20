using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.Models.Buffet
{
    public class ClienteEntity
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public ICollection<EventoEntity> Eventos { get; set; }
        public ClienteEntity()
        {
            Id = new Guid();
            Eventos = new List<EventoEntity>();
        }
    }
}
