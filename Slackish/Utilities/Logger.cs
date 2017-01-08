
using Microsoft.Practices.Unity;
using System;

namespace Slackish.Utilities
{
    public class Logger: ILogger
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly string _name;
        private ILogger[] _loggers;

        [InjectionConstructor]
        public Logger()
        {

        }

        public Logger(LoggerFactory loggerFactory, string categoryName)
        {
            _loggerFactory = loggerFactory;
            _name = categoryName;

            var providers = loggerFactory.GetProviders();
            if (providers.Count > 0)
            {
                _loggers = new ILogger[providers.Count];
                for (var index = 0; index < providers.Count; index++)
                {
                    _loggers[index] = providers[index].CreateLogger(categoryName);
                }
            }
        }

        public void AddProvider(ILoggerProvider provider)
        {
            var logger = provider.CreateLogger(_name);
            int logIndex;
            if (_loggers == null)
            {
                logIndex = 0;
                _loggers = new ILogger[1];
            }
            else
            {
                logIndex = _loggers.Length;
                Array.Resize(ref _loggers, logIndex + 1);
            }
            _loggers[logIndex] = logger;
        }
    }


}
