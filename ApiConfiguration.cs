using MediatR;
using Microsoft.Owin.Cors;
using Microsoft.Practices.Unity;
using Microsoft.Owin.Security.OAuth;
using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using Slackish.Security;
using Slackish.Features.Core;
using Swashbuckle.Application;
using System;
using System.Web.Http;

using static Slackish.Features.Core.WebApiUnityActionFilterProvider;
using Microsoft.AspNet.SignalR;

namespace Slackish
{
    public class ApiConfiguration
    {
        public static void Install(HttpConfiguration config, IAppBuilder app)
        {
            RegisterFilterProviders(config);
            var container = UnityConfiguration.GetContainer();

            var unityHubActivator = new UnityHubActivator(container);
            Microsoft.AspNet.SignalR.GlobalHost.DependencyResolver.Register(typeof(IHubActivator), () => unityHubActivator);
            Microsoft.AspNet.SignalR.GlobalHost.DependencyResolver.Register(typeof(IUserIdProvider), () => new UserIdProvider());

            app.MapSignalR();
            app.Use(typeof(TenantMiddleware));

            config.Filters.Add(container.Resolve<HandleErrorAttribute>());
            config.Filters.Add(container.Resolve<System.Web.Http.AuthorizeAttribute>());

            app.UseCors(CorsOptions.AllowAll);

            config.SuppressHostPrincipal();

            var mediator = container.Resolve<IMediator>();
            var lazyAuthConfiguration = container.Resolve<Lazy<IAuthConfiguration>>();

            config
                .EnableSwagger(c => c.SingleApiVersion("v1", "Slackish"))
                .EnableSwaggerUi();

            app.UseOAuthAuthorizationServer(new OAuthOptions(lazyAuthConfiguration, mediator));

            app.UseJwtBearerAuthentication(new JwtOptions(lazyAuthConfiguration));

            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            var jSettings = new JsonSerializerSettings();
            jSettings.Formatting = Formatting.Indented;
			jSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            jSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings = jSettings;
            config.MapHttpAttributeRoutes();
        }
    }
}
