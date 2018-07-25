using Hesint.Lib.Models.ResultModel;
using System;

namespace Hesint.Core.Cache
{
    public interface ICache
    {
        /// <summary>
        /// 清空所有缓存
        /// </summary>
        /// <returns></returns>
        [Obsolete("此方法在未来版本中加入，暂不可用",true)]
        OpreationResult Clear();

        /// <summary>
        /// 清空指定键的缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        OpreationResult Clear(string key);
        
        /// <summary>
        /// 更新指定键的缓存
        /// </summary>
        /// <typeparam name="T">更新后的数据</typeparam>
        /// <param name="key">键</param>
        /// <returns></returns>
        OpreationResult Update<T>(T obj,string key);

        /// <summary>
        /// 更新指定键的缓存，重新指定过期时间
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="key"></param>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        OpreationResult Update<T>(T obj, string key, TimeSpan timeSpan);

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        OpreationResult Set<T>(T obj, string key);

        /// <summary>
        /// 设置缓存过期时间，并且指定
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="key"></param>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        OpreationResult Set<T>(T obj, string key, TimeSpan timeSpan);

        /// <summary>
        /// 根据键获取一个缓存的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        OpreationResult<T> Get<T>(string key) where T : class;
    }
}
