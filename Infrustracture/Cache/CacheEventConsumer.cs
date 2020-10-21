using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HanifStore.Infrustracture.Cache
{
    public class CacheEventConsumer
    {
        private readonly IMemoryCache _memoryCache;
        public CacheEventConsumer(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public static string productCachePrefixKey => "public.product";
        public static string getProductByCategoryKey => "public.product-{0}-{1}";
        public static string getProductsModelByCategoryKey => "public.product-{1}-{0}";

        public void ClearCache()
        {
            _memoryCache.Dispose();
        }
    }
}
