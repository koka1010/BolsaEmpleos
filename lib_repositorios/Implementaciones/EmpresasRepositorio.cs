using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class EmpresasRepositorio : IEmpresasRepositorio
    {
        private Conexion? conexion = null;
        private IAuditoriaRepositorio? iAuditoriaRepositorio;

        public EmpresasRepositorio(Conexion conexion,
             IAuditoriaRepositorio iAuditoriaRepositorio)
        {

            this.conexion = conexion;
            this.iAuditoriaRepositorio = iAuditoriaRepositorio;
        }

        public List<Empresas> Listar()
        {
            iAuditoriaRepositorio!.Guardar(new Auditoria
            {
                Tabla = "Empresas",
                Referencia = 0,
                Accion = "Listar"

            });
            return Buscar(x => x != null);
        }

        public List<Empresas> Buscar(Expression<Func<Empresas, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Empresas Guardar(Empresas entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            iAuditoriaRepositorio!.Guardar(new Auditoria
            {
                Tabla = "Empresas",
                Referencia = entidad.Id,
                Accion = "Guardar"

            });
            return entidad;
        }

        public Empresas Modificar(Empresas entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            iAuditoriaRepositorio!.Guardar(new Auditoria
            {
                Tabla = "Empresas",
                Referencia = entidad.Id,
                Accion = "Modificar"

            });
            return entidad;
        }

        public Empresas Borrar(Empresas entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            iAuditoriaRepositorio!.Guardar(new Auditoria
            {
                Tabla = "Empresas",
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