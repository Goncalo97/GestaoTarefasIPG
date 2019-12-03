using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models
{
    public class EFGestaoTarefasIPGRepository : IGestaoTarefasIPGRepository
    {
        private Data.ApplicationDbContext db;
        public EFGestaoTarefasIPGRepository(Data.ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Escola> Escolas => db.Escola;
    }
}
