using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class AuditoriaRepositorio : IAuditoriaRepositorio
    {
        private Conexion? conexion = null;

        public AuditoriaRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public List<Auditoria> Listar()
        {
            return conexion!.Listar<Auditoria>();
        }

        public List<Auditoria> Buscar(Expression<Func<Auditoria, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Auditoria Guardar(Auditoria entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Auditoria Modificar(Auditoria entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Auditoria Borrar(Auditoria entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }
    }
}
