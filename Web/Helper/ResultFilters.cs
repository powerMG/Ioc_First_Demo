using Core.Contract.Environment;
using Hesint.Core.Cache;
using Hesint.Lib.Models.ResultModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Helper
{
    public class ResultFilters : IResultFilter
    {
        private IServiceProvider service;
        public ResultFilters(IServiceProvider service )
        {
            this.service = service;
        }
        public void OnResultExecuted(ResultExecutedContext context)
        {
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errorMessages = context.ModelState.Values.Where(a => a.Errors.Count > 0).SelectMany(a => a.Errors.Select(c => c.ErrorMessage)).ToList();
                context.Result = new JsonResult(OpreationResult<List<string>>.Init(OpreationResuleType.ValidtorError, errorMessages, "校验失败"));
            }
        }
    }

    public class AuthorizationFilter : Attribute,IAuthorizationFilter
    {
        private IServiceProvider service;
        private ICache cache;
        private ICurrentRequest environment;

       public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (string.IsNullOrEmpty(context.HttpContext.Request.Headers["H-Token"]))
            {
                context.Result = new JsonResult(OpreationResult.Init(OpreationResuleType.UnLogin, "用户未登陆"));
            }
            else
            {
                cache= (ICache)service.GetService(typeof(ICache));
                var cacheResult= cache.Get<Models.Administrator>(context.HttpContext.Request.Headers["H-Token"].ToString().ToLower());
                if(cacheResult.ResuleType== OpreationResuleType.Success)
                {
                    environment.CurrentUser = cacheResult.Data;
                }
                else
                {
                    context.Result = new JsonResult(OpreationResult.Init(OpreationResuleType.UnLogin, "用户未登陆"));
                }
               
            }
        }
    }
}
