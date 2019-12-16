using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoTarefasIPG.Models;

namespace GestaoTarefasIPG.Controllers
{
    public class EscolasController : Controller
    {
        private readonly GestaoTarefasIPGDbContext _context;

        private const int NUMBER_OF_PRODUCTS_PER_PAGE = 10;
        private const int NUMBER_OF_PAGES_BEFORE_AND_AFTER = 1;
          
        public EscolasController(GestaoTarefasIPGDbContext context)
        {
            _context = context;
        }

        // GET: Escolas
        public IActionResult Index(int page = 1, string sortOrder = null)
        {
            decimal numberProducts = _context.Escola.Count();
            EscolasViewModel vm = new EscolasViewModel 
            {
                Escolas = _context.Escola
                .Take((int)numberProducts),
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(numberProducts / NUMBER_OF_PRODUCTS_PER_PAGE),
                FirstPageShow = Math.Max(2, page - NUMBER_OF_PAGES_BEFORE_AND_AFTER),      
            };
            switch (sortOrder)
            {
                case "Nome":
                    vm.Escolas = vm.Escolas.OrderBy(p => p.Nome); // ascending by default
                    vm.CurrentSortOrder = "Nome";
                    break;
                case "Localizacao":
                    vm.Escolas = vm.Escolas.OrderBy(p => p.Localizacao);
                    vm.CurrentSortOrder = "Localizacao";
                    break;
                case "Descricao":
                    vm.Escolas = vm.Escolas.OrderBy(p => p.Descricao);
                    vm.CurrentSortOrder = "Descricao";
                    break;
            }
            vm.Escolas = vm.Escolas.Skip((page - 1) * NUMBER_OF_PRODUCTS_PER_PAGE);
            vm.Escolas = vm.Escolas.Take(NUMBER_OF_PRODUCTS_PER_PAGE);
            vm.LastPageShow = Math.Min(vm.TotalPages, page + NUMBER_OF_PAGES_BEFORE_AND_AFTER);
            vm.FirstPage = 1;
            vm.LastPage = vm.TotalPages;
            return View(vm);
        }

        // GET: Escolas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escola = await _context.Escola
                .FirstOrDefaultAsync(m => m.EscolaID == id);
            if (escola == null)
            {
                return NotFound();
            }

            return View(escola);
        }

        // GET: Escolas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Escolas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EscolaID,Nome,Localizacao,Descricao")] Escola escola)
        {
            if (ModelState.IsValid)
            {
                _context.Add(escola);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(escola);
        }

        // GET: Escolas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escola = await _context.Escola.FindAsync(id);
            if (escola == null)
            {
                return NotFound();
            }
            return View(escola);
        }

        // POST: Escolas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EscolaID,Nome,Localizacao,Descricao")] Escola escola)
        {
            if (id != escola.EscolaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(escola);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EscolaExists(escola.EscolaID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(escola);
        }

        // GET: Escolas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escola = await _context.Escola
                .FirstOrDefaultAsync(m => m.EscolaID == id);
            if (escola == null)
            {
                return NotFound();
            }

            return View(escola);
        }

        // POST: Escolas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var escola = await _context.Escola.FindAsync(id);
            _context.Escola.Remove(escola);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EscolaExists(int id)
        {
            return _context.Escola.Any(e => e.EscolaID == id);
        }
    }
}
