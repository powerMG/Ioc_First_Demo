using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Contract.Channel;
using Core.InputModel.Channel;
using Core.ViewModel.Channel;
using Hesint.Core.Cache;
using Hesint.Lib.Models.ResultModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Helper;

namespace Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Channel")]
    [AuthorizationFilter]
    public class ChannelController : Controller
    {
        private IChannelContract channel;
        private ICache cache;
        public ChannelController(IChannelContract channel,ICache cache)
        {
            this.channel = channel;
            this.cache = cache;
        }

        /// <summary>
        /// 根据Id或者URL来确定请求的是哪个频道
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<dynamic> Get(ChannelQueryModel queryModel)
        {
            return await channel.GetChannel(queryModel);
        }

        // GET: api/channel/list
        [HttpGet("/api/channel/list")]
        public OpreationResult<List<ChannelViewModel>> GetAll()
        {
            return channel.GetList(a => a.Id > 0);
        }




        // POST: api/Channel
        [HttpPost]
        public async Task<OpreationResult> Post(ChannelDto dto)
        {
            return await channel.Update(dto);
        }
        
        // PUT: api/Channel/5
        [HttpPut]
        public async Task<OpreationResult>  Put(ChannelDto dto)
        {
            return await channel.Insert(dto);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<OpreationResult> Delete(int id)
        {
            return await channel.Delete(id);
        }
    }
}
