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
        private const int NUMBER_PRODUCTS_PER_PAGE = 4;
        private const int NUMBER_PAGES_BEFORE_AND_AFTER = 5;

        private IGestaoTarefasIPGRepository repository;
        public EscolasController(IGestaoTarefasIPGRepository repository)
        {
            this.repository = repository;
        }

        

        public EscolasController(GestaoTarefasIPGDbContext context)
        {
            _context = context;
        }

        // GET: Escolas
        /*
         * public async Task<IActionResult> Index()
        {
            return View(await _context.Escola.ToListAsync());
        }
        */
        public IActionResult Index()
        {
            int page = 1;
            decimal numberProducts = repository.Escola.Count();
            EscolasViewModel vm = new EscolasViewModel // create a view with this 
            {
                Escolas = repository.Escola
                .OrderBy(p => p.Nome)
                .Skip((page - 1) * NUMBER_PRODUCTS_PER_PAGE)
                .Take(NUMBER_PRODUCTS_PER_PAGE),
                CurrentPage = page,
                //TotalPages = 500,
                TotalPages = (int)Math.Ceiling(numberProducts / NUMBER_PRODUCTS_PER_PAGE), // higher integer
                FirstPageShow = Math.Max(1, page - NUMBER_PAGES_BEFORE_AND_AFTER), // i'm on page 2 then i subtract 5 ... 2 - 3 = -3  .. 8 - 5 = 3 ..  .. first page to show is never below one (1)
                // LastPageShow = Math.Min(1, page - NUMBER_PAGES_BEFORE_AND_AFTER) // cannot access TotalPages here
                // TotalPages = (int)Math.Ceiling(numberProducts / NUMBER_PRODUCTS_PER_PAGE) // higher integer
            };  // 3 / 4 .. 4
            // if ()
            vm.LastPageShow = Math.Min(vm.TotalPages, page + NUMBER_PAGES_BEFORE_AND_AFTER);
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
