using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    public interface IPersonasRepositorio
    {
        List<Personas> Listar();
        List<Personas> Buscar(Expression<Func<Personas, bool>> condiciones);
        Personas Guardar(Personas entidad);
        Personas Modificar(Personas entidad);
        Personas Borrar(Personas entidad);
    }
}