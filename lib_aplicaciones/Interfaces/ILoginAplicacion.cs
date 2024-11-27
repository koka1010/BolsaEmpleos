using lib_entidades.Modelos;
using System.Linq.Expressions;
namespace lib_aplicaciones.Interfaces
{
    public interface ILoginAplicacion
    {
        void Configurar(string string_conexion);
        List<Login> Buscar(Login entidad, string tipo);
        List<Login> Listar();
        Login Guardar(Login entidad);
        Login Modificar(Login entidad);
        Login Borrar(Login entidad);
    }
}