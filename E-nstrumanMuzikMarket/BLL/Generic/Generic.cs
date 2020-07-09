using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Generic
{
    public class Generic<T> : IGeneric<T> where T : class
    {

        private readonly DbContext Context;
        private DbSet<T> ObjectDbSet;

        public EnstrumanMuzikMarketDBEntities context
        {
            get { return new EnstrumanMuzikMarketDBEntities(); }
            set { context = new EnstrumanMuzikMarketDBEntities();  }
        }

        //Context
        public Generic()
        {
            Context = new EnstrumanMuzikMarketDBEntities();
            ObjectDbSet = Context.Set<T>();
        }

        public Generic(DbContext context)
        {
            Context = context;
        }

        public void Add(T entity)
        {
            ObjectDbSet.Add(entity);
        }

        public void Update(T entity)
        {
            ObjectDbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            T entityDelete = ObjectDbSet.Find(id);
            ObjectDbSet.Remove(entityDelete);
        }

        public T GetByID(int id)
        {
            return ObjectDbSet.Find(id);
        }
        public IQueryable<T> GetAll()
        {
            return ObjectDbSet.ToList().AsQueryable();
        }

        public int Save()
        {
            return Context.SaveChanges();
        }
    }
}
