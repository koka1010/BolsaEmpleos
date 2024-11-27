﻿using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class LoginRepositorio : ILoginRepositorio
    {
        private Conexion? conexion = null;
        private IAuditoriaRepositorio? iAuditoriaRepositorio;

        public LoginRepositorio(Conexion conexion,
             IAuditoriaRepositorio iAuditoriaRepositorio)
        {
            
            this.conexion = conexion;
            this.iAuditoriaRepositorio= iAuditoriaRepositorio;
        }

        public List<Login> Listar()
        {
            iAuditoriaRepositorio!.Guardar(new Auditoria
            {
                Tabla= "Login",
                Referencia=0,
                Accion= "Listar"

            });
            return Buscar(x => x != null);
        }

        public List<Login> Buscar(Expression<Func<Login, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Login Guardar(Login entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            iAuditoriaRepositorio!.Guardar(new Auditoria
            {
                Tabla = "Login",
                Referencia = entidad.Id,
                Accion = "Guardar"

            });
            return entidad;
        }

        public Login Modificar(Login entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            iAuditoriaRepositorio!.Guardar(new Auditoria
            {
                Tabla = "Login",
                Referencia = entidad.Id,
                Accion = "Modificar"

            });
            return entidad;
        }

        public Login Borrar(Login entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            iAuditoriaRepositorio!.Guardar(new Auditoria
            {
                Tabla = "Login",
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