using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace lib_entidades.Modelos
{
    

    public partial class Postulaciones
    {
        public Postulaciones()
        {
            this.Detalles = new HashSet<Detalles>();
        }

        [Key] public int Id { get; set; }
        public int Vacante { get; set; }
        public string? Especificaciones { get; set; }
        public int Salario { get; set; }

        
        [ForeignKey("Vacante")] public Vacantes? _Vacante { get; set; }

        [NotMapped] public ICollection<Detalles> Detalles { get; set; }
    }
}
