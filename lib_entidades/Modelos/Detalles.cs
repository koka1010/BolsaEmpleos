using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    }

 
}