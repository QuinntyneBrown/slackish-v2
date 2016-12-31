using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Slackish.Filters
{
    public class WebApiUnityActionFilterProvider : ActionDescriptorFilterProvider, IFilterProvider
    {
        private readonly IUnityContainer _container;

        public WebApiUnityActionFilterProvider(IUnityContainer container)
        {
            _container = container;
        }

        public new IEnumerable<FilterInfo> GetFilters(HttpConfiguration configuration, HttpActionDescriptor actionDescriptor)
        {
            var filters = base.GetFilters(configuration, actionDescriptor);
            var filterInfoList = new List<FilterInfo>();

            foreach (var filter in filters)
            {
                _container.BuildUp(filter.Instance.GetType(), filter.Instance);
            }

            return filters;
        }

        public static void RegisterFilterProviders(HttpConfiguration config)
        {
            var providers = config.Services.GetFilterProviders().ToList();
            config.Services.Add(typeof(System.Web.Http.Filters.IFilterProvider), new WebApiUnityActionFilterProvider(UnityConfiguration.GetContainer()));
            var defaultprovider = providers.First(p => p is ActionDescriptorFilterProvider);
            config.Services.Remove(typeof(System.Web.Http.Filters.IFilterProvider), defaultprovider);
        }
    }
}
