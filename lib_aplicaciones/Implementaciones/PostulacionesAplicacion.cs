using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;
using lib_entidades.Modelos;

namespace lib_aplicaciones.Implementaciones
{
    public class PostulacionesAplicacion : IPostulacionesAplicacion
    {
        private IPostulacionesRepositorio? iRepositorio = null;

        public PostulacionesAplicacion(IPostulacionesRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Postulaciones Borrar(Postulaciones entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public Postulaciones Guardar(Postulaciones entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Postulaciones> Listar()
        {
            return iRepositorio!.Listar();
        }

        public List<Postulaciones> Buscar(Postulaciones entidad, string tipo)
        {
            Expression<Func<Postulaciones, bool>>? condiciones = null;

            switch (tipo.ToUpper())
            {
                case "Especificaciones": condiciones = x => x.Especificaciones!.Contains(entidad.Especificaciones!); break;
                default: condiciones = x => x.Id == entidad.Id; break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }


        public Postulaciones Modificar(Postulaciones entidad)
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