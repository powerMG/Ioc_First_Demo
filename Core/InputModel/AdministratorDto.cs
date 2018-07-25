using Hesint.Lib.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.InputModel
{
    public class AdministratorDto
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "登陆名不能为空"), MaxLength(10, ErrorMessage = "登陆名不能超过10位"), MinLength(6, ErrorMessage = "登陆名最短5位"), RegularExpression(Reg.UserNameRegStr, ErrorMessage = Reg.UserNameErrorMsg)]
        public string LoginName { get; set; }

        [Required(AllowEmptyStrings =true,ErrorMessage = "密码不能为空"), MaxLength(16, ErrorMessage = "密码最长为16位"), MinLength(8, ErrorMessage = "密码最短为8位"), RegularExpression(Reg.PasswordRegStr, ErrorMessage = Reg.PasswordErrorMsg)]
        public string Password { get; set; }

        public DateTime? LastLoginTime { get; set; }

        public string LastLoginIp { get; set; }
    }
}
