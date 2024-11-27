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
        protected DbSet<Login>? Login { get; set; }
        protected DbSet<Auditoria>? Auditoria { get; set; }

        public virtual List<T> Listar<T>() where T : class, new()
        {
            return this.Set<T>().ToList();
        }
        public virtual List<T> Buscar<T>(Expression<Func<T, bool>> condiciones) where T : class, new()
        {
            return this.Set<T>().Where(condiciones).ToList();
        }
        public virtual List<Detalles> Buscar(Expression<Func<Detalles, bool>> condiciones)
        {
            return this.Set<Detalles>()
                .Include(x => x._Persona)
                .Include(x => x._Postulacion)
                .Where(condiciones)
                .ToList();
        }
        public virtual List<Estudios> Buscar(Expression<Func<Estudios, bool>> condiciones)
        {
            return this.Set<Estudios>()
                .Include(x => x._Persona)
                .Where(condiciones)
                .ToList();
        }
        public virtual List<Postulaciones> Buscar(Expression<Func<Postulaciones, bool>> condiciones)
        {
            return this.Set<Postulaciones>()
                .Include(x => x._Vacante)
                .Where(condiciones)
                .ToList();
        }
        public virtual List<Vacantes> Buscar(Expression<Func<Vacantes, bool>> condiciones)
        {
            return this.Set<Vacantes>()
                .Include(x => x._Empresa)
                .Where(condiciones)
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