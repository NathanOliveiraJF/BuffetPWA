using Buffet.Models.Buffet.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buffet.Data;
using Microsoft.EntityFrameworkCore;
using Buffet.RequestModels.Buffet;
using Buffet.Models.Buffet.Situacao;

namespace Buffet.Models.Buffet.Evento
{
    public class SituacaoEventoService
    {
        private readonly DataBaseContext _dbContext;
        public SituacaoEventoService(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }


        public ICollection<SituacaoEventoEntity> GetAll()
        {
            return _dbContext.SituacaoEvento.ToList();
        }

        public SituacaoEventoEntity GetById(Guid id)
        {
            SituacaoEventoEntity c = _dbContext.SituacaoEvento.Find(id);
            
            return c ?? null;
        }
        
        public void Create(string descricao)
        {
            SituacaoEventoEntity SituacaoEvento = new SituacaoEventoEntity { Descricao = descricao };
            //TODO: CRIAR VALIDACAO
            _dbContext.SituacaoEvento.Add(SituacaoEvento);
            _dbContext.SaveChanges();
        }


        public void Remove(Guid id)
        {
            SituacaoEventoEntity SituacaoEvento = GetById(id);
            _dbContext.SituacaoEvento.Remove(SituacaoEvento);
            _dbContext.SaveChanges();
        }

        public void Edit(Guid id, string descricao)
        {
            //TODO: CRIAR VALIDACAO
            SituacaoEventoEntity SituacaoEvento = GetById(id);
            SituacaoEvento.Descricao = descricao;
            _dbContext.SituacaoEvento.Update(SituacaoEvento);
            _dbContext.SaveChanges();
        }

    }
}
