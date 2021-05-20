using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buffet.Models.Buffet;

namespace Buffet.ViewModels.Buffet.Evento
{
    public class EditarEventoViewModel
    {

        public string Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<Convidado> Convidados { get; set; } = new List<Convidado>();

    }

    public class Convidado
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string DataNascimento { get; set; }
        public string DataInserido { get; set; }
        public string DataModificacao { get; set; }

    }

   
}
