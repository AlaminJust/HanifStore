using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Infrustracture.Cache
{
    public class CacheEventConsumer
    {
        private readonly IMemoryCache _memoryCache;

        public static string productCachePrefixKey => "public.product";
        public static string getProductByCategoryKey => "public.product-{0}-{1}";
        public static string getProductsModelByCategoryKey => "public.product-{1}-{0}";
        public CacheEventConsumer
            (
                IMemoryCache memoryCache
            )
        {
            _memoryCache = memoryCache;
        }
        public static void ClearCache()
        {
            var cacheItems = new MemoryCache(new MemoryCacheOptions());
            cacheItems.Dispose();
        }
    }
}
