﻿using Buffet.Models.Buffet.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buffet.Data;
using Microsoft.EntityFrameworkCore;
using Buffet.RequestModels.Buffet;

namespace Buffet.Models.Buffet
{
    public class ClientService
    {
        private readonly DataBaseContext _dbContext;
        public ClientService(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IEnumerable<ClienteEntity> GetAll()
        {
            return _dbContext.Clientes
            .Include(x => x.Events);
        }

        public ClienteEntity GetById(Guid id)
        {
            ClienteEntity c = _dbContext.Clientes.Find(id);
            
            return c ?? null;
        }
        
        public List<ClienteEntity> GetByFilter(string name)
        {
            return _dbContext.Clientes.Where(x => x.Nome.Contains(name)).ToList();
        }
        
        public TipoClienteEntity GetByDescriptionTypeClient(string desc)
        {
            TipoClienteEntity c = _dbContext.TipoCliente.FirstOrDefault(x => x.Descricao == desc);
            
            return c ?? null;
        }

        public void ClientRegister(ClienteRegisterRequestModel register)
        {
            ClienteEntity c = new ClienteEntity
            {
                Tipo = GetByDescriptionTypeClient(register.TipoCliente),
                Email = register.Email,
                Nome = register.Nome,
                Endereco = register.Endereco,
                Cpf = register.Cpf,
                DataNascimento = DateTime.Parse(register.DataNascimento),
                Cnpj = register.Cnpj,
                TextoObservacao = register.TextoObservacao,
                DataInserido = DateTime.Now,
                DataModificacao = DateTime.Now

            };

            _dbContext.Clientes.Add(c);
             _dbContext.SaveChanges();
            
        }
        
        
    }
}