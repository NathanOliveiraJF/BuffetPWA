using Buffet.Models.Buffet.Cliente;
using System;

namespace Buffet.RequestModels.Buffet
{
    public class ClienteRegisterRequestModel
    {
        public ClienteRegisterRequestModel()
        {
            TipoCliente = "";
            Nome = "";
            Email = "";
            Endereco = "";
            Cpf = "";
            Cnpj = "";
            TextoObservacao = "";
        }

        public string TipoCliente { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Cpf { get; set; }
        public string DataNascimento { get; set; }
        public string Cnpj { get; set; }
        public string TextoObservacao { get; set; }
        
    }
}
