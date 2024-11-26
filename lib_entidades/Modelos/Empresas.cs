using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
    }
   
}
