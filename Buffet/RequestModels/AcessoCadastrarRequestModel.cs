using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.RequestModels
{
    public class AcessoCadastrarRequestModel
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string SenhaConfirmacao { get; set; }
    }
}
