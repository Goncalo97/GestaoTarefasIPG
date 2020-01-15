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
        public string Nome { get; set; }

        //public Escola EscolaIdForeignKey { get; set; }

        public Escola Escola { get; set; }
        public int EscolaId { get; set; }
    }
}
