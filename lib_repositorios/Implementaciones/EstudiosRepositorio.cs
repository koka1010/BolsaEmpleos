using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class EstudiosRepositorio : IEstudiosRepositorio
    {
        private Conexion? conexion = null;
        private IAuditoriaRepositorio? iAuditoriaRepositorio;

        public EstudiosRepositorio(Conexion conexion,
             IAuditoriaRepositorio iAuditoriaRepositorio)
        {

            this.conexion = conexion;
            this.iAuditoriaRepositorio = iAuditoriaRepositorio;
        }

        public List<Estudios> Listar()
        {
            iAuditoriaRepositorio!.Guardar(new Auditoria
            {
                Tabla = "Estudios",
                Referencia = 0,
                Accion = "Listar"

            });
            return Buscar(x => x != null);
        }

        public List<Estudios> Buscar(Expression<Func<Estudios, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Estudios Guardar(Estudios entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            iAuditoriaRepositorio!.Guardar(new Auditoria
            {
                Tabla = "Estudios",
                Referencia = entidad.Id,
                Accion = "Guardar"

            });
            return entidad;
        }

        public Estudios Modificar(Estudios entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            iAuditoriaRepositorio!.Guardar(new Auditoria
            {
                Tabla = "Estudios",
                Referencia = entidad.Id,
                Accion = "Modificar"

            });
            return entidad;
        }

        public Estudios Borrar(Estudios entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            iAuditoriaRepositorio!.Guardar(new Auditoria
            {
                Tabla = "Estudios",
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