//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcSpring.OA.Model
{
    using System;
    using System.Collections.Generic;
    
    [Serializable]
    public partial class UserInfo
    {
        public UserInfo()
        {
            this.R_UserInfo_ActionInfo = new HashSet<R_UserInfo_ActionInfo>();
            this.RoleInfo = new HashSet<RoleInfo>();
            this.StateOperateLog = new HashSet<StateOperateLog>();
            this.UserInfoExtention = new HashSet<UserInfoExtention>();
        }
    
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string ShowName { get; set; }
        public int DelFlag { get; set; }
        public string SubTime { get; set; }
        public string Modfiedon { get; set; }
        public string Remark { get; set; }
    
        public virtual ICollection<R_UserInfo_ActionInfo> R_UserInfo_ActionInfo { get; set; }
        public virtual ICollection<RoleInfo> RoleInfo { get; set; }
        public virtual ICollection<StateOperateLog> StateOperateLog { get; set; }
        public virtual ICollection<UserInfoExtention> UserInfoExtention { get; set; }
    }
}