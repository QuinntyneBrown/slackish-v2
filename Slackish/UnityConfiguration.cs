using Slackish.Security;
using Slackish.Data;
using Slackish.Features.Core;

using Microsoft.Practices.Unity;
using MediatR;
using System.Linq;
using System;

namespace Slackish
{
    public class UnityConfiguration
    {
        public static IUnityContainer GetContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<SlackishContext>(new ContainerControlledLifetimeManager());
            container.RegisterType<ILoggerFactory, LoggerFactory>();            
            container.RegisterType<IEncryptionService, EncryptionService>();
            container.RegisterType<ILogger, Logger>();
            container.RegisterType<IMediator, Mediator>();
            container.RegisterInstance<SingleInstanceFactory>(t => container.Resolve(t));
            container.RegisterInstance<MultiInstanceFactory>(t => container.ResolveAll(t));
            var classes = AllClasses.FromAssemblies(typeof(UnityConfiguration).Assembly)
                .Where(x => x.Name.Contains("Controller") == false
                && x.Name.EndsWith("Attribute") == false
                && x.Name.EndsWith("Hub") == false
                && x.FullName.Contains("Data.Model") == false)
                .ToList();

            container.RegisterTypes(classes, WithMappings.FromAllInterfaces, GetName, GetLifetimeManager);
            
            container.RegisterInstance(AuthConfiguration.LazyConfig);
            container.RegisterInstance(MemoryCache.Current, new ContainerControlledLifetimeManager());         
            return container;
        }

        static bool IsNotificationHandler(Type type)
        {
            return type.GetInterfaces().Any(x => x.IsGenericType && (x.GetGenericTypeDefinition() == typeof(INotificationHandler<>) || x.GetGenericTypeDefinition() == typeof(IAsyncNotificationHandler<>)));
        }

        static LifetimeManager GetLifetimeManager(Type type)
        {
            return IsNotificationHandler(type) ? new ContainerControlledLifetimeManager() : null;
        }

        static string GetName(Type type)
        {
            return IsNotificationHandler(type) ? string.Format("HandlerFor" + type.Name) : string.Empty;
        }
    }
}
