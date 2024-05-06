using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;
using System.Net.WebSockets;
using System.Reflection;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Linq.Expressions;
using static Utilities.Enums.File;
using Utilities;

namespace DataLayer.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CollegeContext _collegeContext;

        private DbSet<T> _entities;

        public Repository(CollegeContext collegeContext)
        {
            _collegeContext = collegeContext;
        }

        private DbSet<T> Entities
        {
            get
            {
                if(_entities != null)
                {
                    return _entities;
                }
                else
                {
                    Type type = typeof(CollegeContext);
                    string typeName = typeof(T).Name;
                    string entitiesName = typeName.Pluralize();
                    PropertyInfo correspondingProperty = type.GetProperty(entitiesName);
                    var entities = correspondingProperty.GetValue(_collegeContext, null);
                    return (DbSet<T>)entities;
                }
            }
        }

        public T Get(int id)
        {
            FileUtility.WriteContent(LogFile.ErrorLog, new List<string>() { $"[{DateTime.Now.ToString()}] Entities != null? {Entities != null}" });
            return Entities.Find(id);
        }

        public T Get(Expression<Func<T, bool>> condition)
        {
            return Entities.FirstOrDefault(condition);
        }

        public IEnumerable<T> Gets(Expression<Func<T, bool>> condition)
        {
            return Entities.Where(condition).ToList();
        }

        public IEnumerable<T> Gets()
        {
            return Entities.ToList();
        }

        public void Add(T item)
        {
            Entities.Add(item);
            _collegeContext.SaveChanges();
        }

        public void Delete(int id)
        {
            T item = Get(id);
            Entities.Remove(item);
            _collegeContext.SaveChanges();
        }

        public T Update(T item)
        {
            Entities.Update(item);
            _collegeContext.SaveChanges();
            return item;
        }

        public int Count(Expression<Func<T, bool>> condition)
        {
            return Entities.Count(condition);
        }

        public int Count()
        {
            return Entities.Count();
        }

        public bool Save()
        {
            return (_collegeContext.SaveChanges() >= 0);
        }
    }
}
