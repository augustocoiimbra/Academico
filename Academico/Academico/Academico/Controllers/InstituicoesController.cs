using Academico.Data;
using Academico.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Academico.Controllers
{
    public class InstituicoesController : Controller
    {
        private readonly AcademicoContext _context;

        public InstituicoesController(AcademicoContext context)
        {
            _context = context;
        }

        // GET: Instituicoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Instituicoes.OrderBy(i => i.Nome).ToListAsync());
        }

        // GET: Instituicoes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null) return NotFound();

            var instituicao = await _context.Instituicoes.FirstOrDefaultAsync(i => i.Id == id);
            if (instituicao == null) return NotFound();

            return View(instituicao);
        }

        // GET: Instituicoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instituicoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Endereco")] Instituicao instituicao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instituicao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instituicao);
        }

        // GET: Instituicoes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null) return NotFound();

            var instituicao = await _context.Instituicoes.FindAsync(id);
            if (instituicao == null) return NotFound();

            return View(instituicao);
        }

        // POST: Instituicoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Nome,Endereco")] Instituicao instituicao)
        {
            if (id != instituicao.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instituicao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstituicaoExists(instituicao.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(instituicao);
        }

        // GET: Instituicoes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null) return NotFound();

            var instituicao = await _context.Instituicoes.FirstOrDefaultAsync(i => i.Id == id);
            if (instituicao == null) return NotFound();

            return View(instituicao);
        }

        // POST: Instituicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var instituicao = await _context.Instituicoes.FindAsync(id);
            if (instituicao != null)
            {
                _context.Instituicoes.Remove(instituicao);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool InstituicaoExists(long id)
        {
            return _context.Instituicoes.Any(e => e.Id == id);
        }
    }
}
