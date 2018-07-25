using Hesint.Core.Cache;
using Hesint.Lib.Models.ResultModel;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace Hesint.Cache
{
    public class CacheManager : ICache
    {
        private IMemoryCache cache;
        public CacheManager(IMemoryCache cache)
        {
            this.cache = cache;
        }
        public OpreationResult Clear()
        {
            return null;
        }

        public OpreationResult Clear(string key)
        {
            try
            {
                cache.Remove(key);
                return OpreationResult.Init(OpreationResuleType.Success);
            }catch(Exception e)
            {
                return OpreationResult.Init(OpreationResuleType.Error, e.Message);
            }
        }

        public OpreationResult<T> Get<T>(string key) where T : class
        {
            try
            {
                var result= cache.Get(key);
                return OpreationResult<T>.Init(OpreationResuleType.Success, (T)result);
            }
            catch(Exception e)
            {
                return OpreationResult<T>.Init(OpreationResuleType.Error, default(T), e.Message);
            }
        }

        public OpreationResult Set<T>(T obj, string key)
        {
            try
            {
                var result = cache.Set<T>(key, obj);
                return OpreationResult.Init(OpreationResuleType.Success);
            }
            catch(Exception e)
            {
                return OpreationResult.Init(OpreationResuleType.Error,e.Message);
            }
        }

        public OpreationResult Set<T>(T obj, string key, TimeSpan timeSpan)
        {
            try
            {
                var result = cache.Set<T>(key, obj, timeSpan);
                return OpreationResult.Init(OpreationResuleType.Success);
            }
            catch(Exception e)
            {
                return OpreationResult.Init(OpreationResuleType.Error, e.Message);
            }
        }

        public OpreationResult Update<T>(T obj, string key)
        {
            try
            {
                cache.Remove(key);
                cache.Set<T>(key, obj);
                return OpreationResult.Init(OpreationResuleType.Success);
            }
            catch(Exception e)
            {
                return OpreationResult.Init(OpreationResuleType.Error, e.Message);
            }
        }

        public OpreationResult Update<T>(T obj, string key, TimeSpan timeSpan)
        {
            try
            {
                cache.Remove(key);
                cache.Set<T>(key, obj, timeSpan);
                return OpreationResult.Init(OpreationResuleType.Success);
            }
            catch(Exception e)
            {
                return OpreationResult.Init(OpreationResuleType.Error, e.Message);
            }
        }
    }
}
