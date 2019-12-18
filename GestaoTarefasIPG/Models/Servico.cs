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
        [StringLength(200)]
        [Display(Name = "Nome:")]
        public string Nome { get; set; }
    }
}