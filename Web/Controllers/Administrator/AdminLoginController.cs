using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Contract;
using Core.ViewModel;
using Hesint.Core.Cache;
using Hesint.Lib.Models.ResultModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;
using Models;
using Core.Contract.Environment;
using Web.Helper;

namespace Web.Controllers.Administrator
{
    [Produces("application/json")]
    [Route("api/AdminLogin")]
    
    public class AdminLoginController : Controller
    {
        private IAdministrator administrator;
        private ICache cache;
        private ICurrentRequest request;
        public AdminLoginController(IAdministrator administrator,ICache cache,ICurrentRequest request)
        {
            this.administrator = administrator;
            this.cache = cache;
            this.request = request;
        }
        [HttpPost]
        public async Task<OpreationResult<LoginResult>> Post([FromBody] AdminLoginViewModel model)
        {
            model.LastLoginIp = HttpContext.GetClientUserIp();
            model.LastLoginTime = DateTime.Now;
            var result = await administrator.LoginAsync(model);
            if(result.ResuleType== OpreationResuleType.Success)
            {
                var token = Guid.NewGuid().ToString("N").ToString().ToLower();
                cache.Set(result.Data,token);
                return OpreationResult<LoginResult>.Init(OpreationResuleType.Success,new LoginResult() { Token=token, UserName=result.Data.LoginName } ,"登陆成功");
            }
            return OpreationResult<LoginResult>.Init(result.ResuleType,null,result.Message);
        }
        [HttpGet]
        public JsonResult Get()
        {
            return Json(request);
        }
    }
}