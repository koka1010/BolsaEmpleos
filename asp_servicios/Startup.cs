﻿using asp_servicios.Controllers;
using lib_aplicaciones.Implementaciones;
using lib_aplicaciones.Interfaces;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace asp_servicios
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration? Configuration { set; get; }

        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.Configure<IISServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped<Conexion, Conexion>();
            // Repositorios
            services.AddScoped<IDetallesRepositorio, DetallesRepositorio>();
            services.AddScoped<IAuditoriaRepositorio, AuditoriaRepositorio>();
            services.AddScoped<IEmpresasRepositorio, EmpresasRepositorio>();
            services.AddScoped<IEstudiosRepositorio, EstudiosRepositorio>();
            services.AddScoped<IPersonasRepositorio, PersonasRepositorio>();
            services.AddScoped<IPostulacionesRepositorio, PostulacionesRepositorio>();
            services.AddScoped<IVacantesRepositorio, VacantesRepositorio>();
            services.AddScoped<ILoginRepositorio, LoginRepositorio>();

            // Aplicaciones
            services.AddScoped<IDetallesAplicacion, DetallesAplicacion>();
            services.AddScoped<IEmpresasAplicacion, EmpresasAplicacion>();
            services.AddScoped<IEstudiosAplicacion, EstudiosAplicacion>();
            services.AddScoped<IPersonasAplicacion, PersonasAplicacion>();
            services.AddScoped<IPostulacionesAplicacion, PostulacionesAplicacion>();
            services.AddScoped<IVacantesAplicacion, VacantesAplicacion>();
            services.AddScoped<ILoginAplicacion, LoginAplicacion>();

            // Controladores
            services.AddScoped<TokenController, TokenController>();

            services.AddCors(o => o.AddDefaultPolicy(b => b.AllowAnyOrigin()));
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
            app.UseRouting();
            app.UseCors();
        }
    }
}