﻿using Buffet.Models.Buffet.Situacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.Models.Buffet.Convidado
{
    public class ConvidadoEntity
    {
        public ConvidadoEntity()
        {
            Id = new Guid();
        }

        public Guid Id { get; private set; }
        public Guid EventoId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataInserido { get; set; }
        public DateTime DataModificacao { get; set; }
        public SituacaoConvidadoEntity Situacao { get; set; }
        public string TextoObservacao { get; set; }

    }
}
