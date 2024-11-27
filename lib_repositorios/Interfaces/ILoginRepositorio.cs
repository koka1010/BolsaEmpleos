using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    public interface ILoginRepositorio
    {
        void Configurar(string string_conexion);

        List<Login> Listar();
        List<Login> Buscar(Expression<Func<Login, bool>> condiciones);
        Login Guardar(Login entidad);
        Login Modificar(Login entidad);
        Login Borrar(Login entidad);
    }
}