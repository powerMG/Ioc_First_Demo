using Core.ViewModel.Channel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contract.Environment
{
    public interface ICurrentRequest
    {
        /// <summary>
        /// 当前请求的URL
        /// </summary>
        string RequestUrl { get; }

        /// <summary>
        /// 当前请求的根URL
        /// </summary>
        string Url { get; }

        /// <summary>
        /// 当前登陆的用户
        /// </summary>
        Models.Administrator CurrentUser { get; set; }
    }
}
