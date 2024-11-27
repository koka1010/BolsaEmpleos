using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class PersonasRepositorio : IPersonasRepositorio
    {
        private Conexion? conexion = null;
        private IAuditoriaRepositorio? iAuditoriaRepositorio;

        public PersonasRepositorio(Conexion conexion,
             IAuditoriaRepositorio iAuditoriaRepositorio)
        {

            this.conexion = conexion;
            this.iAuditoriaRepositorio = iAuditoriaRepositorio;
        }

        public List<Personas> Listar()
        {
            iAuditoriaRepositorio!.Guardar(new Auditoria
            {
                Tabla = "Personas",
                Referencia = 0,
                Accion = "Listar"

            });
            return Buscar(x => x != null);
        }

        public List<Personas> Buscar(Expression<Func<Personas, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Personas Guardar(Personas entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            iAuditoriaRepositorio!.Guardar(new Auditoria
            {
                Tabla = "Personas",
                Referencia = entidad.Id,
                Accion = "Guardar"

            });
            return entidad;
        }

        public Personas Modificar(Personas entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            iAuditoriaRepositorio!.Guardar(new Auditoria
            {
                Tabla = "Personas",
                Referencia = entidad.Id,
                Accion = "Modificar"

            });
            return entidad;
        }

        public Personas Borrar(Personas entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            iAuditoriaRepositorio!.Guardar(new Auditoria
            {
                Tabla = "Personas",
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