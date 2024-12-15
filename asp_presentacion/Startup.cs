using lib_comunicaciones.Implementaciones;
using lib_comunicaciones.Interfaces;
using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;

namespace asp_presentacion
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
            // Comunicaciones
            services.AddScoped<IDetallesComunicacion, DetallesComunicacion>();
            services.AddScoped<IEmpresasComunicacion, EmpresasComunicacion>();
            services.AddScoped<IEstudiosComunicacion, EstudiosComunicacion>();
            services.AddScoped<ILoginComunicacion, LoginComunicacion>();
            services.AddScoped<IPersonasComunicacion, PersonasComunicacion>();
            services.AddScoped<IPostulacionesComunicacion, PostulacionesComunicacion>();
            services.AddScoped<IVacantesComunicacion, VacantesComunicacion>();


            // Presentaciones
            services.AddScoped<IDetallesPresentacion, DetallesPresentacion>();
            services.AddScoped<IEmpresasPresentacion, EmpresasPresentacion>();
            services.AddScoped<IEstudiosPresentacion, EstudiosPresentacion>();
            services.AddScoped<ILoginPresentacion, LoginPresentacion>();
            services.AddScoped<IPersonasPresentacion, PersonasPresentacion>();
            services.AddScoped<IPostulacionesPresentacion, PostulacionesPresentacion>();
            services.AddScoped<IVacantesPresentacion, VacantesPresentacion>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddRazorPages();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();
            app.UseSession();
            app.Run();
        }
    }
}