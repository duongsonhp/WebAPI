using Humanizer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public interface IRepository<T> where T : class
    {
        public T Get(int id);

        public T Get(Expression<Func<T, bool>> condition);

        public IEnumerable<T> Gets(Expression<Func<T, bool>> condition);

        public IEnumerable<T> Gets();

        public void Add(T item);

        public void Delete(int id);

        public T Update(T item);

        public int Count(Expression<Func<T, bool>> condition);

        public int Count();

        public bool Save();
    }
}
