using System;
using System.Collections.Generic;
using System.Text;

namespace Hesint.Core.Mapper
{
    public interface IMapperConfig
    {
        /// <summary>
        /// 创建对象映射
        /// </summary>
        /// <typeparam name="TSource">源类型</typeparam>
        /// <typeparam name="TTarget">目标类型</typeparam>
        void CreateMapper<TSource,TTarget>();

        void InitMapper();
    }
}
