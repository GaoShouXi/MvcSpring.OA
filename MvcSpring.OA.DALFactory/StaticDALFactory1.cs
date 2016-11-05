
using MvcSpring.OA.DAL;
using MvcSpring.OA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MvcSpring.OA.DALFactory
{
  public partial  class StaticDALFactory
    {
   
     public static IActionInfoDal GetActionInfoDal()
     {
        
        
          return Assembly.Load(StaticDALFactory.assmeblyName).CreateInstance(StaticDALFactory.assmeblyName+".ActionInfoDal") as IActionInfoDal;
      }
   
     public static IButtonInfoDal GetButtonInfoDal()
     {


         return Assembly.Load(StaticDALFactory.assmeblyName).CreateInstance(StaticDALFactory.assmeblyName + ".ButtonInfoDal") as IButtonInfoDal;
      }
   
     public static IDepartmentDal GetDepartmentDal()
     {


         return Assembly.Load(StaticDALFactory.assmeblyName).CreateInstance(StaticDALFactory.assmeblyName + ".DepartmentDal") as IDepartmentDal;
      }
   
     public static IR_UserInfo_ActionInfoDal GetR_UserInfo_ActionInfoDal()
     {


         return Assembly.Load(StaticDALFactory.assmeblyName).CreateInstance(StaticDALFactory.assmeblyName + ".R_UserInfo_ActionInfoDal") as IR_UserInfo_ActionInfoDal;
      }
   
     public static IRoleInfoDal GetRoleInfoDal()
     {


         return Assembly.Load(StaticDALFactory.assmeblyName).CreateInstance(StaticDALFactory.assmeblyName + ".RoleInfoDal") as IRoleInfoDal;
      }
   
     public static IStateOperateLogDal GetStateOperateLogDal()
     {


         return Assembly.Load(StaticDALFactory.assmeblyName).CreateInstance(StaticDALFactory.assmeblyName + ".StateOperateLogDal") as IStateOperateLogDal;
      }
   
     public static IUserInfoDal GetUserInfoDal()
     {


         return Assembly.Load(StaticDALFactory.assmeblyName).CreateInstance(StaticDALFactory.assmeblyName + ".UserInfoDal") as IUserInfoDal;
      }
   
     public static IUserInfoExtentionDal GetUserInfoExtentionDal()
     {


         return Assembly.Load(StaticDALFactory.assmeblyName).CreateInstance(StaticDALFactory.assmeblyName + ".UserInfoExtentionDal") as IUserInfoExtentionDal;
      }
      }
}
