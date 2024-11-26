using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lib_entidades.Modelos
{
    public partial class Detalles
    {
        [Key] public int Id { get; set; }
        public int Postulacion { get; set; }
        public int Persona { get; set; }

        [ForeignKey("Postulacion")] public Postulaciones? _Postulacion { get; set; }
        [ForeignKey("Persona")] public Personas? _Persona { get; set; }
        public void GuardarDatos()
        {

        }
        public void ValidacionEstudios()
        {

        }
        public bool Validar()
        {
            if (Postulacion < 0 ||
                Persona < 0)
                return false;
            return true;
        }

    }

 
}