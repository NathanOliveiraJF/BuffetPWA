using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buffet.Models.Buffet;

namespace Buffet.ViewModels.Buffet
{
    public class ClientViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cnpj { get; set; }
        public string TextoObservacao { get; set; }

        public IEnumerable<ClienteEntity> Clients { get; set; } = new List<ClienteEntity>();
        public IEnumerable<EventoEntity> Events { get; set; } = new List<EventoEntity>();

    }
}
