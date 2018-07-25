using AutoMapper;
using Core.Contract;
using Core.InputModel;
using Core.ViewModel;
using EntityFramework;
using Hesint.Core.Mapper;
using Hesint.Lib.Models.ResultModel;
using Hesint.Lib.Security;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    /// <summary>
    /// 管理员信息
    /// 为开发民教网版本所提供
    /// </summary>

    public class AdministratorService : IAdministrator
    {
        private DbContext db;
        private IAutoMapperConfig mapper;
        public AdministratorService(TreeDbContext db, IAutoMapperConfig mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<OpreationResult> CreateOrUpdate(AdministratorDto dto)
        {
            if (dto.Id.HasValue)
            {
                var dbAdmin = await db.Set<Administrator>().Where(a => a.Id == dto.Id).FirstOrDefaultAsync();
                dbAdmin.LastLoginIp = dto.LastLoginIp;
                dbAdmin.LastLoginTime = dto.LastLoginTime;
                dbAdmin.LoginName = dto.LoginName;
                if (!string.IsNullOrEmpty(dto.Password))
                {
                    dbAdmin.Password = dto.Password;
                }
                db.Set<Administrator>().Update(dbAdmin);
            }
            else
            {
                var dbAdmin = mapper.MapTo<Administrator, AdministratorDto>(dto);
                await db.Set<Administrator>().AddAsync(dbAdmin);
            }
            var saveResult = await db.SaveChangesAsync();
            return saveResult > 0 ? OpreationResult.Init(OpreationResuleType.Success) : OpreationResult.Init(OpreationResuleType.Error);
        }

        public async Task<OpreationResult<Administrator>> LoginAsync(AdminLoginViewModel model)
        {
            var dbAdmin = await db.Set<Administrator>().Where(a => a.LoginName == model.LoginName).AsNoTracking().FirstOrDefaultAsync();
            if (dbAdmin == null)
            {
                return OpreationResult<Administrator>.Init(OpreationResuleType.QueryNull,null ,"用户不存在");
            }
            if (dbAdmin.Password != SHA.SHA512(model.Password).ToLower())
            {
                return OpreationResult<Administrator>.Init(OpreationResuleType.ValidtorError,null, "您的密码不正确");
            }
            var updateModel = new AdministratorDto()
            {
                Id = dbAdmin.Id,
                LastLoginIp = model.LastLoginIp,
                LastLoginTime = DateTime.Now,
                Password = dbAdmin.Password,
                LoginName = dbAdmin.LoginName
            };
            await CreateOrUpdate(updateModel);
            dbAdmin.Password = null;
            return OpreationResult<Administrator>.Init(OpreationResuleType.Success, dbAdmin);
        }
    }
}
