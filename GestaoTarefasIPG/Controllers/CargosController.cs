﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoTarefasIPG.Models;
using Microsoft.AspNetCore.Authorization;

namespace GestaoTarefasIPG.Controllers
{
    public class CargosController : Controller
    {
        private readonly GestaoTarefasIPGDbContext _context;


        private const int NUMBER_OF_PRODUCTS_PER_PAGE = 10;
        private const int NUMBER_OF_PAGES_BEFORE_AND_AFTER = 1;

        public CargosController(GestaoTarefasIPGDbContext context)
        {
            _context = context;
        }

        // GET: Cargos
        
        public async Task<IActionResult> Index(int page = 1, string sortOrder = null, string searchString = null, string searchOption = null)
        {
            decimal numberProducts = _context.Cargo.Count();
            CargosViewModel vm = new CargosViewModel
            {
                Cargos = _context.Cargo
                .Take((int)numberProducts),
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(numberProducts / NUMBER_OF_PRODUCTS_PER_PAGE),
                FirstPageShow = Math.Max(2, page - NUMBER_OF_PAGES_BEFORE_AND_AFTER),
            };
            var searchOptionList = new List<string>();
            searchOptionList.Add("Nome");

            ViewBag.searchOption = new SelectList(searchOptionList);

            if (!String.IsNullOrEmpty(searchString) && !String.IsNullOrEmpty(searchOption))
            {
                vm.CurrentSearchString = searchString;
                switch (searchOption)
                {
                    case "Nome":
                        vm.Cargos = vm.Cargos.Where(p => p.NomeCargo.Contains(searchString, StringComparison.CurrentCultureIgnoreCase));
                        vm.CurrentSearchOption = "Nome";
                        break;
                }
            }

                        switch (sortOrder)
            {
                case "Nome":
                    vm.Cargos = vm.Cargos.OrderBy(p => p.NomeCargo); // ascending by default
                    vm.CurrentSortOrder = "Nome";
                    break;
              
            }
            vm.Cargos = vm.Cargos.Skip((page - 1) * NUMBER_OF_PRODUCTS_PER_PAGE);
            vm.Cargos = vm.Cargos.Take(NUMBER_OF_PRODUCTS_PER_PAGE);
            vm.LastPageShow = Math.Min(vm.TotalPages, page + NUMBER_OF_PAGES_BEFORE_AND_AFTER);
            vm.FirstPage = 1;
            vm.LastPage = vm.TotalPages;
            return View(vm);
        }

        // GET: Cargos/Details/5
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargo = await _context.Cargo
                .FirstOrDefaultAsync(m => m.CargoID == id);
            if (cargo == null)
            {
                return NotFound();
            }

            return View(cargo);
        }

        // GET: Cargos/Create
        [Authorize(Roles ="admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cargos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([Bind("CargoID,NomeCargo,NivelCargo")] Cargo cargo)
        {
            
            if (ModelState.IsValid)
            {
                // se isto for null é porque não encontrou nenhum registo na tabela Escola com o mesmo Nome
                if (_context.Cargo.FirstOrDefault(m => m.NomeCargo == cargo.NomeCargo) == null)
                {
                    _context.Add(cargo);
                    await _context.SaveChangesAsync();
                    return View("Sucesso");
                }
                else
                {
                    // aparece a mensagem de erro em baixo do input do Nome
                    ModelState.AddModelError("NomeCargo", "Não é possível adicionar nomes repetidos.");
                    return View(cargo);
                }
            }
            else
            {
                return View("Erro");
            }
        }

        // GET: Cargos/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargo = await _context.Cargo.FindAsync(id);
            if (cargo == null)
            {
                return NotFound();
            }
            return View(cargo);
        }

        // POST: Cargos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int id, [Bind("CargoID,NomeCargo,NivelCargo")] Cargo cargo)
        {
            if (id != cargo.CargoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // se isto for null é porque não encontrou nenhum registo na tabela Escola com o mesmo Nome
                    if (_context.Cargo.FirstOrDefault(m => m.NomeCargo == cargo.NomeCargo) == null)
                    {
                        _context.Update(cargo);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        // aparece a mensagem de erro em baixo do input do Nome
                        ModelState.AddModelError("NomeCargo", "Não é possível adicionar nomes repetidos.");
                        return View(cargo);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CargoExists(cargo.CargoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return View("Sucesso");
            }
            else
            {
                return View("Erro");
            }
            
        }

        // GET: Cargos/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargo = await _context.Cargo
                .FirstOrDefaultAsync(m => m.CargoID == id);
            if (cargo == null)
            {
                return NotFound();
            }

            return View(cargo);
        }

        // POST: Cargos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cargo = await _context.Cargo.FindAsync(id);
            _context.Cargo.Remove(cargo);
            await _context.SaveChangesAsync();
            return View("Sucesso");
        }

        private bool CargoExists(int id)
        {
            return _context.Cargo.Any(e => e.CargoID == id);
        }
    }
}
