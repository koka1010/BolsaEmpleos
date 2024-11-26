using lib_entidades.Modelos;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
namespace mst_pruebas.Repositorios
{
    [TestClass]
    public class DetallesPruebaUnitaria
    {
        private IDetallesRepositorio? iRepositorio = null;
        private Detalles? entidad = null;

        public DetallesPruebaUnitaria()
        {
            var conexion = new Conexion();
            conexion.StringConnection = "server=DESKTOP-6DUCLD1\\DEV;database=db_Bolsa_empleos;Integrated Security=True;TrustServerCertificate=true;";
            /*"server=localhost;database=db_Bolsa_empleos;uid=sa;pwd=Clas3sPrO2024_!;TrustServerCertificate=true;";*/
            iRepositorio = new DetallesRepositorio(conexion);
        }

        [TestMethod]
        public void Ejecutar()
        {
            Guardar();
            Listar();
            Buscar();
            //Modificar();
            Borrar();
        }

        private void Guardar()
        {
            entidad = new Detalles()
            {
                Postulacion = 1,
                Persona = 1
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
            //entidad!.Nombre = "Test";
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