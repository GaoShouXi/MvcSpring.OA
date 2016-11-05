using MvcSpring.OA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcSpring.OA.BLL
{
   public abstract partial class BaseService<T> where T:class
    {
       public IBaseDal<T> CurrentDal { get; set; }
       public IDbSession DbSession { get; set; }
       public abstract void SetCurrentDal();
       #region 查询

       public IQueryable<T> GetEntites(Expression<Func<T, bool>> whereLambda)
       {
           return CurrentDal.GetEntites(whereLambda);
       }
       public IQueryable<T> GetEntitesByPage<S>(int pageSize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderbyLambda, bool IsAsc)
       {
           return CurrentDal.GetEntitesByPage(pageSize, pageIndex, out total, whereLambda, orderbyLambda, IsAsc);
       }

       #endregion
       #region cud
       public int Delete(List<int> ids)
       {
           CurrentDal.Delete(ids);
           return DbSession.SaveChanges();
           
       }

       public int DeleteList(List<int> ids)
       {
           foreach (var id in ids)
           {
               CurrentDal.Delete(id);

           }
           return DbSession.SaveChanges();
       }
       public bool Delete(int id)
       {
           CurrentDal.Delete(id);
           return DbSession.SaveChanges() > 0;
       }
       public T Add(T entity)
       {
           CurrentDal.Add(entity);
           DbSession.SaveChanges();
           return entity;
       }
       public bool Update(T entity)
       {
           CurrentDal.Update(entity);

           return DbSession.SaveChanges() > 0;
       }
       public bool Delete(T entity)
       {
           CurrentDal.Delete(entity);
           return DbSession.SaveChanges() > 0;
       }
       #endregion
    }
}
