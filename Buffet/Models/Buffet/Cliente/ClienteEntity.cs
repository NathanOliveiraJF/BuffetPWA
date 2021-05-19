using Buffet.Models.Buffet.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.Models.Buffet
{
    public class ClienteEntity
    {
        public Guid Id { get; private set; }
        public TipoClienteEntity Tipo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cnpj { get; set; }
        public string TextoObservacao { get; set; }
        public DateTime DataInserido { get; set; }
        public DateTime DataModificacao { get; set; }
        public List<EventoEntity> Events { get; set; } = new List<EventoEntity>();
    
        public ClienteEntity()
        {
            Id = new Guid();
    
        }
    }
}
