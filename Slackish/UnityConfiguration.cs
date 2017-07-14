using Slackish.Security;
using Slackish.Data;
using Slackish.Features.Core;

using Microsoft.Practices.Unity;
using MediatR;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Slackish
{
    public class UnityConfiguration
    {
        public static IUnityContainer GetContainer()
        {
            var container = new UnityContainer();
            container.AddMediator<UnityConfiguration>();
            container.RegisterType<HttpClient>(
                new ContainerControlledLifetimeManager(),
                new InjectionFactory(x => new HttpClient()));
            container.RegisterInstance(AuthConfiguration.LazyConfig);
            container.RegisterType<SlackishContext>(new ContainerControlledLifetimeManager());
            container.RegisterInstance(AuthConfiguration.LazyConfig);
            container.RegisterInstance(MemoryCache.Current, new ContainerControlledLifetimeManager());
            return container;
        }
    }

    public static class UnityContainerExtension
    {

        public static IUnityContainer AddMediator<T>(this IUnityContainer container)
        {
            var classes = AllClasses.FromAssemblies(typeof(T).Assembly)
                .Where(x => x.Name.Contains("Controller") == false
                && x.Name.EndsWith("Attribute") == false
                && x.Name.EndsWith("Hub") == false
                && x.FullName.Contains("Data.Model") == false)
                .ToList();

            return container.RegisterClassesTypesAndInstances(classes);
        }

        public static IUnityContainer AddMediator<T1, T2>(this IUnityContainer container)
        {
            var classes = AllClasses.FromAssemblies(typeof(T1).Assembly)
                .Where(x => x.Name.Contains("Controller") == false
                && x.Name.Contains("Attribute") == false
                && x.FullName.Contains("Data.Model") == false)
                .ToList();

            classes.AddRange(AllClasses.FromAssemblies(typeof(T2).Assembly)
                .Where(x => x.Name.Contains("Controller") == false
                && x.FullName.Contains("Data.Model") == false)
                .ToList());

            return container.RegisterClassesTypesAndInstances(classes);
        }

        public static IUnityContainer RegisterClassesTypesAndInstances(this IUnityContainer container, IList<Type> classes)
        {
            container.RegisterClasses(classes);
            container.RegisterType<IMediator, Mediator>();
            container.RegisterInstance<SingleInstanceFactory>(t => container.IsRegistered(t) ? container.Resolve(t) : null);
            container.RegisterInstance<MultiInstanceFactory>(t => container.ResolveAll(t));
            return container;
        }

        public static void RegisterClasses(this IUnityContainer container, IList<Type> types)
            => container.RegisterTypes(types, WithMappings.FromAllInterfaces, container.GetName, container.GetLifetimeManager);

        public static bool IsNotificationHandler(this IUnityContainer container, Type type)
            => type.GetInterfaces().Any(x => x.IsGenericType && (x.GetGenericTypeDefinition() == typeof(INotificationHandler<>) || x.GetGenericTypeDefinition() == typeof(IAsyncNotificationHandler<>)));

        public static LifetimeManager GetLifetimeManager(this IUnityContainer container, Type type)
            => container.IsNotificationHandler(type) ? new ContainerControlledLifetimeManager() : null;

        public static string GetName(this IUnityContainer container, Type type)
            => container.IsNotificationHandler(type) ? string.Format("HandlerFor" + type.Name) : string.Empty;
    }
}
