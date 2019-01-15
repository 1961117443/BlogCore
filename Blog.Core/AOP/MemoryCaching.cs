using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Core.AOP
{
    public class MemoryCaching : ICaching
    {
        private readonly IMemoryCache _cache;
        
        public MemoryCaching(IMemoryCache caching)
        {
            _cache = caching;
        }
        public object Get(string cacheKey)
        {
            return _cache.Get(cacheKey);
        }

        public void Set(string cacheKey, object cacheValue)
        {
            _cache.Set(cacheKey, cacheValue);
        }
    }
}
