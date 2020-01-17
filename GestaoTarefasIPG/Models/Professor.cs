using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models
{
    public class Professor
    {
        public int ProfessorID { get; set; }
        [Required(ErrorMessage = "Por favor, insira um nome")]
        [StringLength(60)]
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
        [Required]
        [StringLength(80)]
        public String Morada { get; set; }
        public Departamento Departamento { get; set; }
        public int DepartamentoID { get; set; }
    }
}
