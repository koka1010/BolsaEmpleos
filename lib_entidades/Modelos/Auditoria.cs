using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace lib_entidades.Modelos
{


    public partial class Auditoria
    {
       
        [Key]public int Id { get; set; }
        
        public string? Tabla { get; set; }
        public int Referencia { get; set; }
        public string? Accion { get; set; }
        
    }
   
}
