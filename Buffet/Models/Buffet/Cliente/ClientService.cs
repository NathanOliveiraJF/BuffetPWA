using Buffet.Models.Buffet.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buffet.Data;
using Microsoft.EntityFrameworkCore;
using Buffet.RequestModels.Buffet;
using Buffet.RequestModels.Buffet.Cliente;

namespace Buffet.Models.Buffet.Cliente
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
            return _dbContext.Clientes;
        }

        public ClienteEntity GetById(Guid id)
        {
            ClienteEntity c = _dbContext.Clientes
                .FirstOrDefault(x => x.Id == id);
            
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

        public void Edit(Guid id, EditClientRequestModel edit)
        {
            //TODO TRATAMENTOS
            var clienteEntity = _dbContext.Clientes.Find(id);
            clienteEntity.Nome = edit.Nome;
            clienteEntity.Cpf = edit.Cpf;
            clienteEntity.Cnpj = edit.Cnpj;
            clienteEntity.Email = edit.Email;
            clienteEntity.Endereco = edit.Endereco;
            clienteEntity.TextoObservacao = edit.TextoObservacao;
            clienteEntity.DataNascimento = DateTime.Parse(edit.DataNascimento);
            clienteEntity.DataModificacao = DateTime.Now;

            _dbContext.Clientes.Update(clienteEntity);
            _dbContext.SaveChanges();
        }
        
        public void Delete(Guid id)
        {
            //TODO TRATAMENTOS
            ClienteEntity c = _dbContext.Clientes.Find(id);
            _dbContext.Remove(c);
            _dbContext.SaveChanges();
        }   
    }
}
