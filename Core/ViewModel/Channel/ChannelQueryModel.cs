using Hesint.Lib.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.ViewModel.Channel
{
    public class ChannelQueryModel
    {
        /// <summary>
        /// 请求的频道Id
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// 请求频道的链接
        /// </summary>
        [RegularExpression(Reg.URLRegStr,ErrorMessage =Reg.URLRegStrErrorMsg)]
        public string Url { get; set; }
    }
}
