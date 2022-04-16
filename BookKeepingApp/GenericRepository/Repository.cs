using BookKeepingApp.Context;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookKeepingApp.GenericRepository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        //#region Without UoW
        //DbContext _context;
        //DbSet<T> _dbSet;

        //public Repository(DbContext context)
        //{
        //    _context = context;
        //    _dbSet = context.Set<T>();
        //}
        //#endregion Without UoW

        #region UoW
        ApplicationDBContext _context;
        DbSet<T> _dbSet;

        public Repository(ApplicationDBContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        #endregion UoU
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);

        }
        public void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = _dbSet.Where(where).AsEnumerable();
            foreach (T obj in objects)
                _dbSet.Remove(obj);

        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where).FirstOrDefault<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where).AsEnumerable();
        }
        public T FirstOrDefault(Expression<Func<T, bool>> where)

        {
            return _dbSet.FirstOrDefault(where);
        }
        public T LastOrDefault(Expression<Func<T, bool>> where)

        {
            return _dbSet.LastOrDefault(where);
        }
        public bool Any(Expression<Func<T, bool>> where)
        {
            return _dbSet.Any(where);
        }
        public T First(Expression<Func<T, bool>> where)
        {
            return _dbSet.First(where);
        }
        public T Last(Expression<Func<T, bool>> where)
        {
            return _dbSet.Last(where);
        }
        public bool IsExist(Expression<Func<T, bool>> where)
        {
            var count = _dbSet.Count(where);
            return count > 0;
        }

        public string Max(Expression<Func<T, string>> where)
        {
            return _dbSet.AsNoTracking().Max(where);
        }

        public string Min(Expression<Func<T, string>> where)
        {
            return _dbSet.AsNoTracking().Min(where);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void AddMultiple(IEnumerable<T> list)
        {
            _context.Set<T>().AddRange(list);
        }

        public void DeleteMultiple(IEnumerable<T> list)
        {
            _context.Set<T>().RemoveRange(list);
        }

        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
           
            return _context.Database.ExecuteSqlRaw(sqlCommand, parameters);
        }

        public IEnumerable<T> ExecStoreProcedure<T>(string sql, params object[] parameters) where T : class
        {
            return _context.Set<T>().FromSqlRaw(sql);
        }
        public IEnumerable<T> SQLQueryList<T>(string sql) where T : class
        {
            return _context.Set<T>().FromSqlRaw(sql);
        }
        public T SQLQuery<T>(string sql) where T : class
        {
            return _context.Set<T>().FromSqlRaw(sql).FirstOrDefault();
        }

        public T ExecuteScalar<T>(string sqlCommand, params object[] parameters) where T : class
        {
            return _context.Set<T>().FromSqlRaw(sqlCommand).FirstOrDefault();
        }

        public IEnumerable<T> ExecWithStoreProcedure(string query, params object[] parameters)
        {
            return _context.Set<T>().FromSqlRaw(query, parameters);
        }
        

    }
}