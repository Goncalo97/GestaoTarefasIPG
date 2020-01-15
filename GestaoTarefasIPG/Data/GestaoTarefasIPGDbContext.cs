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


    /*
        protected override void OnModelCreating(Modelbuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Company);
            .WithMany(c => c.Employees)

            base.OnModelCreating(modelBuilder);

    }
    */
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Chave composta especialidademedicoId + medicoId
       // modelBuilder.Entity<Departamento>().HasKey(o => new { o.DepartamentoId, o.Nome, o.EscolaIdForeignKey });

        //Relação 1 -> N
        modelBuilder.Entity<Departamento>()
            .HasOne(mm => mm.Escola)
            .WithMany(m => m.Departamentos)
            .HasForeignKey(mm => mm.EscolaId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
}

        
    
