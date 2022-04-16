using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookKeepingApp.GenericRepository
{
    public interface IRepository<T> where T : class
    {
        #region Command
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);

        void AddMultiple(IEnumerable<T> list);
        void DeleteMultiple(IEnumerable<T> list);

        int ExecuteCommand(string sqlCommand, params object[] parameters);

        #endregion Command


        #region Query
        T Get(int id);
        T Get(Expression<Func<T, bool>> where);
        T First(Expression<Func<T, bool>> where);
        T FirstOrDefault(Expression<Func<T, bool>> where);

        T Last(Expression<Func<T, bool>> where);
        T LastOrDefault(Expression<Func<T, bool>> where);
        bool Any(Expression<Func<T, bool>> where);
        string Max(Expression<Func<T, string>> where);
        string Min(Expression<Func<T, string>> where);
        bool IsExist(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> where);

        #endregion Query

        IEnumerable<T> ExecWithStoreProcedure(string query, params object[] parameters);
        IEnumerable<T> ExecStoreProcedure<T>(string sql, params object[] parameters) where T : class;
        IEnumerable<T> SQLQueryList<T>(string sql) where T : class;
        T SQLQuery<T>(string sql) where T : class;        
        T ExecuteScalar<T>(string sqlCommand, params object[] parameters) where T : class;


    }
}