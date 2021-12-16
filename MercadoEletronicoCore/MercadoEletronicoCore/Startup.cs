using MercadoEletronicoCore.Models;
using MercadoEletronicoCore.Services.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;
using Swashbuckle.Swagger;
using Microsoft.OpenApi.Models;
using MercadoEletronicoCore.Services;
using Microsoft.EntityFrameworkCore;
using MercadoEletronicoCore.Context;
using MercadoEletronicoCore.Repository;

namespace MercadoEletronicoCore
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // requires using Microsoft.Extensions.Options
            //services.Configure<BookstoreDatabaseSettings>(
            //    Configuration.GetSection(nameof(BookstoreDatabaseSettings)));

            //services.AddSingleton<IBookstoreDatabaseSettings>(sp =>
            //    sp.GetRequiredService<IOptions<BookstoreDatabaseSettings>>().Value);

            services.AddControllers().AddNewtonsoftJson(x => x.UseMemberCasing());

            //services.AddSingleton<PedidoItemService>();

            services.AddScoped<IPedidoItemRepository, PedidoItemRepository>();

            services.AddScoped<IPedidoItemService, PedidoItemService>();

            services.AddDbContext<DatabaseContext>(opt => opt.UseInMemoryDatabase("pedido"));

            // Configurando o serviço de documentação do Swagger
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Mercado Eletrônico API",
                    Description = "Prova para vaga na Mercado Eletrônico"
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                s.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();                
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(end =>
            {
                end.MapControllers();
            });

            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Mercado Eletrônico");
                c.RoutePrefix = string.Empty;
            });


        }

        
    }
}
