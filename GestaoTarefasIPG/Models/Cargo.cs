
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models
{
    public class Cargo
    {
        public int CargoID { get; set; }
        [Required(ErrorMessage = "Por favor, insira um nome")]
        public string NomeCargo { get; set; }
        [Required(ErrorMessage = "Por favor, insira um nivel para o cargo")]
        [RegularExpression(@"([1-4])", ErrorMessage = "Por favor insira um nivel válido")]
        public string NivelCargo { get; set; }
    }
}