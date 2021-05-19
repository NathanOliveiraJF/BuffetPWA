using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buffet.Models.Buffet;

namespace Buffet.ViewModels.Buffet.Local
{
    public class ListLocalViewModel
    {
        public string MensagemSucesso { get; set; }
        public string MensagemErro { get; set; }

        public List<Local> Locais { get; set; } = new List<Local>();
    }

    public class Local
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public string Endereco { get; set; }
    }
   
}
