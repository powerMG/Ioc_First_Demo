using Core.Contract.Channel;
using Core.Contract.Environment;
using Core.InputModel.Channel;
using Core.ViewModel.Channel;
using EntityFramework;
using Hesint.Core.Mapper;
using Hesint.Lib.Models.ResultModel;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service.Channel
{
    public class ChannelService : IChannelContract
    {
        private DbContext db;
        private IAutoMapperConfig mapper;
        private ICurrentRequest request;
        public ChannelService(TreeDbContext db, IAutoMapperConfig mapper, ICurrentRequest request)
        {
            this.db = db;
            this.mapper = mapper;
            this.request = request;
        }

        private async Task<OpreationResult<ChannelViewModel>> GetChannel(string Url)
        {
            try
            {
                if (string.IsNullOrEmpty(Url))
                {
                    Url = request.Url;
                }
                var channel = await db.Set<Models.Channel>().Where(a => a.Url == Url).FirstOrDefaultAsync();
                if (channel == null)
                {
                    channel = await db.Set<Models.Channel>().OrderBy(a => a.SortId).FirstOrDefaultAsync();
                }
                if (channel == null)
                {
                    return OpreationResult<ChannelViewModel>.Init(OpreationResuleType.QueryNull, null, "不存在任何频道，请新建一个频道");
                }
                return OpreationResult<ChannelViewModel>.Init(OpreationResuleType.Success, mapper.MapTo<ChannelViewModel, Models.Channel>(channel));
            }
            catch(Exception e)
            {
                throw new Exception("查询频道时出错", e);
            }
        }

        private async Task<OpreationResult<ChannelViewModel>> GetChannel(int Id)
        {
            try
            {
                if (Id != 0)
                {
                    var channel = await db.Set<Models.Channel>().Where(a => a.Id == Id).FirstOrDefaultAsync();
                    if (channel == null)
                    {

                        return OpreationResult<ChannelViewModel>.Init(OpreationResuleType.QueryNull, null, "请求的频道不存在");
                    }
                    else
                    {
                        return OpreationResult<ChannelViewModel>.Init(OpreationResuleType.Success, mapper.MapTo<ChannelViewModel, Models.Channel>(channel));
                    }
                }
                else
                {
                    return  OpreationResult<ChannelViewModel>.Init(OpreationResuleType.ValidtorError, null,"请求的参数错误，请勿非法修改参数");
                }
            }
            catch (Exception e)
            {
                throw new Exception("根据ID获取频道时出错", e);
            }
        }

        async Task<OpreationResult> IChannelContract.Delete(int Id)
        {
            var categoryCount = await db.Set<Models.ArticleCategory>().Where(a => a.ChannelID == Id).CountAsync();
            if (categoryCount > 0)
            {
                return OpreationResult.Init(OpreationResuleType.ValidtorError, "请先删除当前频道下的分类");
            }
            else
            {
                var delModel = await db.Set<Models.Channel>().Where(a => a.Id == Id).FirstOrDefaultAsync();
                db.Set<Models.Channel>().Remove(delModel);
                var result= await db.SaveChangesAsync();
                if (result > 0)
                {
                    return OpreationResult.Init(OpreationResuleType.Success, "删除频道成功");
                }
                else
                {
                    return OpreationResult.Init(OpreationResuleType.Error, "删除失败");
                }
            }
        }

        OpreationResult<List<ChannelViewModel>> IChannelContract.GetList(Func<Models.Channel,bool> func)
        {
            var list = db.Set<Models.Channel>().Where(func).OrderBy(a=>a.SortId).Select(a => new ChannelViewModel() { Id = a.Id, Name = a.ChannelName, SortId = a.SortId, Url = a.Url }).ToList();
            return OpreationResult<List<ChannelViewModel>>.Init(OpreationResuleType.Success, list, "获取成功");
        }

        async Task<OpreationResult<ChannelViewModel>> IChannelContract.Insert(ChannelDto model)
        {

            if (model != null)
            {
                var dbModel = mapper.MapTo<Models.Channel, ChannelDto>(model);
                await db.Set<Models.Channel>().AddAsync(dbModel);
                int result=  await db.SaveChangesAsync();
                if (result > 0)
                {
                    return OpreationResult<ChannelViewModel>.Init(OpreationResuleType.Success, mapper.MapTo<ChannelViewModel, Models.Channel>(dbModel),"新增成功");
                }
                else
                {
                    return OpreationResult<ChannelViewModel>.Init(OpreationResuleType.Error, null, "新增失败");
                }
            }
            else
            {
                return OpreationResult<ChannelViewModel>.Init(OpreationResuleType.ValidtorError, null, "数据格式不正确");
            }
            
        }

        async Task<OpreationResult> IChannelContract.Update(ChannelDto model)
        {
            var dbModel = await db.Set<Models.Channel>().Where(a => a.Id == model.Id).FirstOrDefaultAsync();
            dbModel = mapper.MapTo<Models.Channel, ChannelDto>(model);
            db.Set<Models.Channel>().Update(dbModel);
            var result= await db.SaveChangesAsync();
            if (result > 0)
            {
                return OpreationResult.Init(OpreationResuleType.Success);
            }
            else
            {
                return OpreationResult.Init(OpreationResuleType.Error, "更新失败，请稍后重试");
            }
        }

        public async Task<OpreationResult<ChannelViewModel>> GetChannel(ChannelQueryModel queryModel)
        {
            if (queryModel.Id != null)
            {
                return await this.GetChannel(queryModel.Id.Value);
            }
            if (queryModel.Url != null)
            {
                return await this.GetChannel(queryModel.Url);
            }
            return OpreationResult<ChannelViewModel>.Init(OpreationResuleType.QueryNull, null, "频道不存在");
        }
    }
}
