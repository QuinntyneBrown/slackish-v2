using System;
using System.Runtime.Caching;

namespace Slackish.Services
{
    public class MemoryCache : Cache
    {
        private static volatile Slackish.Services.MemoryCache _current = null;
        private static System.Runtime.Caching.MemoryCache _cache = System.Runtime.Caching.MemoryCache.Default;
        private static object _sync = new object();

        public static MemoryCache Current
        {
            get
            {
                if (_current == null)
                    _current = new MemoryCache();
                return _current;
            }
        }

        public override T Get<T>(string key) => (T)Get(key);

        public override object Get(string key) {
            lock (_sync)
            {
                return _cache.Contains(key) ? _cache.Get(key) : null;
            }
        }

        public override void Add(object objectToCache, string key)
        {
            if (objectToCache == null)
            {
                _cache.Remove(key);
            }
            else
            {
                _cache[key] = objectToCache;
            }
        }

        public override void Add<T>(object objectToCache, string key) => Add(objectToCache, key);

        public override void Add<T>(object objectToCache, string key, double cacheDuration)
        {
            if (objectToCache == null) {
                _cache.Remove(key);
            }
            else
            {
                _cache.Add(new CacheItem(key, objectToCache), new CacheItemPolicy()
                { AbsoluteExpiration = DateTime.Now.AddMinutes(cacheDuration) });
            }
        }

        public override void Remove(string key) => _cache.Remove(key);

        public override void ClearAll()
        {
            _cache.Dispose();
            _cache = System.Runtime.Caching.MemoryCache.Default;
        }

        public override bool Exists(string key) => _cache.Contains(key);
    }
}
