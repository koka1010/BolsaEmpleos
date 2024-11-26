using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    public interface IPostulacionesRepositorio
    {
        List<Postulaciones> Listar();
        List<Postulaciones> Buscar(Expression<Func<Postulaciones, bool>> condiciones);
        Postulaciones Guardar(Postulaciones entidad);
        Postulaciones Modificar(Postulaciones entidad);
        Postulaciones Borrar(Postulaciones entidad);
    }
}