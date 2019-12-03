using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models
{
    public class EFGestaoTarefasIPGRepository : IGestaoTarefasIPGRepository
    {
        private GestaoTarefasIPGDbContext db;
        public EFGestaoTarefasIPGRepository(GestaoTarefasIPGDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Escola> Escolas => db.Escola;
    }
}
