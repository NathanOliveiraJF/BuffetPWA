using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.Models.Acesso.Exceptions
{
    public class CadastrarUsuarioException : Exception
    {
        public CadastrarUsuarioException(IEnumerable<IdentityError> errors)
        {
            Errors = errors;
        }

        public IEnumerable<IdentityError> Errors { get; set; }
    }
}
