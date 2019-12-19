using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models
{
    public class UserAccount
    {
        public int UserID { get; set; }
        [Required(ErrorMessage = "Por favor, insira o seu nome")]
        [StringLength(25)]
        [Display(Name = "Nome:")]
        public string PrimeiroNome { get; set; }
        [Required(ErrorMessage = "Por favor, insira o seu apelido")]
        [StringLength(25)]
        [Display(Name = "Sobrenome:")]
        public string UltimoNome { get; set; }
        [EmailAddress(ErrorMessage = "Por favor insira um email válido.")]
        [StringLength(200)]
        [Display(Name = "Email:")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Insira uma palavra-chave.")]
        [DataType(DataType.Password)]  
        public string Password { get; set; }
    }
}
