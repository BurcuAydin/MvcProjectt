using DataAccessLayer.Abstracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concretes.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {

        Context context = new Context();

        // T değerine karşılık gelen sınıfı object tutuyor.
        DbSet<T> _object;

        //T değerine karşılık gelen sınıf için ctor
        public GenericRepository()
        {
            _object = context.Set<T>();
        }

        public void Add(T t)
        {
            _object.Add(t);
            context.SaveChanges();
        }

        public void Delete(T t)
        {
            _object.Remove(t);
            context.SaveChanges();
            
        }

        public T GetById(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T t)
        {
            context.SaveChanges();
        }
    }
}
