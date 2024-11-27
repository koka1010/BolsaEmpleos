using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace lib_entidades.Modelos
{


    public partial class Login
    {
       
        [Key]public int Id { get; set; }
        
        public string? Nombre { get; set; }
      
        public string? Contraseña { get; set; }
        public string? Rol { get; set; }
        public bool Validar()
        {
            if (string.IsNullOrEmpty(Nombre) ||
                string.IsNullOrEmpty(Contraseña) ||
                string.IsNullOrEmpty(Rol))
                return false;
            return true;
        }

    }
   
}
