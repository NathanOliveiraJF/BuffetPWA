using Buffet.Models.Buffet.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buffet.Data;
using Microsoft.EntityFrameworkCore;
using Buffet.RequestModels.Buffet;

namespace Buffet.Models.Buffet.Convidado
{
    public class ConvidadoService
    {
        private readonly DataBaseContext _dbContext;
        public ConvidadoService(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }


        public ICollection<ConvidadoEntity> GetAll()
        {
            return _dbContext.Convidados.ToList();
        }

        public ConvidadoEntity GetById(Guid id)
        {
            ConvidadoEntity c = _dbContext.Convidados.Find(id);
            
            return c ?? null;
        }
        
        public void Create(string descricao)
        {
            ConvidadoEntity Convidados = new ConvidadoEntity();
            //TODO: CRIAR VALIDACAO
            _dbContext.Convidados.Add(Convidados);
            _dbContext.SaveChanges();
        }


        public void Remove(Guid id)
        {
            ConvidadoEntity Convidados = GetById(id);
            _dbContext.Convidados.Remove(Convidados);
            _dbContext.SaveChanges();
        }

        public void Edit(Guid id, string descricao)
        {
            //TODO: CRIAR VALIDACAO
            ConvidadoEntity Convidados = GetById(id);
         //   Convidados.Descricao = descricao;
            _dbContext.Convidados.Update(Convidados);
            _dbContext.SaveChanges();
        }

    }
}
