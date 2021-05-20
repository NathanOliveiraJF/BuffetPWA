using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.ViewModels.Buffet.Evento
{
    public class DeleteEventoViewModel
    {

        public DeleteEventoViewModel()
        {
            Id = "";
            Descricao = "";
            Nome = "";
        }

        public string Id { get; set; }
        public string Descricao { get; set; }
        public string Nome { get; set; }
    }
}
