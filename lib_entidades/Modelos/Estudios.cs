using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace lib_entidades.Modelos
{
    

    public partial class Estudios
    {
    
        [Key] public int Id { get; set; }
        public string? Cod_estudio { get; set; }
        public int Persona { get; set; }
        public string? Nombre_estudio { get; set; }
       
        

        [ForeignKey("Persona")] public Personas? _Persona { get; set; }
       
    }
}
