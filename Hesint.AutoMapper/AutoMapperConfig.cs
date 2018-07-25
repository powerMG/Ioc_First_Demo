using AutoMapper;
using AutoMapper.Configuration;
using Hesint.Core.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hesint.AutoMapper
{
    public class AutoMapperConfig : IMapperConfig
    {
        private IMapperConfigurationExpression _config;
        public AutoMapperConfig(IMapperConfigurationExpression config)
        {
            _config = config;
        }

        public void CreateMapper<TSource, TTarget>()
        {
            _config.CreateMap<TSource, TTarget>();
        }

        public void InitMapper()
        {
            Mapper.Initialize((MapperConfigurationExpression)_config);
        }

    }
}
