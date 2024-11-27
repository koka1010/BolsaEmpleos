using lib_entidades.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace lib_repositorios
{
    public partial class Conexion : DbContext
    {
        private int tamaño = 50;
        public string? StringConnection { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConnection!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected DbSet<Empresas>? Empresas { get; set; }
        protected DbSet<Personas>? Personas { get; set; }
        protected DbSet<Vacantes>? Vacantes { get; set; }
        protected DbSet<Estudios>? Estudios { get; set; }
        protected DbSet<Postulaciones>? Postulaciones { get; set; }
        protected DbSet<Detalles>? Detalles { get; set; }

        public virtual DbSet<T> ObtenerSet<T>() where T : class, new()
        {
            return this.Set<T>();
        }
        public virtual List<T> Listar<T>() where T : class, new()
        {
            return this.Set<T>()
            .Take(tamaño)
            .ToList();
        }
        public virtual List<Detalles> Buscar(Expression<Func<Detalles, bool>> condiciones)
        {
            return this.Set<Detalles>()
                .Include(x => x._Persona)
                .Include(x => x._Postulacion)
                .Where(condiciones)
                .ToList();
        }
        public virtual List<T> Buscar<T>(Expression<Func<T, bool>> condiciones) where T : class, new()
        {
            return this.Set<T>()
            .Where(condiciones)
            .Take(tamaño)
            .ToList();
        }

        public virtual bool Existe<T>(Expression<Func<T, bool>> condiciones) where T : class, new()
        {
            return this.Set<T>().Any(condiciones);
        }

        public virtual void Guardar<T>(T entidad) where T : class, new()
        {
            this.Set<T>().Add(entidad);
        }

        public virtual void Modificar<T>(T entidad) where T : class
        {
            var entry = this.Entry(entidad);
            entry.State = EntityState.Modified;
        }

        public virtual void Borrar<T>(T entidad) where T : class, new()
        {
            this.Set<T>().Remove(entidad);
        }

        public virtual void Separar<T>(T entidad) where T : class, new()
        {
            this.Entry(entidad).State =
            EntityState.Detached;
        }

        public virtual void GuardarCambios()
        {
            this.SaveChanges();
        }
    }
}