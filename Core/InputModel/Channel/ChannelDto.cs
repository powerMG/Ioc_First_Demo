using Hesint.Lib.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.InputModel.Channel
{
    public class ChannelDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "频道名称不能为空")]
        public string Name { get; set; }

        [Required(ErrorMessage = "频道的URL不能为空"), RegularExpression(Reg.URLRegStr, ErrorMessage = Reg.URLRegStrErrorMsg)]
        public string Url { get; set; }

        public int SortId { get; set; }
    }
}
