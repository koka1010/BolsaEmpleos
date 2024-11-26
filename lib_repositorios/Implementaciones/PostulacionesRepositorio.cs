﻿using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class PostulacionesRepositorio : IPostulacionesRepositorio
    {
        private Conexion? conexion = null;

        public PostulacionesRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public List<Postulaciones> Listar()
        {
            return conexion!.Listar<Postulaciones>();
        }

        public List<Postulaciones> Buscar(Expression<Func<Postulaciones, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Postulaciones Guardar(Postulaciones entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Postulaciones Modificar(Postulaciones entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Postulaciones Borrar(Postulaciones entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }
        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }
    }
}