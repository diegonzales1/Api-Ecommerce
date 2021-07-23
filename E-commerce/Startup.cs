using Dominio.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Repositorio.Contexto;
using Repositorio.Repositorios;

namespace E_commerce
{
    public class Startup
    {
        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Libera acesso do Cors
            services.AddCors();

            //Banco de Dados
            services.AddDbContext<BancoContexto>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Add Scopo
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<ICarrinhoRepositorio, CarrinhoRepositorio>();

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Api E-Commerce",
                    Version = "v1",
                    Description = ".NET 01 API E-COMMERCE",
                    Contact = new OpenApiContact
                    {
                        Name = "Diego, Everton, Kayque, Victor"
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
                c.SwaggerEndpoint("/swagger/v1/swagger.json", ".NET 01 API E-COMMERCE")
            );

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Swagger - tudo o que for $ vai direto para o swagger
            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
        }
    }
}
