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
        [StringLength(80)]
        [Display(Name = "Nome:")]
        public String Nome { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Sigla:")]
        public String Sigla { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "Localização:")]
        public String Localizacao { get; set; }

        [StringLength(100)]
        [Display(Name = "Descrição:")]
        public String Descricao { get; set; }
    }
}