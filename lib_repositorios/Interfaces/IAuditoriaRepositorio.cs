using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    public interface IAuditoriaRepositorio
    {
        void Configurar(string string_conexion);

        List<Auditoria> Listar();
        List<Auditoria> Buscar(Expression<Func<Auditoria, bool>> condiciones);
        Auditoria Guardar(Auditoria entidad);
        Auditoria Modificar(Auditoria entidad);
        Auditoria Borrar(Auditoria entidad);
    }
}