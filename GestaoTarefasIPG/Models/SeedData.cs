using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models
{
    public class SeedData
    {

        public static void Populate(GestaoTarefasIPGDbContext db)
        {
            PopulateEscolas(db);
            PopulateCargos(db);
            PopulateServicos(db);
        }

        private static void PopulateEscolas(GestaoTarefasIPGDbContext db)
        {
            if (db.Escola.Any()) return;

            db.Escola.AddRange(
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "Guarda", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Educação, Comunicação e Desporto", Localizacao = "Guarda", Descricao = "Onde se aprende" },
                new Escola { Nome = "Escola Superior de Saúde", Localizacao = "Guarda", Descricao = "Onde se cura" },
                new Escola { Nome = "Escola Superior de Turismo e Hotelaria", Localizacao = "Seia", Descricao = "Onde se mistura" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "Guarda", Descricao = "Onde se aprende" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "Guarda", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Educação, Comunicação e Desporto", Localizacao = "Guarda", Descricao = "Onde se aprende" },
                new Escola { Nome = "Escola Superior de Saúde", Localizacao = "Guarda", Descricao = "Onde se cura" },
                new Escola { Nome = "Escola Superior de Turismo e Hotelaria", Localizacao = "Seia", Descricao = "Onde se mistura" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "Guarda", Descricao = "Onde se aprende" },
                new Escola { Nome = "Escola Superior de Educação, Comunicação e Desporto", Localizacao = "Guarda", Descricao = "Onde se aprende" },
                new Escola { Nome = "Escola Superior de Saúde", Localizacao = "Guarda", Descricao = "Onde se cura" },
                new Escola { Nome = "Escola Superior de Turismo e Hotelaria", Localizacao = "Seia", Descricao = "Onde se mistura" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "Guarda", Descricao = "Onde se aprende" },
                new Escola { Nome = "Escola Superior de Educação, Comunicação e Desporto", Localizacao = "Guarda", Descricao = "Onde se aprende" },
                new Escola { Nome = "Escola Superior de Saúde", Localizacao = "Guarda", Descricao = "Onde se cura" },
                new Escola { Nome = "Escola Superior de Turismo e Hotelaria", Localizacao = "Seia", Descricao = "Onde se mistura" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "Guarda", Descricao = "Onde se aprende" },
                new Escola { Nome = "Escola Superior de Educação, Comunicação e Desporto", Localizacao = "Guarda", Descricao = "Onde se aprende" },
                new Escola { Nome = "Escola Superior de Saúde", Localizacao = "Guarda", Descricao = "Onde se cura" },
                new Escola { Nome = "Escola Superior de Turismo e Hotelaria", Localizacao = "Seia", Descricao = "Onde se mistura" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "Guarda", Descricao = "Onde se aprende" },
                new Escola { Nome = "Escola Superior de Educação, Comunicação e Desporto", Localizacao = "Guarda", Descricao = "Onde se aprende" },
                new Escola { Nome = "Escola Superior de Saúde", Localizacao = "Guarda", Descricao = "Onde se cura" },
                new Escola { Nome = "Escola Superior de Turismo e Hotelaria", Localizacao = "Seia", Descricao = "Onde se mistura" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "Guarda", Descricao = "Onde se aprende" },
                new Escola { Nome = "Escola Superior de Educação, Comunicação e Desporto", Localizacao = "Guarda", Descricao = "Onde se aprende" },
                new Escola { Nome = "Escola Superior de Saúde", Localizacao = "Guarda", Descricao = "Onde se cura" },
                new Escola { Nome = "Escola Superior de Turismo e Hotelaria", Localizacao = "Seia", Descricao = "Onde se mistura" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "Guarda", Descricao = "Onde se aprende" },
                new Escola { Nome = "Escola Superior de Educação, Comunicação e Desporto", Localizacao = "Guarda", Descricao = "Onde se aprende" },
                new Escola { Nome = "Escola Superior de Saúde", Localizacao = "Guarda", Descricao = "Onde se cura" },
                new Escola { Nome = "Escola Superior de Turismo e Hotelaria", Localizacao = "Seia", Descricao = "Onde se mistura" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "Guarda", Descricao = "Onde se aprende" },
                new Escola { Nome = "Escola Superior de Educação, Comunicação e Desporto", Localizacao = "Guarda", Descricao = "Onde se aprende" },
                new Escola { Nome = "Escola Superior de Saúde", Localizacao = "Guarda", Descricao = "Onde se cura" },
                new Escola { Nome = "Escola Superior de Turismo e Hotelaria", Localizacao = "Seia", Descricao = "Onde se mistura" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "Guarda", Descricao = "Onde se aprende" },
                new Escola { Nome = "Escola Superior de Educação, Comunicação e Desporto", Localizacao = "Guarda", Descricao = "Onde se aprende" },
                new Escola { Nome = "Escola Superior de Saúde", Localizacao = "Guarda", Descricao = "Onde se cura" },
                new Escola { Nome = "Escola Superior de Turismo e Hotelaria", Localizacao = "Seia", Descricao = "Onde se mistura" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "Guarda", Descricao = "Onde se aprende" }
            );
            db.SaveChanges();
        }
        private static void PopulateServicos(GestaoTarefasIPGDbContext db)
        {
            if (db.Servico.Any()) return;
            db.Servico.AddRange(
                new Servico { Nome = "Calcular o número de alunos no curso de engenharia informática" },
                new Servico { Nome = "Calcular o número de alunos que frequenta a aula de programação para a internet" },
                new Servico { Nome = "Vigiar o teste de Análise Matemática" }
            );
            db.SaveChanges();
        }
        private static void PopulateCargos(GestaoTarefasIPGDbContext db)
        {
            if (db.Cargo.Any()) return;

            db.Cargo.AddRange(
                new Cargo { NomeCargo = "Presidente", NivelCargo = "4" },
                new Cargo { NomeCargo = "Professor", NivelCargo = "2" },
                new Cargo { NomeCargo = "Funcionario Limpezas", NivelCargo = "1" },
                new Cargo { NomeCargo = "Segurança", NivelCargo = "1" },
                new Cargo { NomeCargo = "Funcionario Secretaria", NivelCargo = "2" }
            );

            db.SaveChanges();

        }
    }
}