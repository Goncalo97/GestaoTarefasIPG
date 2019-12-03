using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GestaoTarefasIPG.Models;

    public class GestaoTarefasIPGDbContext : DbContext
    {
        public GestaoTarefasIPGDbContext (DbContextOptions<GestaoTarefasIPGDbContext> options)
            : base(options)
        {
        }

        public DbSet<GestaoTarefasIPG.Models.Escola> Escola { get; set; }
    }
