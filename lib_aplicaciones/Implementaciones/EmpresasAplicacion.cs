using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;
using lib_entidades.Modelos;

namespace lib_aplicaciones.Implementaciones
{
    public class EmpresasAplicacion : IEmpresasAplicacion
    {
        private IEmpresasRepositorio? iRepositorio = null;

        public EmpresasAplicacion(IEmpresasRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Empresas Borrar(Empresas entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public Empresas Guardar(Empresas entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Empresas> Listar()
        {
            return iRepositorio!.Listar();
        }

        public List<Empresas> Buscar(Empresas entidad, string tipo)
        {
            Expression<Func<Empresas, bool>>? condiciones = null;

            switch (tipo.ToUpper())
            {
                case "Nom_Empresa": condiciones = x => x.Nom_Empresa!.Contains(entidad.Nom_Empresa!); break;
                default: condiciones = x => x.Id == entidad.Id; break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }


        public Empresas Modificar(Empresas entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Modificar(entidad);
            return entidad;
        }
    }
}