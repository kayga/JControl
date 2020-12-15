using JControl.Base.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JControl.Base.IDal
{

    public interface IBaseService<T> : IDisposable where T : BaseEntity, new()
    {
        Task<int> AddAsync(T model);
        Task<int> AddConnChildAsync(T model);
        Task<int> DeleteAsync(int id);
        Task<int> EditAsync(T model);


        Task<int> EditConnChildAsync(T model);
        IQueryable<T> GetAll();
        Task<T> GetOneAsync(int id);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> whereLambda);
        IQueryable<T> QueryByPage(int pageSize, int pageIndex, Expression<Func<T, bool>> whereLambda, bool isAsc);
        Task<int> RealDeleteAsync(int id);
    }
}