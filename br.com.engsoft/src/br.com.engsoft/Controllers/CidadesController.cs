using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using br.com.engsoft.Data;
using br.com.engsoft.Models;
using br.com.engsoft.Data.Repository;

namespace br.com.engsoft.Controllers
{
    public class CidadesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IRepository<Cidade> CidadeRepository;

        public CidadesController(ApplicationDbContext context)
        //public CidadesController()
        {
            CidadeRepository = new CidadeRepository(context);    
        }

        // GET: Cidades
        public async Task<IActionResult> Index()
        {
            return View(this.CidadeRepository.GetAll());
            //return View(await _context.Cidade.ToListAsync());
        }

        // GET: Cidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidade = this.CidadeRepository.GetById(id);
            //var cidade = await _context.Cidade.SingleOrDefaultAsync(m => m.codigo_cidade == id);
            if (cidade == null)
            {
                return NotFound();
            }

            return View(cidade);
        }

        // GET: Cidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("codigo_cidade,UF,nome,taxa")] Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                this.CidadeRepository.Save(cidade);
                //_context.Add(cidade);
                //await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cidade);
        }

        // GET: Cidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidade = this.CidadeRepository.GetById(id);
            //var cidade = await _context.Cidade.SingleOrDefaultAsync(m => m.codigo_cidade == id);
            if (cidade == null)
            {
                return NotFound();
            }
            return View(cidade);
        }

        // POST: Cidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("codigo_cidade,UF,nome,taxa")] Cidade cidade)
        {
            if (id != cidade.codigo_cidade)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    cidade.codigo_cidade = id;
                    this.CidadeRepository.Update(cidade);
                    //_context.Update(cidade);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CidadeExists(cidade.codigo_cidade))
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
            return View(cidade);
        }

        // GET: Cidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidade = this.CidadeRepository.Where(x => x.codigo_cidade == id).FirstOrDefault();
            //var cidade = await _context.Cidade.SingleOrDefaultAsync(m => m.codigo_cidade == id);
            if (cidade == null)
            {
                return NotFound();
            }

            return View(cidade);
        }

        // POST: Cidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cidade = this.CidadeRepository.Where(x => x.codigo_cidade == id).FirstOrDefault();
            this.CidadeRepository.Delete(cidade);

            //var cidade = await _context.Cidade.SingleOrDefaultAsync(m => m.codigo_cidade == id);
            //_context.Cidade.Remove(cidade);
            //await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CidadeExists(int id)
        {

            return _context.Cidade.Any(e => e.codigo_cidade == id);
        }
    }
}
