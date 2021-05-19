using Buffet.Models.Acesso;
using Buffet.Models.Buffet;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buffet.Models.Buffet.Cliente;
using Buffet.Models.Buffet.Evento;

using Buffet.Models.Buffet.Convidado;
using Buffet.Models.Buffet.Local;

namespace Buffet.Data
{
    public class DataBaseContext : IdentityDbContext<Usuario, Papel, Guid>
    {
        //client
        public DbSet<ClienteEntity> Clientes { get; set; }
        public DbSet<TipoClienteEntity> TipoCliente { get; set; }

        //events
        public DbSet<EventoEntity> Eventos { get; set; }
        public DbSet<TipoEventoEntity> TipoEvento { get; set; }
        public DbSet<SituacaoEventoEntity> SituacaoEvento { get; set; }

        //Guest
        public DbSet<ConvidadoEntity> Convidados { get; set; }
        public DbSet<SituacaoConvidadoEntity> SituacaoConvidado { get; set; }

        //LocalEntity
        public DbSet<LocalEntity> LocalEntity { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }
    }
}
