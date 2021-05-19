using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buffet.Data;
using Microsoft.EntityFrameworkCore;
using Buffet.RequestModels.Buffet;
using Buffet.RequestModels.Buffet.Local;

namespace Buffet.Models.Buffet.Local
{
    public class LocalService
    {
        private readonly DataBaseContext _dbContext;
        public LocalService(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<LocalEntity> GetAll()
        {
            return _dbContext.LocalEntity.ToList();
            
        }

        public LocalEntity GetById(Guid id)
        {
            LocalEntity c = _dbContext.LocalEntity.Include(x => x.Events).FirstOrDefault(x => x.Id == id);
            
            return c ?? null;
        }
        
        public List<LocalEntity> GetByFilter(string name)
        {
            return _dbContext.LocalEntity.Where(x => x.Descricao.Contains(name)).ToList();
        }
        

        public void Create(LocalRegisterRequestModel register)
        {
            LocalEntity c = new LocalEntity
            {
                Descricao = register.Descricao,
                Endereco = register.Endereco
            };

            _dbContext.LocalEntity.Add(c);
            _dbContext.SaveChanges();
        }

        public void Edit(Guid id, EditLocalRequestModel edit)
        {
            //TODO TRATAMENTOS
            var localEntity = _dbContext.LocalEntity.Find(id);
            localEntity.Descricao = edit.Descricao;
            localEntity.Endereco = edit.Endereco;

            _dbContext.LocalEntity.Update(localEntity);
            _dbContext.SaveChanges();
        }
        
        public void Delete(Guid id)
        {
            //TODO TRATAMENTOS
            LocalEntity c = _dbContext.LocalEntity.Find(id);
            _dbContext.LocalEntity.Remove(c);
            _dbContext.SaveChanges();
        }   
    }
}
