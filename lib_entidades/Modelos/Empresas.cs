using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace lib_entidades.Modelos
{


    public partial class Empresas
    {
        public Empresas()
        {
            this.Vacantes = new HashSet<Vacantes>();
        }

        [Key]public int Id { get; set; }
        public int Cod_Empresa{get; set;}
        public string? Nom_Empresa { get; set; }
        public string? Direc_Empresa { get; set; }
        [NotMapped] public ICollection<Vacantes> Vacantes { get; set; }
        public void NotificarPersona()
        {

        }
        public bool Validar()
        {
            if (string.IsNullOrEmpty(Nom_Empresa) ||
                string.IsNullOrEmpty(Direc_Empresa) ||
                Cod_Empresa <= 0)
                return false;
            return true;
        }
    }
   
}
