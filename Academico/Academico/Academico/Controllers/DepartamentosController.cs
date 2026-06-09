using Academico.Data;
using Academico.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Academico.Controllers
{
    public class DepartamentosController : Controller
    {
        private readonly AcademicoContext _context;

        public DepartamentosController(AcademicoContext context)
        {
            _context = context;
        }

        // GET: Departamentos
        public async Task<IActionResult> Index()
        {
            var departamentos = await _context.Departamentos
                .Include(d => d.Instituicao)
                .OrderBy(d => d.Nome)
                .ToListAsync();
            return View(departamentos);
        }

        // GET: Departamentos/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null) return NotFound();

            var departamento = await _context.Departamentos
                .Include(d => d.Instituicao)
                .FirstOrDefaultAsync(d => d.Id == id);
            if (departamento == null) return NotFound();

            return View(departamento);
        }

        // GET: Departamentos/Create
        public IActionResult Create()
        {
            ViewData["InstituicaoId"] = new SelectList(_context.Instituicoes, "Id", "Nome");
            return View();
        }

        // POST: Departamentos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,InstituicaoId")] Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstituicaoId"] = new SelectList(_context.Instituicoes, "Id", "Nome", departamento.InstituicaoId);
            return View(departamento);
        }

        // GET: Departamentos/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null) return NotFound();

            var departamento = await _context.Departamentos.FindAsync(id);
            if (departamento == null) return NotFound();

            ViewData["InstituicaoId"] = new SelectList(_context.Instituicoes, "Id", "Nome", departamento.InstituicaoId);
            return View(departamento);
        }

        // POST: Departamentos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Nome,InstituicaoId")] Departamento departamento)
        {
            if (id != departamento.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartamentoExists(departamento.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstituicaoId"] = new SelectList(_context.Instituicoes, "Id", "Nome", departamento.InstituicaoId);
            return View(departamento);
        }

        // GET: Departamentos/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null) return NotFound();

            var departamento = await _context.Departamentos
                .Include(d => d.Instituicao)
                .FirstOrDefaultAsync(d => d.Id == id);
            if (departamento == null) return NotFound();

            return View(departamento);
        }

        // POST: Departamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var departamento = await _context.Departamentos.FindAsync(id);
            if (departamento != null)
            {
                _context.Departamentos.Remove(departamento);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool DepartamentoExists(long id)
        {
            return _context.Departamentos.Any(e => e.Id == id);
        }
    }
}
