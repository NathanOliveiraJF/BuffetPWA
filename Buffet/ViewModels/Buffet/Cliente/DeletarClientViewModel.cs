using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buffet.Models.Buffet;
using Buffet.Models.Buffet.Cliente;
using Buffet.Models.Buffet.Evento;

namespace Buffet.ViewModels.Buffet.Cliente
{
    public class DeletarClientViewModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Cpf { get; set; }
        public string DataNascimento { get; set; }
        public string Cnpj { get; set; }
       
    }
}
