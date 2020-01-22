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
    public class DepartamentosController : Controller
    {
        private readonly GestaoTarefasIPGDbContext _context;

        private const int NUMBER_OF_PRODUCTS_PER_PAGE = 10;
        private const int NUMBER_OF_PAGES_BEFORE_AND_AFTER = 1;

        public DepartamentosController(GestaoTarefasIPGDbContext context)
        {
            _context = context;
        }

        // GET: Departamentos
        public IActionResult Index(int page = 1, string sortOrder = "Nome", string searchString = null, string searchOption = null)
        {
            decimal numberProducts = _context.Departamento.Count();
            var _contextDepartamento = _context.Departamento.Include(d => d.Escola);
            
            DepartamentosViewModel vm = new DepartamentosViewModel
            {
                Departamentos = _contextDepartamento
                .Take((int)numberProducts),
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(numberProducts / NUMBER_OF_PRODUCTS_PER_PAGE),
                FirstPageShow = Math.Max(2, page - NUMBER_OF_PAGES_BEFORE_AND_AFTER),
            };
            var searchOptionList = new List<string>();

            searchOptionList.Add("Nome");
            searchOptionList.Add("Escola");

            ViewBag.searchOption = new SelectList(searchOptionList);

            if (!String.IsNullOrEmpty(searchString) && !String.IsNullOrEmpty(searchOption))
            {
                vm.CurrentSearchString = searchString;
                switch (searchOption)
                {
                    case "Nome":
                        vm.Departamentos = vm.Departamentos.Where(p => p.Nome.Contains(searchString, StringComparison.CurrentCultureIgnoreCase));
                        vm.CurrentSearchOption = "Nome";
                        break;
                    case "Escola":
                        vm.Departamentos = vm.Departamentos.Where(p => p.Escola.Nome.Contains(searchString, StringComparison.CurrentCultureIgnoreCase));
                        vm.CurrentSearchOption = "Escola";
                        break;
                }
            }
            ViewBag.NomeSortParm = sortOrder == "Nome" ? "Nome_Desc" : "Nome";
            ViewBag.Nome_EscolaSortParm = sortOrder == "Nome_Escola" ? "Nome_Escola_Desc" : "Nome_Escola";         
            switch (sortOrder)
            {
                case "Nome_Desc":
                    vm.Departamentos = vm.Departamentos.OrderByDescending(p => p.Nome);
                    vm.CurrentSortOrder = "Nome_Desc";
                    break;
                case "Nome_Escola":
                    vm.Departamentos = vm.Departamentos.OrderBy(p => p.Escola.Nome);
                    vm.CurrentSortOrder = "Nome_Escola";
                    break;
                case "Nome_Escola_Desc":
                    vm.Departamentos = vm.Departamentos.OrderByDescending(p => p.Escola.Nome);
                    vm.CurrentSortOrder = "Nome_Escola_Desc";
                    break;
                default:
                    vm.Departamentos = vm.Departamentos.OrderBy(p => p.Nome); // ascending by default
                    vm.CurrentSortOrder = "Nome";
                    break;

            }
            vm.TotalPages = (int)Math.Ceiling((decimal)vm.Departamentos.Count() / NUMBER_OF_PRODUCTS_PER_PAGE);
            vm.Departamentos = vm.Departamentos.Skip((page - 1) * NUMBER_OF_PRODUCTS_PER_PAGE);
            vm.Departamentos = vm.Departamentos.Take(NUMBER_OF_PRODUCTS_PER_PAGE);
            vm.LastPageShow = Math.Min(vm.TotalPages, page + NUMBER_OF_PAGES_BEFORE_AND_AFTER);
            vm.FirstPage = 1;
            vm.LastPage = vm.TotalPages;
            //return View(await gestaoTarefasIPGDbContext.ToListAsync());
            return View(vm);

        }

        // GET: Departamentos/Details/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamento
                .Include(d => d.Escola)
                .FirstOrDefaultAsync(m => m.DepartamentoId == id);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        // GET: Departamentos/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            ViewData["EscolaId"] = new SelectList(_context.Escola, "EscolaID", "Nome");
            return View();
        }

        // POST: Departamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([Bind("DepartamentoId,Nome,EscolaId")] Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                // se isto for null é porque não encontrou nenhum registo na tabela Escola com o mesmo Nome
                if (_context.Escola.FirstOrDefault(m => m.Nome == departamento.Nome) == null)
                {
                    _context.Add(departamento);
                    await _context.SaveChangesAsync();
                    return View("Sucesso");
                }
                else
                {
                    ViewData["EscolaId"] = new SelectList(_context.Escola, "EscolaID", "Nome", departamento.EscolaId);
                    // aparece a mensagem de erro em baixo do input do Nome
                    ModelState.AddModelError("Nome", "Não é possível adicionar nomes repetidos.");
                    return View(departamento);
                }
            }
            else
            {
                return View("Erro");
            }          
        }

        // GET: Departamentos/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamento.FindAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }
            ViewData["EscolaId"] = new SelectList(_context.Escola, "EscolaID", "Nome", departamento.EscolaId);
            return View(departamento);
        }

        // POST: Departamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int id, [Bind("DepartamentoId,Nome,EscolaId")] Departamento departamento)
        {
            if (id != departamento.DepartamentoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // se isto for null é porque não encontrou nenhum registo na tabela Escola com o mesmo Nome
                    if (_context.Escola.FirstOrDefault(m => m.Nome == departamento.Nome) == null)
                    {
                        _context.Update(departamento);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        ViewData["EscolaId"] = new SelectList(_context.Escola, "EscolaID", "Nome", departamento.EscolaId);
                        // aparece a mensagem de erro em baixo do input do Nome
                        ModelState.AddModelError("Nome", "Não é possível adicionar nomes repetidos.");
                        return View(departamento);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartamentoExists(departamento.DepartamentoId))
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

        // GET: Departamentos/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamento
                .Include(d => d.Escola)
                .FirstOrDefaultAsync(m => m.DepartamentoId == id);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        // POST: Departamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departamento = await _context.Departamento.FindAsync(id);
            _context.Departamento.Remove(departamento);
            await _context.SaveChangesAsync();
            return View("Sucesso");
        }

        private bool DepartamentoExists(int id)
        {
            return _context.Departamento.Any(e => e.DepartamentoId == id);
        }
    }
}
