using br.com.engsoft.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using br.com.engsoft.Helpers;

namespace br.com.engsoft.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Delete(T model)
        {
            var entry = this._context.Entry(model);
            if (entry.State == EntityState.Detached)
                this._context.Attach<T>(model);

            this._context.ChangeObjectState(model, EntityState.Deleted);
            this._context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return this._context.Set<T>().AsEnumerable();
            //throw new NotImplementedException();
        }

        public T GetById(object id)
        {
            return this._context.Set<T>().Find(id);
            //throw new NotImplementedException();
        }

        public IEnumerable<T> OrderBy(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).AsEnumerable();
            //throw new NotImplementedException();
        }

        public int Save(T model)
        {
            this._context.Set<T>().Add(model);
            return _context.SaveChanges();
            //throw new NotImplementedException();
        }

        public int Update(T model)
        {
            var entry = this._context.Entry(model);
            if (entry.State == EntityState.Detached)
                this._context.Set<T>().Attach(model);

            this._context.ChangeObjectState(model, EntityState.Modified);
            return this._context.SaveChanges();
            //throw new NotImplementedException();
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> expression)
        {
            return this._context.Set<T>().Where(expression);
            throw new NotImplementedException();
        }
    }
}
