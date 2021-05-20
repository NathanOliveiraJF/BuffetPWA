using Buffet.Models.Buffet.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buffet.Data;
using Microsoft.EntityFrameworkCore;
using Buffet.RequestModels.Buffet;
using Buffet.RequestModels.Buffet.Evento;
using Buffet.Models.Buffet.Local;

namespace Buffet.Models.Buffet.Evento
{
    public class EventoService
    {
        private readonly DataBaseContext _dbContext;
        private readonly ClientService _clientService;
        private readonly SituacaoEventoService _situacaoEventoService;
        private readonly TipoEventoService _tipoEventoService;
        private readonly LocalService _localService;


        public EventoService(DataBaseContext dbContext, ClientService clientService, 
            SituacaoEventoService situacaoEventoService, TipoEventoService tipoEventoService,
            LocalService localService)
        {
            _dbContext = dbContext;
            _clientService = clientService;
            _situacaoEventoService = situacaoEventoService;
            _tipoEventoService = tipoEventoService;
            _localService = localService;
        }


        public ICollection<EventoEntity> GetAll()
        {
            return _dbContext.Eventos
                .Include(x => x.Cliente)
                .Include(x => x.Situacao)
                .Include(x => x.Tipo)
                .Include(x => x.Local)
                .ToList();
        }

        public EventoEntity GetById(Guid id)
        {
            EventoEntity c = _dbContext.Eventos.Find(id);
            
            return c ?? null;
        }
        
        public void Create(EventoRegisterRequestModel request)
        {
            EventoEntity Eventos = new EventoEntity 
            {  
                Cliente = _clientService.GetAll()
                .FirstOrDefault(x => x.Id.ToString() == request.Cliente),
              
                Situacao = _situacaoEventoService.GetAll()
                .FirstOrDefault(x => x.Id.ToString() == request.Situacao),
                
                Tipo = _tipoEventoService.GetAll()
                .FirstOrDefault(x => x.Id.ToString() == request.TipoEvento),
                
                Local = _localService.GetAll()
                .FirstOrDefault(x => x.Id.ToString() == request.Local),
                
                Descricao = request.Descricao,
                Nome = request.Nome,
                TextoObservacao = request.TextoObservacao,
                DataInicio = DateTime.Parse(request.DataInicio),
                DataTermino = DateTime.Parse(request.DataTermino),
                DataModificacao = DateTime.Now,
                DataInserido = DateTime.Now

            };

            //TODO: CRIAR VALIDACAO
            _dbContext.Eventos.Add(Eventos);
            _dbContext.SaveChanges();
        }


        public void Delete(Guid id)
        {
            EventoEntity Eventos = GetById(id);
            _dbContext.Eventos.Remove(Eventos);
            _dbContext.SaveChanges();
        }

        public void Edit(Guid id, EditEventoRegisterRequestModel edit)
        {
            //TODO: CRIAR VALIDACAO
            EventoEntity eventos = GetById(id);
            eventos.Descricao = edit.Descricao;
            eventos.Nome = edit.Nome;
            _dbContext.Eventos.Update(eventos);
            _dbContext.SaveChanges();
        }

    }
}
