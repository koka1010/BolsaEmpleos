﻿using lib_entidades.Modelos;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
namespace mst_pruebas.Repositorios
{
    [TestClass]
    public class VacantesPruebaUnitaria
    {
        private IVacantesRepositorio? iRepositorio = null;
        private Vacantes? entidad = null;

        public VacantesPruebaUnitaria()
        {
            var conexion = new Conexion();
            conexion.StringConnection = "server=DESKTOP-6DUCLD1\\DEV;database=db_Bolsa_empleos;Integrated Security=True;TrustServerCertificate=true;";
            /*"server=localhost;database=db_Bolsa_empleos;uid=sa;pwd=Clas3sPrO2024_!;TrustServerCertificate=true;";*/
            iRepositorio = new VacantesRepositorio(conexion);
        }

        [TestMethod]
        public void Ejecutar()
        {
            Guardar();
            Listar();
            Buscar();
            Modificar();
            Borrar();
        }

        private void Guardar()
        {
            entidad = new Vacantes()
            {
                Empresa = 1,
                Nombre_vacante = "desarrolotest"
            };
            entidad = iRepositorio!.Guardar(entidad);
            Assert.IsTrue(entidad.Id != 0);
        }

        private void Listar()
        {
            var lista = iRepositorio!.Listar();
            Assert.IsTrue(lista.Count > 0);
        }

        public void Buscar()
        {
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);
            Assert.IsTrue(lista.Count > 0);
        }

        private void Modificar()
        {
            entidad!.Nombre_vacante = "desarrolotest1";
            entidad = iRepositorio!.Modificar(entidad!);

            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);
            Assert.IsTrue(lista.Count > 0);
        }

        private void Borrar()
        {
            entidad = iRepositorio!.Borrar(entidad!);

            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);
            Assert.IsTrue(lista.Count == 0);
        }
    }
}