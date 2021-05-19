using Buffet.Models.Buffet.Cliente;
using System;

namespace Buffet.RequestModels.Buffet.Local
{
    public class LocalRegisterRequestModel
    {
        public LocalRegisterRequestModel()
        {
            Descricao = "";
            Endereco = "";
        }

        public string Descricao { get; set; }
        public string Endereco { get; set; }

    }
}
