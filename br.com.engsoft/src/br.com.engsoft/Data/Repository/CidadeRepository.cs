using br.com.engsoft.Data;
using br.com.engsoft.Models;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using br.com.engsoft.Helpers;

namespace br.com.engsoft.Data.Repository
{
    public class CidadeRepository : IRepository<Cidade>
    {
        private ApplicationDbContext _context;

        public CidadeRepository(ApplicationDbContext contex)
        {
            this._context = contex;
        }

        public void Delete(Cidade model)
        {
            var entry = this._context.Entry(model);
            if (entry.State == EntityState.Detached)
                this._context.Cidade.Attach(model);

            this._context.ChangeObjectState(model, EntityState.Deleted);
            this._context.SaveChanges();
        }

        public IEnumerable<Cidade> GetAll()
        {
            return this._context.Cidade.ToList();
        }

        public Cidade GetById(object id)
        {
            return _context.Cidade.Find(id);
        }

        public IEnumerable<Cidade> OrderBy(Expression<Func<Cidade, bool>> expression)
        {
            return _context.Cidade.OrderBy(expression);
        }

        public int Save(Cidade model)
        {
            this._context.Cidade.Add(model);
            return _context.SaveChanges();
        }

        public int Update(Cidade model)
        {
            var entry = this._context.Entry(model);
            if (entry.State == EntityState.Detached)
                this._context.Cidade.Attach(model);

            this._context.ChangeObjectState(model, EntityState.Modified);
            return this._context.SaveChanges();
        }

        public IEnumerable<Cidade> Where(Expression<Func<Cidade, bool>> expression)
        {
            return this._context.Cidade.Where(expression);
        }
    }
}
