
using MvcSpring.OA.IDAL;
using MvcSpring.OA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcSpring.OA.DAL
{
       public partial class ActionInfoDal:BaseDal<ActionInfo>,IActionInfoDal
    {
      }
       public partial class ButtonInfoDal:BaseDal<ButtonInfo>,IButtonInfoDal
    {
      }
       public partial class DepartmentDal:BaseDal<Department>,IDepartmentDal
    {
      }
       public partial class R_UserInfo_ActionInfoDal:BaseDal<R_UserInfo_ActionInfo>,IR_UserInfo_ActionInfoDal
    {
      }
       public partial class RoleInfoDal:BaseDal<RoleInfo>,IRoleInfoDal
    {
      }
       public partial class StateOperateLogDal:BaseDal<StateOperateLog>,IStateOperateLogDal
    {
      }
       public partial class UserInfoDal:BaseDal<UserInfo>,IUserInfoDal
    {
      }
       public partial class UserInfoExtentionDal:BaseDal<UserInfoExtention>,IUserInfoExtentionDal
    {
      }
      
}
