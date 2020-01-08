using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models
{
    public class SeedData
    {
        private const string ADMIN_ROLE = "admin";
        public const string SECRETARY_ROLE = "secretaria";
        public const string CLEANING_ROLE = "limpeza";

        public static async Task PopulateAsync(GestaoTarefasIPGDbContext db)
        {
            PopulateEscolas(db);
            PopulateCargos(db);
            PopulateServicos(db);

        }

        private static void PopulateEscolas(GestaoTarefasIPGDbContext db)
        {
            if (db.Escola.Any()) return;

            db.Escola.AddRange(
                /*
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "1", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "2", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "3", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "4", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "5", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "7", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "8", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "9", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "10", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "11", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "12", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "13", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "14", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "7", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "8", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "9", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "10", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "11", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "12", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "13", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "14", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "6", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "1", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "1", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "1", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "1", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "1", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "1", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "1", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "1", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "1", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "1", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "1", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "1", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "1", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "1", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "1", Descricao = "Onde se faz" }
                */

                new Escola { Nome = "Escola Superior de Tecnologia e Gestão", Localizacao = "Guarda", Descricao = "Onde se faz" },
                new Escola { Nome = "Escola Superior de Educação, Comunicação e Desporto", Localizacao = "Guarda", Descricao = "Onde se aprende" },
                new Escola { Nome = "Escola Superior de Saúde", Localizacao = "Guarda", Descricao = "Onde se cura" },
                new Escola { Nome = "Escola Superior de Turismo e Hotelaria", Localizacao = "Seia", Descricao = "Onde se mistura" },
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
                new Escola { Nome = "Escola Superior de Turismo e Hotelaria", Localizacao = "Seia", Descricao = "Onde se mistura" }

            );
            db.SaveChanges();
        }

        public static async Task PopulateUsersAsync(UserManager<IdentityUser> userManager)
        {
            const string ADMIN_USERNAME = "admin@ipg.pt";
            const string ADMIN_PASSWORD = "Secret123$";

            IdentityUser user = await userManager.FindByNameAsync(ADMIN_USERNAME);
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = ADMIN_USERNAME,
                    Email = ADMIN_USERNAME
                };

                await userManager.CreateAsync(user, ADMIN_PASSWORD);
            }

            if (!await userManager.IsInRoleAsync(user, ADMIN_ROLE))
            {
                await userManager.AddToRoleAsync(user, ADMIN_ROLE);
            }

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
                new Cargo { NomeCargo = "Presidente" },
                new Cargo { NomeCargo = "Professor" },
                new Cargo { NomeCargo = "Funcionario Limpezas" },
                new Cargo { NomeCargo = "Segurança" },
                new Cargo { NomeCargo = "Funcionario Secretaria" }
            );

            db.SaveChanges();

        }
        public static async Task CreateRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            //const string CAN_ADD_MENUS = "can_add_menus";

            if (!await roleManager.RoleExistsAsync(ADMIN_ROLE))
            {
                await roleManager.CreateAsync(new IdentityRole(ADMIN_ROLE));
            }

            if (!await roleManager.RoleExistsAsync(SECRETARY_ROLE))
            {
                await roleManager.CreateAsync(new IdentityRole(SECRETARY_ROLE));
            }

            if (!await roleManager.RoleExistsAsync(CLEANING_ROLE))
            {
                await roleManager.CreateAsync(new IdentityRole(CLEANING_ROLE));
            }
        }
    }
}