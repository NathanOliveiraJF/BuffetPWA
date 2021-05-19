using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buffet.Models.Buffet;
using Buffet.Models.Buffet.Cliente;
using Buffet.Models.Buffet.Evento;

namespace Buffet.ViewModels.Buffet.Local
{
    public class EditarLocalViewModel
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public string Endereco { get; set; }

        public ICollection<Evento> Eventos { get; set; } = new List<Evento>();
    }

    public class Evento
    {
        public string Id { get; set; }
        public string TipoEvento { get; set; }
        public string Descricao { get; set; }
        public string Situacao { get; set; }
    }
}
