using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Generic
{
    public interface IGeneric<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        T GetByID(int id);
        IQueryable<T> GetAll();
        int Save();
    }
}
