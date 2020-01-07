
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models
{
    public class Cargo
    {
        public int CargoID { get; set; }
        [Required(ErrorMessage = "Por favor, insira um nome")]
        [StringLength(248)]
        [Display(Name ="Nome:")]
        public string NomeCargo { get; set; }
        [Required]
        public string role { get; set; }

    }
}