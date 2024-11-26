using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace lib_entidades.Modelos
{
   

    public partial class Vacantes
    {
        public Vacantes()
        {
            this.Postulaciones = new HashSet<Postulaciones>();
        }

        [Key] public int Id { get; set; }
        public int? Empresa { get; set; }
        public string? Nombre_vacante { get; set; }

        [ForeignKey("Empresa")] public Empresas? _Empresa { get; set; }
        

        [NotMapped] public ICollection<Postulaciones> Postulaciones { get; set; }
        public void ValidarCantidad()
        {

        }

    }
   
}
