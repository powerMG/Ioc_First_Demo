using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Hesint.Lib.Helper
{
    public static class Reg
    {
        /// <summary>
        /// 用户名校验正则
        /// </summary>
        public const  string UserNameRegStr = @"^\w+$";

        /// <summary>
        /// 用户名校验错误提示信息
        /// </summary>
        public const string UserNameErrorMsg = "用户名只能为数字或字母";

        /// <summary>
        /// 密码校验正则
        /// </summary>
        public const string PasswordRegStr = @"^(((?=.*[0-9])(?=.*[a-zA-Z])|(?=.*[0-9])(?=.*[^\s0-9a-zA-Z])|(?=.*[a-zA-Z])(?=.*[^\s0-9a-zA-Z]))[^\s]+)$";

        /// <summary>
        /// 密码校验错误提示信息
        /// </summary>
        public const string PasswordErrorMsg = "密码至少包含数字、字母和特殊字符的两种";

        /// <summary>
        /// URL 验证正则
        /// </summary>
        public const string URLRegStr = @"^([hH][tT]{2}[pP]:\/\/|[hH][tT]{2}[pP][sS]:\/\/)(([A-Za-z0-9-~]+)\.)+([A-Za-z0-9-~\/])+$";

        /// <summary>
        /// URL验证错误信息
        /// </summary>
        public const string URLRegStrErrorMsg = "网址必须以http或者https开头";
    }
}
