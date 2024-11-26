using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;
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
        public bool Validar()
        {
            if (string.IsNullOrEmpty(Especificaciones) ||
                Salario <=0 ||
                Vacante < 0)
                return false;
            return true;
        }
    }
}
