﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models
{
    public class FuncionariosViewModel
    {
        public IEnumerable<Funcionario> Funcionarios { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int FirstPageShow { get; set; }
        public int LastPageShow { get; set; }
        public int FirstPage { get; set; }
        public int LastPage { get; set; }
        public string CurrentSortOrder { get; set; }
        public string CurrentSearchOption { get; set; }
        public string CurrentSearchString { get; set; }
    }
}
