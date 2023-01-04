using Kutuphane.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.DataAccessLayer.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext context;

        public Repository(DbContext context)
        {
            this.context = context;
        }

        public void Add(T Item)
        {
            context.Set<T>().Add(Item);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetItem(object key)
        {
            return context.Set<T>().Find(key);
        }

        public void Remove(object key)
        {
            context.Set<T>().Remove(GetItem(key));
        }

        public void Remove(T Item)
        {
            if (context.Entry<T>(Item).State == EntityState.Detached)
            {
                context.Set<T>().Attach(Item);
            }
            context.Entry<T>(Item).State = EntityState.Deleted;
        }

        public void Update(T Item)
        {
            if (context.Entry<T>(Item).State == EntityState.Detached)
            {
                context.Set<T>().Attach(Item);
            }
            context.Entry<T>(Item).State = EntityState.Modified;
        }

        public void Dispose()
        {
            context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
