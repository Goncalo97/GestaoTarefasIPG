using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models
{
    public class Funcionario
    {
        public int FuncionarioID { get; set; }
        [Required(ErrorMessage = "Por favor, insira um nome")]
        [StringLength(248)]
        [Display(Name = "Nome:")]
        public string nome { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email:")]
        public string email { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Telemovel:")]
        public string telemovel { get; set; }
    }
}
