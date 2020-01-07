using System;
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
    public class ServicosController : Controller
    {
        private readonly GestaoTarefasIPGDbContext _context;

        private const int NUMBER_OF_PRODUCTS_PER_PAGE = 10;
        private const int NUMBER_OF_PAGES_BEFORE_AND_AFTER = 1;

        public ServicosController(GestaoTarefasIPGDbContext context)
        {
            _context = context;
        }

        // GET: Servicos
        public IActionResult Index(int page = 1, string sortOrder = null, string searchString = null, string searchOption = null)
        {
            decimal numberProducts = _context.Servico.Count();
            ServicosViewModel vm = new ServicosViewModel
            {
                Servicos = _context.Servico
                .Take(NUMBER_OF_PRODUCTS_PER_PAGE),
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(numberProducts / NUMBER_OF_PRODUCTS_PER_PAGE),
                FirstPageShow = Math.Max(1, page - NUMBER_OF_PAGES_BEFORE_AND_AFTER),
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
                        vm.Servicos = vm.Servicos.Where(p => p.Nome.Contains(searchString, StringComparison.CurrentCultureIgnoreCase));
                        vm.CurrentSearchOption = "Nome";
                        break;
                }
            }
            switch (sortOrder)
            {
                case "Nome":
                    vm.Servicos = vm.Servicos.OrderBy(p => p.Nome); // ascending by default
                    vm.CurrentSortOrder = "Nome";
                    break;
            }
            vm.TotalPages = (int)Math.Ceiling((decimal)vm.Servicos.Count() / NUMBER_OF_PRODUCTS_PER_PAGE);
            vm.Servicos = vm.Servicos.Skip((page - 1) * NUMBER_OF_PRODUCTS_PER_PAGE);
            vm.Servicos = vm.Servicos.Take(NUMBER_OF_PRODUCTS_PER_PAGE);
            vm.LastPageShow = Math.Min(vm.TotalPages, page + NUMBER_OF_PAGES_BEFORE_AND_AFTER);
            vm.FirstPage = 1;
            vm.LastPage = vm.TotalPages;
            return View(vm);
        }

        // GET: Servicos/Details/5
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servico = await _context.Servico
                .FirstOrDefaultAsync(m => m.ServicoId == id);
            if (servico == null)
            {
                return NotFound();
            }

            return View(servico);
        }

        // GET: Servicos/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Servicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServicoId,Nome")] Servico servico)
        {
            if (ModelState.IsValid)
            {
                // se isto for null é porque não encontrou nenhum registo na tabela Escola com o mesmo Nome
                if (_context.Servico.FirstOrDefault(m => m.Nome == servico.Nome) == null)
                {
                    _context.Add(servico);
                    await _context.SaveChangesAsync();
                    return View("Sucesso");
                }
                else
                {
                    // aparece a mensagem de erro em baixo do input do Nome
                    ModelState.AddModelError("Nome", "Não é possível adicionar nomes repetidos.");
                    return View(servico);
                }
            }
            else
            {
                return View("Erro");
            }
        }

        // GET: Servicos/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servico = await _context.Servico.FindAsync(id);
            if (servico == null)
            {
                return NotFound();
            }
            return View(servico);
        }

        // POST: Servicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServicoId,Nome")] Servico servico)
        {
            if (id != servico.ServicoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // se isto for null é porque não encontrou nenhum registo na tabela Escola com o mesmo Nome
                    if (_context.Servico.FirstOrDefault(m => m.Nome == servico.Nome) == null)
                    {
                        _context.Update(servico);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        // aparece a mensagem de erro em baixo do input do Nome
                        ModelState.AddModelError("Nome", "Não é possível adicionar nomes repetidos.");
                        return View(servico);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicoExists(servico.ServicoId))
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

        // GET: Servicos/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servico = await _context.Servico
                .FirstOrDefaultAsync(m => m.ServicoId == id);
            if (servico == null)
            {
                return NotFound();
            }

            return View(servico);
        }

        // POST: Servicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servico = await _context.Servico.FindAsync(id);
            _context.Servico.Remove(servico);
            await _context.SaveChangesAsync();
            return View("Sucesso");
        }

        private bool ServicoExists(int id)
        {
            return _context.Servico.Any(e => e.ServicoId == id);
        }
    }
}
