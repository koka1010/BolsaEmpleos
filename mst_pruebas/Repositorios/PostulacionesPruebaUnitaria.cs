using lib_entidades.Modelos;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
namespace mst_pruebas.Repositorios
{
    [TestClass]
    public class PostulacionesPruebaUnitaria
    {
        private IPostulacionesRepositorio? iRepositorio = null;
        private Postulaciones? entidad = null;

        public PostulacionesPruebaUnitaria()
        {
            var conexion = new Conexion();
            conexion.StringConnection = "server=DESKTOP-6DUCLD1\\DEV;database=db_Bolsa_empleos;Integrated Security=True;TrustServerCertificate=true;";
            /*"server=localhost;database=db_Bolsa_empleos;uid=sa;pwd=Clas3sPrO2024_!;TrustServerCertificate=true;";*/
            iRepositorio = new PostulacionesRepositorio(conexion);
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
            entidad = new Postulaciones()
            {
                Vacante = 1,
                Especificaciones = "sepatesting",
                Salario = 100
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
            entidad!.Especificaciones = "test";
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