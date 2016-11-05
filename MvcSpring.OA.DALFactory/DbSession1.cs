
using MvcSpring.OA.DAL;
using MvcSpring.OA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcSpring.OA.DALFactory
{
   public partial class DbSession:IDbSession
   {
     
   public IActionInfoDal ActionInfoDal
   {
      get{ return StaticDALFactory.GetActionInfoDal();}
   }
     
   public IButtonInfoDal ButtonInfoDal
   {
      get{ return StaticDALFactory.GetButtonInfoDal();}
   }
     
   public IDepartmentDal DepartmentDal
   {
      get{ return StaticDALFactory.GetDepartmentDal();}
   }
     
   public IR_UserInfo_ActionInfoDal R_UserInfo_ActionInfoDal
   {
      get{ return StaticDALFactory.GetR_UserInfo_ActionInfoDal();}
   }
     
   public IRoleInfoDal RoleInfoDal
   {
      get{ return StaticDALFactory.GetRoleInfoDal();}
   }
     
   public IStateOperateLogDal StateOperateLogDal
   {
      get{ return StaticDALFactory.GetStateOperateLogDal();}
   }
     
   public IUserInfoDal UserInfoDal
   {
      get{ return StaticDALFactory.GetUserInfoDal();}
   }
     
   public IUserInfoExtentionDal UserInfoExtentionDal
   {
      get{ return StaticDALFactory.GetUserInfoExtentionDal();}
   }
      }
}
