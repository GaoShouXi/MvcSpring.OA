
using MvcSpring.OA.IBLL;
using MvcSpring.OA.IDAL;
using MvcSpring.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcSpring.OA.BLL
{
    
   
	 public partial class ActionInfoService :BaseService<ActionInfo>,IActionInfoService
    {
	     public override void SetCurrentDal()
        {
            CurrentDal = DbSession.ActionInfoDal;
        }
	}
    
   
	 public partial class ButtonInfoService :BaseService<ButtonInfo>,IButtonInfoService
    {
	     public override void SetCurrentDal()
        {
            CurrentDal = DbSession.ButtonInfoDal;
        }
	}
    
   
	 public partial class DepartmentService :BaseService<Department>,IDepartmentService
    {
	     public override void SetCurrentDal()
        {
            CurrentDal = DbSession.DepartmentDal;
        }
	}
    
   
	 public partial class R_UserInfo_ActionInfoService :BaseService<R_UserInfo_ActionInfo>,IR_UserInfo_ActionInfoService
    {
	     public override void SetCurrentDal()
        {
            CurrentDal = DbSession.R_UserInfo_ActionInfoDal;
        }
	}
    
   
	 public partial class RoleInfoService :BaseService<RoleInfo>,IRoleInfoService
    {
	     public override void SetCurrentDal()
        {
            CurrentDal = DbSession.RoleInfoDal;
        }
	}
    
   
	 public partial class StateOperateLogService :BaseService<StateOperateLog>,IStateOperateLogService
    {
	     public override void SetCurrentDal()
        {
            CurrentDal = DbSession.StateOperateLogDal;
        }
	}
    
   
	 public partial class UserInfoService :BaseService<UserInfo>,IUserInfoService
    {
	     public override void SetCurrentDal()
        {
            CurrentDal = DbSession.UserInfoDal;
        }
	}
    
   
	 public partial class UserInfoExtentionService :BaseService<UserInfoExtention>,IUserInfoExtentionService
    {
	     public override void SetCurrentDal()
        {
            CurrentDal = DbSession.UserInfoExtentionDal;
        }
	}
   
}
