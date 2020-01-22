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
        public string Nome { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email:")]
        public string Email { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Telemovel:")]
        public string Telemovel { get; set; }

        public Escola Escola { get; set; }
        public int EscolaId { get; set; }
    }
}
