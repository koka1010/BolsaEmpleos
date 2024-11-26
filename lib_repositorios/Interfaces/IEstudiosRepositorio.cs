using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    public interface IEstudiosRepositorio
    {
        List<Estudios> Listar();
        List<Estudios> Buscar(Expression<Func<Estudios, bool>> condiciones);
        Estudios Guardar(Estudios entidad);
        Estudios Modificar(Estudios entidad);
        Estudios Borrar(Estudios entidad);
    }
}