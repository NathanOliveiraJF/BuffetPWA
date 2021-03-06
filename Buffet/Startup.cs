using Buffet.Data;
using Buffet.Models.Acesso;
using Buffet.Models.Acesso.Services;
using Buffet.Models.Buffet;
using Buffet.Models.Buffet.Cliente;
using Buffet.Models.Buffet.Convidado;
using Buffet.Models.Buffet.Evento;
using Buffet.Models.Buffet.Local;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<DataBaseContext>(options =>
               options.UseMySql(Configuration.GetConnectionString("BuffetDb"))
           );

            // Configurar o Controle de Acesso de Usu?rios
            services.AddIdentity<Usuario, Papel>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 8;
            }).AddEntityFrameworkStores<DataBaseContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Acesso/Login";
            });

            services.AddTransient<AcessoService>();
            services.AddTransient<ClientService>();
            services.AddTransient<TipoEventoService>();
            services.AddTransient<SituacaoEventoService>();
            services.AddTransient<SituacaoConvidadoService>();
            services.AddTransient<LocalService>();
            services.AddTransient<EventoService>();
            services.AddTransient<ConvidadoService>();




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Acesso}/{action=Login}/{id?}");
            });
        }
    }
}
