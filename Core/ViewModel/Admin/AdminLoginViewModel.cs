using Hesint.Lib.Helper;
using Hesint.Lib.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.ViewModel
{
    public class AdminLoginViewModel
    {
        private string _loginName;

        /// <summary>
        /// 用户输入的用户名
        /// </summary>
        [Required(ErrorMessage ="登陆名不能为空"),MaxLength(16,ErrorMessage ="登陆名不能超过16位"),MinLength(6,ErrorMessage ="登陆名最短5位"),RegularExpression(Reg.UserNameRegStr, ErrorMessage =Reg.UserNameErrorMsg)]
        public string LoginName
        {
            get
            {
                return _loginName;
            }
            set
            {
                _loginName = value.ToLower();
            }
        }
        /// <summary>
        /// 用户输入的加密后的密码
        /// </summary>
        [Required(ErrorMessage ="密码不能为空"),MaxLength(16,ErrorMessage ="密码最长为16位"),MinLength(8,ErrorMessage ="密码最短为8位"),RegularExpression(Reg.PasswordRegStr,ErrorMessage =Reg.PasswordErrorMsg)]
        public string Password { get; set; }

        /// <summary>
        /// 是否需要验证码
        /// </summary>
        public bool IsNeedCode { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string Code { get; set; }

        public DateTime? LastLoginTime { get; set; }

        public string LastLoginIp { get; set; }
    }
}
