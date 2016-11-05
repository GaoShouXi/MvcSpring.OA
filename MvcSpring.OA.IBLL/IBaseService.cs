using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcSpring.OA.IBLL
{
   public partial interface IBaseService<T> where T:class
    {
        #region 查询
        IQueryable<T> GetEntites(Expression<Func<T, bool>> whereLambda);
        IQueryable<T> GetEntitesByPage<S>(int pageSize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderbyLambda, bool IsAsc);
        #endregion
        T Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool Delete(int id);
        int DeleteList(List<int> ids);
    }
}
