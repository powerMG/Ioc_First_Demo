using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    /// <summary>
    /// 后台管理员类
    /// </summary>
    [Description]
    public class Administrator
    {
        [Key]
        public int Id { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }

        public DateTime? LastLoginTime { get; set; }

        public string LastLoginIp { get; set; }
    }
}
