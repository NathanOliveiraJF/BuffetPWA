using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buffet.Models.Buffet;

namespace Buffet.ViewModels.Buffet
{
    public class ListClientViewModel
    {
        public string MensagemSucesso { get; set; }
        public string MensagemErro { get; set; }

        public List<Cliente> Clients { get; set; } = new List<Cliente>();
        public List<Evento> Events { get; set; } = new List<Evento>();
    }

    public class Cliente
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string DataNascimento { get; set; }
        public string DataInserido { get; set; }
        public string DataModificacao { get; set; }
    }

    public class Evento
    {
        public string Id { get; set; }
        public string TipoEvento { get; set; }
        public string Descricao { get; set; }
        public string Cliente { get; set; }
        public string Situacao { get; set; }
        public string Local { get; set; }
    }
}
