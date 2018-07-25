using Core.Contract.Channel;
using Core.Contract.Environment;
using Core.ViewModel.Channel;
using Microsoft.AspNetCore.Http;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Helper
{
    public class Environment : ICurrentRequest
    {
        private string requestUrl;
        /// <summary>
        /// 请求的URL
        /// </summary>
        public string RequestUrl => requestUrl;

        public Models.Administrator CurrentUser { get; set; }
        private string url;
        /// <summary>
        /// 请求的根路径
        /// </summary>
        public string Url => url;

        public Environment(IHttpContextAccessor httpContext)
        {
            HttpRequest request = httpContext.HttpContext.Request;
            this.requestUrl = $"{request.Scheme}://{request.Host}{request.PathBase}{request.Path}{request.QueryString}";
            this.url = $"{request.Scheme}://{request.Host}";
        }
    }
}
