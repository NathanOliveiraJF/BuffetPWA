using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buffet.Models.Buffet;

namespace Buffet.ViewModels.Buffet.Evento
{
    public class ListEventoViewModel
    {
        public string MensagemSucesso { get; set; }
        public string MensagemErro { get; set; }

        public List<Evento> Eventos { get; set; } = new List<Evento>();
    }

    public class Evento
    {
        public string Id { get; set; }
        public string Cliente { get; set; }
        public string Situacao { get; set; }
        public string Tipo { get; set; }
        public string Local { get; set; }
        public string Nome { get; set; }
        public string DataInserido { get; set; }
        public string DataModificado { get; set; }
    }

   
}
