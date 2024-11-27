using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class VacantesRepositorio : IVacantesRepositorio
    {
        private Conexion? conexion = null;
        private IAuditoriaRepositorio? iAuditoriaRepositorio;

        public VacantesRepositorio(Conexion conexion,
             IAuditoriaRepositorio iAuditoriaRepositorio)
        {

            this.conexion = conexion;
            this.iAuditoriaRepositorio = iAuditoriaRepositorio;
        }

        public List<Vacantes> Listar()
        {
            iAuditoriaRepositorio!.Guardar(new Auditoria
            {
                Tabla = "Vacantes",
                Referencia = 0,
                Accion = "Listar"

            });
            return Buscar(x => x != null);
        }

        public List<Vacantes> Buscar(Expression<Func<Vacantes, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Vacantes Guardar(Vacantes entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            iAuditoriaRepositorio!.Guardar(new Auditoria
            {
                Tabla = "Vacantes",
                Referencia = entidad.Id,
                Accion = "Guardar"

            });
            return entidad;
        }

        public Vacantes Modificar(Vacantes entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            iAuditoriaRepositorio!.Guardar(new Auditoria
            {
                Tabla = "Vacantes",
                Referencia = entidad.Id,
                Accion = "Modificar"

            });
            return entidad;
        }

        public Vacantes Borrar(Vacantes entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            iAuditoriaRepositorio!.Guardar(new Auditoria
            {
                Tabla = "Vacantes",
                Referencia = entidad.Id,
                Accion = "Borrar"

            });
            return entidad;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }
    }
}