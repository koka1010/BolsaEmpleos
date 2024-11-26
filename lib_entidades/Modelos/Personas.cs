using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace lib_entidades.Modelos
{
    

    public partial class Personas
    {
        public Personas()
        {
            this.Detalles = new HashSet<Detalles>();
            this.Estudios = new HashSet<Estudios>();
        }

        [Key] public int Id { get; set; }
        public string? Cedula { get; set; }
        public string? Nombre_persona { get; set; }
        public string? Direccion { get; set; }
        public string? Cargos { get; set; }
        public string? Estado { get; set; }

      
        [NotMapped] public ICollection<Detalles> Detalles { get; set; }
        [NotMapped] public ICollection<Estudios> Estudios { get; set; }
        public bool Validar()
        {
            if (string.IsNullOrEmpty(Cedula) ||
                string.IsNullOrEmpty(Nombre_persona) ||
                string.IsNullOrEmpty(Direccion) ||
                string.IsNullOrEmpty(Cargos) ||
                string.IsNullOrEmpty(Estado) )
                return false;
            return true;
        }
    }
}