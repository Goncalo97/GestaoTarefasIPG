using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models
{
    public class Departamento
    {
        public int DepartamentoId { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "Nome:")]
        public string Nome { get; set; }

        [Display(Name = "Escola:")]
        public Escola Escola { get; set; }

        [Display(Name = "Escola:")]
        public int EscolaId { get; set; }

        public ICollection<Professor> Professores { get; set; }
    }
}
