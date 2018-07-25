using System;
using Hesint.Core.Mapper;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using AutoMapper.Configuration;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Hesint.AutoMapper
{
    public class AutoMapperService : IAutoMapperConfig
    {
        public TTarget MapTo<TSource, TTarget>(TSource source, TTarget target)
        {
            //return new Mapper()
            return default(TTarget);
        }

        public TTarget MapTo<TTarget, TSoucre>(TSoucre soucre)
        {
            return Mapper.Map<TSoucre, TTarget>(soucre);
        }
    }
}
