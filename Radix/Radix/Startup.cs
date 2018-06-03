using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Repository.Interfaces;
using Services;
using Services.Interfaces;

namespace Radix
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<Contexto>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IAdquirenteBusiness, AdquirenteBusiness>();
            services.AddScoped<IAdquirenteRepository, AdquirenteRepository>();
            services.AddScoped<ILojaBusiness, LojaBusiness>();
            services.AddScoped<ILojaRepository, LojaRepository>();
            services.AddScoped<ITransacaoBusiness, TransacaoBusiness>();
            services.AddScoped<ITransacaoRepository, TransacaoRepository>();
            services.AddScoped<IVendaBusiness, VendaBusiness>();
            services.AddScoped<IAntiFraudeBusiness, AntiFraudeBusiness>();
            services.AddScoped<ICieloBusiness, CieloBusiness>();
            services.AddScoped<IStoneBusiness, StoneBusiness>();
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseMvc();
        }

    }
}
