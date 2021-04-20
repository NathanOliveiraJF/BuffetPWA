using Buffet.Models.Acesso;
using Buffet.Models.Buffet;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.Data
{
    public class DataBaseContext : IdentityDbContext<Usuario, Papel, Guid>
    {
        public DbSet<ClienteEntity> Clientes { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }
    }
}
