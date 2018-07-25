using Core.InputModel.Channel;
using Core.ViewModel.Channel;
using Hesint.Lib.Models.ResultModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contract.Channel
{
    public interface IChannelContract
    {
        /// <summary>
        /// 获取频道列表
        /// </summary>
        /// <returns></returns>
        OpreationResult<List<ChannelViewModel>> GetList(Func<Models.Channel, bool> func);

        /// <summary>
        /// 新增一个频道
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<OpreationResult<ChannelViewModel>> Insert(ChannelDto model);

        /// <summary>
        /// 更新一个频道
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<OpreationResult> Update(ChannelDto model);

        /// <summary>
        /// 删除一个频道
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<OpreationResult> Delete(int Id);

        /// <summary>
        /// 根据请求的URL获取一个频道
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        Task<OpreationResult<ChannelViewModel>> GetChannel(ChannelQueryModel queryModel);
        
    }
}
