using Hesint.Core.Mapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper.Mappers;
using AutoMapper;
using AutoMapper.Configuration;

namespace Hesint.AutoMapper
{
    public static class ServiceRegistor
    {
        public static void AddAutoMapperServices(this IServiceCollection services)
        {
            services.AddSingleton<IAutoMapperConfig, AutoMapperService>();
            services.AddSingleton<IMapperConfigurationExpression, MapperConfigurationExpression>();
            services.AddSingleton<IMapperConfig, AutoMapperConfig>();//注册对象映射服务
        }
    }
}
