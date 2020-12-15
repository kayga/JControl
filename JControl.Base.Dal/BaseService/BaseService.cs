using JControl.Base.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JControl.Base.Dal
{
    

    public abstract class BaseService<T> : IDal.IBaseService<T> where T : BaseEntity, new()
    {
        public Models.ControlSystemContext db { get; set; } = new ControlSystemContext();
        public void Dispose()
        {
            db.Dispose();
        }
        public async Task<int> AddAsync(T model)
        {
            db.Entry<T>(model).State = EntityState.Added;
            return await db.SaveChangesAsync();
        }
        public async Task<int> AddConnChildAsync(T model)
        {
            db.Add(model);
            return await db.SaveChangesAsync();
        }

        public async Task<int> EditAsync(T model)
        {
            db.Update(model);
            return await db.SaveChangesAsync();
        }

        public async Task<int> EditConnChildAsync(T model)
        {
            db.Attach(model);
            return await db.SaveChangesAsync();
        }

        public async Task<int> RealDeleteAsync(int id)
        {
            var t = new T() { Id = id };
            db.Entry(t).State = EntityState.Deleted;


            return await db.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(int id)
        {
            var t = new T() { Id = id };
            db.Entry(t).State = EntityState.Unchanged;
            t.IsRemoved = true;

            return await db.SaveChangesAsync();
        }


        public IQueryable<T> GetAll()
        {
            return db.Set<T>().Where(m => !m.IsRemoved).AsNoTracking();
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> whereLambda)
        {
            return GetAll().Where(whereLambda);
        }

        public async Task<T> GetOneAsync(int id)
        {
            return await GetAll().FirstAsync(m => m.Id == id);
        }


        public IQueryable<T> QueryByPage(int pageSize, int pageIndex, Expression<Func<T, bool>> whereLambda, bool isAsc)
        {
            if (isAsc)
            {
                return GetAll()
                    .Where(whereLambda)
                    .OrderBy(t => t.CreateTime)
                    .Skip(pageSize * (pageIndex - 1))
                    .Take(pageSize);
            }
            else
            {
                return GetAll()
                    .Where(whereLambda)
                    .OrderByDescending(t => t.CreateTime)
                    .Skip(pageSize * (pageIndex - 1))
                    .Take(pageSize);
            }
        }
    }

}
