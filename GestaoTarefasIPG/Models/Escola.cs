using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models
{
    public class Escola
    {
        public int EscolaID { get; set; }

        [Required]
        [StringLength(248)]
        [Display(Name = "Nome:")]
        public String Nome { get; set; }

        [Required]
        [Display(Name = "Localização:")]
        public String Localizacao { get; set; }

        [Display(Name = "Descrição:")]
        public String Descricao { get; set; }
    }
}