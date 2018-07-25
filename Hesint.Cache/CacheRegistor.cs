using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Caching.Memory;
using Hesint.Core.Cache;

namespace Hesint.Cache
{
    public static class CacheRegistor
    {
        public static void AddCache(this IServiceCollection service)
        {
            service.AddMemoryCache();
            service.AddScoped<ICache, CacheManager>();
        }
    }
}
