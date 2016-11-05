﻿
using MvcSpring.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcSpring.OA.IDAL
{
    public partial interface IDbSession
	{
      IActionInfoDal ActionInfoDal{get;}
      IButtonInfoDal ButtonInfoDal{get;}
      IDepartmentDal DepartmentDal{get;}
      IR_UserInfo_ActionInfoDal R_UserInfo_ActionInfoDal{get;}
      IRoleInfoDal RoleInfoDal{get;}
      IStateOperateLogDal StateOperateLogDal{get;}
      IUserInfoDal UserInfoDal{get;}
      IUserInfoExtentionDal UserInfoExtentionDal{get;}
      }
}
