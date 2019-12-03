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
        public String Nome { get; set; }

        [Required]
        public String Localizacao { get; set; }

        public String Descricao { get; set; }
    }
}