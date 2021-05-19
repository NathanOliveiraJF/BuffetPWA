using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buffet.Models.Buffet;
using Buffet.Models.Buffet.Cliente;
using Buffet.Models.Buffet.Evento;

namespace Buffet.ViewModels.Buffet.Local
{
    public class DeletarLocalViewModel
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public string Endereco { get; set; }
    }
}
