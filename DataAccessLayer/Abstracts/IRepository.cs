using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstracts
{
    public interface IRepository<T>
    {
        List<T> List();

        void Add(T t);

        T GetById(Expression<Func<T, bool>> filter);
        void Delete(T t);
        void Update(T t);

        //şartlı listele
        List<T> List(Expression<Func<T, bool>> filter);
    }
}
