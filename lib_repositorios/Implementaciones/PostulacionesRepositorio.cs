using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class PostulacionesRepositorio : IPostulacionesRepositorio
    {
        private Conexion? conexion = null;
        private IAuditoriaRepositorio? iAuditoriaRepositorio;

        public PostulacionesRepositorio(Conexion conexion,
             IAuditoriaRepositorio iAuditoriaRepositorio)
        {

            this.conexion = conexion;
            this.iAuditoriaRepositorio = iAuditoriaRepositorio;
        }

        public List<Postulaciones> Listar()
        {
            iAuditoriaRepositorio!.Guardar(new Auditoria
            {
                Tabla = "Postulaciones",
                Referencia = 0,
                Accion = "Listar"

            });
            return Buscar(x => x != null);
        }

        public List<Postulaciones> Buscar(Expression<Func<Postulaciones, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Postulaciones Guardar(Postulaciones entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            iAuditoriaRepositorio!.Guardar(new Auditoria
            {
                Tabla = "Postulaciones",
                Referencia = entidad.Id,
                Accion = "Guardar"

            });
            return entidad;
        }

        public Postulaciones Modificar(Postulaciones entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            iAuditoriaRepositorio!.Guardar(new Auditoria
            {
                Tabla = "Postulaciones",
                Referencia = entidad.Id,
                Accion = "Modificar"

            });
            return entidad;
        }

        public Postulaciones Borrar(Postulaciones entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            iAuditoriaRepositorio!.Guardar(new Auditoria
            {
                Tabla = "Postulaciones",
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