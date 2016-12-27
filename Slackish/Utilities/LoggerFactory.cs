using System;
using System.Collections.Generic;
using System.Linq;

namespace Slackish.Utilities
{
    public class LoggerFactory: ILoggerFactory
    {
        private readonly Dictionary<string, ILogger> _loggers = new Dictionary<string, ILogger>(StringComparer.Ordinal);
        private readonly object _sync = new object();
        private ILoggerProvider[] _providers = new ILoggerProvider[0];

        public ILogger CreateLogger(string categoryName)
        {
            ILogger logger;

            lock (_sync)
            {
                if (!_loggers.TryGetValue(categoryName, out logger))
                {
                    logger = new Logger(this, categoryName);
                    _loggers[categoryName] = logger;
                }
            }
            return logger;
        }

        public void AddProvider(ILoggerProvider provider)
        {
            lock (_sync)
            {
                _providers = _providers.Concat(new[] { provider }).ToArray();
                foreach (var logger in _loggers)
                {
                    logger.Value.AddProvider(provider);
                }
            }
        }
        public List<ILoggerProvider> GetProviders() => _providers.ToList();
    }
}
