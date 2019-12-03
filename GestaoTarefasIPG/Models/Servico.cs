using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models
{
    public class Servico
    {
        public int ServicoId { get; set; }
        [Required(ErrorMessage = "Por favor insira um nome")]
        [RegularExpression(@"([a-z A-z]+)", ErrorMessage = "Por favor insira um no")]
        public string Nome { get; set; }
    }
}