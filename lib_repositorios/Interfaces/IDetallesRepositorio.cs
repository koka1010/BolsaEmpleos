using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    public interface IDetallesRepositorio
    {
        List<Detalles> Listar();
        List<Detalles> Buscar(Expression<Func<Detalles, bool>> condiciones);
        Detalles Guardar(Detalles entidad);
        Detalles Modificar(Detalles entidad);
        Detalles Borrar(Detalles entidad);
    }
}