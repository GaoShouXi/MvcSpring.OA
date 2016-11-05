using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcSpring.OA.DAL
{
   public partial class BaseDal<T> where T:class
    {
       public DbContext db { get { return DbContextFactory.GetCurrentContext(); } }
        #region 查询
       public IQueryable<T> GetEntites(Expression<Func<T,bool>> whereLambda)
       {
           return db.Set<T>().Where(whereLambda).AsQueryable();
       }
       public IQueryable<T> GetEntitesByPage<S>(int pageSize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderbyLambda, bool IsAsc)
       {
           total = db.Set<T>().Where(whereLambda).Count();
           if (IsAsc)//升序
           {
               var temp = db.Set<T>().Where(whereLambda)
                   .OrderBy(orderbyLambda)
                   .Skip(pageSize * (pageIndex - 1))
                   .Take(pageSize).AsQueryable();
               return temp;
           }
           else {

               var temp = db.Set<T>().Where(whereLambda)
                   .OrderByDescending(orderbyLambda)
                   .Skip(pageSize * (pageIndex - 1))
                   .Take(pageSize).AsQueryable();
               return temp;
               //降序

           }
           
       }


        #endregion

        #region 增删改CUD

       public T Add(T entity)
       {
           db.Set<T>().Add(entity);
           return entity;
       }
       public bool Update(T entity)
       {
           db.Entry(entity).State = EntityState.Modified;
           return true;
       }
       public bool Delete(T entity)
       {
           db.Set<T>().Remove(entity);
           return true;
       }
       public bool Delete(int id)
       {
         var entity=db.Set<T>().Find(id);
         db.Entry(entity).Property("DelFlag").CurrentValue = (Int32)MvcSpring.OA.Model.Enum.DelFlagEnum.Deleted;
         db.Entry(entity).Property("DelFlag").IsModified = true;
         return true;

       }
       public int  Delete(List<int> ids)
       {
           foreach (var id in ids)
           {
               var entity = db.Set<T>().Find(id);
               db.Entry(entity).Property("DelFlag").CurrentValue = (Int32)MvcSpring.OA.Model.Enum.DelFlagEnum.Deleted;
               db.Entry(entity).Property("DelFlag").IsModified = true;

           }
           return ids.Count();
       
       }
     
        #endregion
    }
}
