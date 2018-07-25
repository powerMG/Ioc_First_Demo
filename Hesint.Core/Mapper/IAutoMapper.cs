using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hesint.Core.Mapper
{
    public interface IAutoMapperConfig
    {
        /// <summary>
        /// 把对象映射到目标类型
        /// </summary>
        /// <typeparam name="Target">要映射的目标类型</typeparam>
        /// <param name="soucre">源对象</param>
        /// <returns>目标类型对象</returns>
        TTarget MapTo<TTarget,TSoucre>(TSoucre soucre);

        /// <summary>
        /// 使用源类型的对象更新目标类型的对象
        /// </summary>
        /// <typeparam name="TSource">源类型</typeparam>
        /// <typeparam name="TTarget">目标类型</typeparam>
        /// <param name="source">源对象</param>
        /// <param name="target">待更新的目标对象</param>
        /// <returns>更新后的目标类型对象</returns>
        TTarget MapTo<TSource, TTarget>(TSource source, TTarget target);
    }
}
