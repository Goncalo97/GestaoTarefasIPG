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
    public class FuncionariosController : Controller
    {
        private readonly GestaoTarefasIPGDbContext _context;

        private const int NUMBER_OF_PRODUCTS_PER_PAGE = 10;
        private const int NUMBER_OF_PAGES_BEFORE_AND_AFTER = 1;
        public FuncionariosController(GestaoTarefasIPGDbContext context)
        {
            _context = context;
        }

        // GET: Funcionarios
        public IActionResult Index(int page = 1, string sortOrder = "Nome", string searchString = null, string searchOption = null)
        {
            decimal numberProducts = _context.Funcionario.Count();
            FuncionariosViewModel vm = new FuncionariosViewModel
            {
                Funcionarios = _context.Funcionario
                .Take((int)numberProducts),
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(numberProducts / NUMBER_OF_PRODUCTS_PER_PAGE),
                FirstPageShow = Math.Max(2, page - NUMBER_OF_PAGES_BEFORE_AND_AFTER),
            };
            var searchOptionList = new List<string>();

            searchOptionList.Add("Nome");
            searchOptionList.Add("Email");
            searchOptionList.Add("Telemovel");

            ViewBag.searchOption = new SelectList(searchOptionList);

            if (!String.IsNullOrEmpty(searchString) && !String.IsNullOrEmpty(searchOption))
            {
                vm.CurrentSearchString = searchString;
                switch (searchOption)
                {
                    case "Nome":
                        vm.Funcionarios = vm.Funcionarios.Where(p => p.nome.Contains(searchString, StringComparison.CurrentCultureIgnoreCase));
                        vm.CurrentSearchOption = "Nome";
                        break;
                    case "Email":
                        vm.Funcionarios = vm.Funcionarios.Where(p => p.email.Contains(searchString, StringComparison.CurrentCultureIgnoreCase));
                        vm.CurrentSearchOption = "Email";
                        break;
                    case "Telemovel":
                        vm.Funcionarios = vm.Funcionarios.Where(p => p.telemovel.Contains(searchString, StringComparison.CurrentCultureIgnoreCase));
                        vm.CurrentSearchOption = "Telemovel";
                        break;
                }
            }
            ViewBag.NomeSortParm = sortOrder == "Nome" ? "Nome_Desc" : "Nome";
            ViewBag.SiglaSortParm = sortOrder == "Email" ? "Email_Desc" : "Email";
            ViewBag.LocalizacaoSortParm = sortOrder == "Telemovel" ? "Telemovel_Desc" : "Telemovel";
            switch (sortOrder)
            {
                case "Nome_Desc":
                    vm.Funcionarios = vm.Funcionarios.OrderByDescending(p => p.nome);
                    vm.CurrentSortOrder = "Nome_Desc";
                    break;
                case "Email":
                    vm.Funcionarios = vm.Funcionarios.OrderBy(p => p.email);
                    vm.CurrentSortOrder = "Email";
                    break;
                case "Email_Desc":
                    vm.Funcionarios = vm.Funcionarios.OrderByDescending(p => p.email);
                    vm.CurrentSortOrder = "Email_Desc";
                    break;
                case "Telemovel":
                    vm.Funcionarios = vm.Funcionarios.OrderBy(p => p.telemovel);
                    vm.CurrentSortOrder = "Localizacao";
                    break;
                case "Telemovel_Desc":
                    vm.Funcionarios = vm.Funcionarios.OrderByDescending(p => p.telemovel);
                    vm.CurrentSortOrder = "Telemovel_Desc";
                    break;
                default:
                    vm.Funcionarios = vm.Funcionarios.OrderBy(p => p.nome); // ascending by default
                    vm.CurrentSortOrder = "Nome";
                    break;

            }
            vm.TotalPages = (int)Math.Ceiling((decimal)vm.Funcionarios.Count() / NUMBER_OF_PRODUCTS_PER_PAGE);
            vm.Funcionarios = vm.Funcionarios.Skip((page - 1) * NUMBER_OF_PRODUCTS_PER_PAGE);
            vm.Funcionarios = vm.Funcionarios.Take(NUMBER_OF_PRODUCTS_PER_PAGE);
            vm.LastPageShow = Math.Min(vm.TotalPages, page + NUMBER_OF_PAGES_BEFORE_AND_AFTER);
            vm.FirstPage = 1;
            vm.LastPage = vm.TotalPages;
            return View(vm);
        }

        // GET: Funcionarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario
                .FirstOrDefaultAsync(m => m.FuncionarioID == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // GET: Funcionarios/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([Bind("FuncionarioID,nome,email,telemovel")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                if (_context.Escola.FirstOrDefault(m => m.Nome == funcionario.nome) == null)
                {
                    _context.Add(funcionario);
                    await _context.SaveChangesAsync();
                    return View("Sucesso");
                }
                else
                {
                    ModelState.AddModelError("Nome", "Não é possível adicionar nomes repetidos.");
                    return View(funcionario);
                }
            }
            else
            {
                return View("Erro");
            }
        }

        // GET: Funcionarios/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario.FindAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return View(funcionario);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int id, [Bind("FuncionarioID,nome,email,telemovel")] Funcionario funcionario)
        {
            if (id != funcionario.FuncionarioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (_context.Escola.FirstOrDefault(m => m.Nome == funcionario.nome) == null)
                    {
                        _context.Update(funcionario);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        ModelState.AddModelError("Nome", "Não é possível adicionar nomes repetidos.");
                        return View(funcionario);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionarioExists(funcionario.FuncionarioID))
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

        // GET: Funcionarios/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario
                .FirstOrDefaultAsync(m => m.FuncionarioID == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionario = await _context.Funcionario.FindAsync(id);
            _context.Funcionario.Remove(funcionario);
            await _context.SaveChangesAsync();
            return View("Sucesso");
        }

        private bool FuncionarioExists(int id)
        {
            return _context.Funcionario.Any(e => e.FuncionarioID == id);
        }
    }
}
