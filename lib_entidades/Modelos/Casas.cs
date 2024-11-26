using System.ComponentModel.DataAnnotations;

namespace lib_entidades.Modelos
{
    public class Casas
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public DateTime? Fecha { get; set; }
        public bool Activa { get; set; }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Nombre) ||
                string.IsNullOrEmpty(Direccion) ||
                string.IsNullOrEmpty(Telefono) ||
                Fecha == null)
                return false;
            return true;
        }
    }
}
