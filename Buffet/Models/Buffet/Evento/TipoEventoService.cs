using Buffet.Models.Buffet.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buffet.Data;
using Microsoft.EntityFrameworkCore;
using Buffet.RequestModels.Buffet;

namespace Buffet.Models.Buffet.Evento
{
    public class TipoEventoService
    {
        private readonly DataBaseContext _dbContext;
        public TipoEventoService(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }


        public ICollection<TipoEventoEntity> GetAll()
        {
            return _dbContext.TipoEvento.ToList();
        }

        public TipoEventoEntity GetById(Guid id)
        {
            TipoEventoEntity c = _dbContext.TipoEvento.Find(id);
            
            return c ?? null;
        }
        
        public void Create(string descricao)
        {
            TipoEventoEntity tipoEvento = new TipoEventoEntity { Descricao = descricao };
            //TODO: CRIAR VALIDACAO
            _dbContext.TipoEvento.Add(tipoEvento);
            _dbContext.SaveChanges();
        }


        public void Remove(Guid id)
        {
            TipoEventoEntity tipoEvento = GetById(id);
            _dbContext.TipoEvento.Remove(tipoEvento);
            _dbContext.SaveChanges();
        }

        public void Edit(Guid id, string descricao)
        {
            //TODO: CRIAR VALIDACAO
            TipoEventoEntity tipoEvento = GetById(id);
            tipoEvento.Descricao = descricao;
            _dbContext.TipoEvento.Update(tipoEvento);
            _dbContext.SaveChanges();
        }

    }
}
