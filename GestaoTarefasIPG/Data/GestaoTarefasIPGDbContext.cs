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

        public DbSet<GestaoTarefasIPG.Models.Cargo> Cargo { get; set; }

        public DbSet<GestaoTarefasIPG.Models.Servico> Servico { get; set; }

        public DbSet<GestaoTarefasIPG.Models.Funcionario> Funcionario { get; set; }

        public DbSet<GestaoTarefasIPG.Models.Departamento> Departamento { get; set; }

        public DbSet<GestaoTarefasIPG.Models.Professor> Professor { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Relation 1 -> N
        modelBuilder.Entity<Funcionario>()
            .HasOne(mm => mm.Escola)
            .WithMany(m => m.Funcionarios)
            .HasForeignKey(mm => mm.EscolaId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relation 1 -> N
        modelBuilder.Entity<Departamento>()
            .HasOne(mm => mm.Escola)
            .WithMany(m => m.Departamentos)
            .HasForeignKey(mm => mm.EscolaId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relation 1 -> N
        modelBuilder.Entity<Professor>()
            .HasOne(mm => mm.Departamento)
            .WithMany(m => m.Professores)
            .HasForeignKey(mm => mm.DepartamentoID)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
}

        
    
