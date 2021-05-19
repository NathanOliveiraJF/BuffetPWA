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
    public class SituacaoConvidadoService
    {
        private readonly DataBaseContext _dbContext;
        public SituacaoConvidadoService(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }


        public ICollection<SituacaoConvidadoEntity> GetAll()
        {
            return _dbContext.SituacaoConvidado.ToList();
        }

        public SituacaoConvidadoEntity GetById(Guid id)
        {
            SituacaoConvidadoEntity c = _dbContext.SituacaoConvidado.Find(id);
            
            return c ?? null;
        }
        
        public void Create(string descricao)
        {
            SituacaoConvidadoEntity SituacaoConvidado = new SituacaoConvidadoEntity { Descricao = descricao };
            //TODO: CRIAR VALIDACAO
            _dbContext.SituacaoConvidado.Add(SituacaoConvidado);
            _dbContext.SaveChanges();
        }


        public void Remove(Guid id)
        {
            SituacaoConvidadoEntity SituacaoConvidado = GetById(id);
            _dbContext.SituacaoConvidado.Remove(SituacaoConvidado);
            _dbContext.SaveChanges();
        }

        public void Edit(Guid id, string descricao)
        {
            //TODO: CRIAR VALIDACAO
            SituacaoConvidadoEntity SituacaoConvidado = GetById(id);
            SituacaoConvidado.Descricao = descricao;
            _dbContext.SituacaoConvidado.Update(SituacaoConvidado);
            _dbContext.SaveChanges();
        }

    }
}
