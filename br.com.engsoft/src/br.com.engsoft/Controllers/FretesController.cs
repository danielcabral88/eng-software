using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using br.com.engsoft.Data;
using br.com.engsoft.Models;

namespace br.com.engsoft.Controllers
{
    public class FretesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FretesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Fretes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Frete.ToListAsync());
        }

        // GET: Fretes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frete = await _context.Frete.SingleOrDefaultAsync(m => m.codigo_frete == id);
            if (frete == null)
            {
                return NotFound();
            }

            return View(frete);
        }

        // GET: Fretes/Create
        public IActionResult Create()
        {
            //var model = new Frete();

            //var clientes = _context.Cliente.OrderBy(c => c.nome).Select(x => new { Id = x.codigo_cliente, Value = x.nome });
            //model.ListaClientes = new SelectList(clientes, "Id", "Value");

            //var cidades = _context.Cidade.OrderBy(c => c.nome).Select(x => new { Id = x.codigo_cidade, Value = x.nome });
            //model.ListaCidades = new SelectList(cidades, "Id", "Value");

            //return View(model);
            var clientes = _context.Cliente.OrderBy(c => c.nome).Select(x => new { Id = x.codigo_cliente, Value = x.nome });
            ViewBag.Clientes = clientes.Select(x => new SelectListItem
            {
                Text = x.Value,
                Value = x.Id.ToString()
            }).ToList();

            var cidades = _context.Cidade.OrderBy(c => c.nome).Select(x => new { Id = x.codigo_cidade, Value = x.nome });
            ViewBag.Cidades = cidades.Select(x => new SelectListItem
            {
                Text = x.Value,
                Value = x.Id.ToString()
            }).ToList();

            return View();
        }

        // POST: Fretes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("codigo_frete,descricao,peso,valor, cliente.Clientecodigo_cliente, cidade.Cidadecodigo_cidade")] Frete frete)
        {
            if (ModelState.IsValid)
            {
                _context.Add(frete);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(frete);
        }

        // GET: Fretes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frete = await _context.Frete.SingleOrDefaultAsync(m => m.codigo_frete == id);
            if (frete == null)
            {
                return NotFound();
            }
            return View(frete);
        }

        // POST: Fretes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("codigo_frete,descricao,peso,valor")] Frete frete)
        {
            if (id != frete.codigo_frete)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(frete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FreteExists(frete.codigo_frete))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(frete);
        }

        // GET: Fretes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frete = await _context.Frete.SingleOrDefaultAsync(m => m.codigo_frete == id);
            if (frete == null)
            {
                return NotFound();
            }

            return View(frete);
        }

        // POST: Fretes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var frete = await _context.Frete.SingleOrDefaultAsync(m => m.codigo_frete == id);
            _context.Frete.Remove(frete);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FreteExists(int id)
        {
            return _context.Frete.Any(e => e.codigo_frete == id);
        }
    }
}
