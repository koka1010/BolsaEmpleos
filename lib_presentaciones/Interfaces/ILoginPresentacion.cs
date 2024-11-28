using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface ILoginPresentacion
    {
        Task<List<Login>> Listar();
        Task<List<Login>> Buscar(Login entidad, string tipo);
        Task<Login> Guardar(Login entidad);
        Task<Login> Modificar(Login entidad);
        Task<Login> Borrar(Login entidad);
    }
}