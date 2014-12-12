using Castle.Core;
using Castle.Windsor;
using NHibernate.Cfg;

namespace PackageBuilder.TestHelper
{
    public class OverrideHelper
    {
        /// <summary>
        /// Override the LifestyleType of LifestylePerWebRequest to avoid exception below:
        /// 
        /// Castle.MicroKernel.ComponentResolutionException
        /// Looks like you forgot to register the http module Castle.MicroKernel.Lifestyle.PerWebRequestLifestyleModule
        /// To fix this add
        /// <add name="PerRequestLifestyle" type="Castle.MicroKernel.Lifestyle.PerWebRequestLifestyleModule, Castle.Windsor" />
        /// to the <httpModules> section on your web.config.
        /// If you plan running on IIS in Integrated Pipeline mode, you also need to add the module to the <modules> section under <system.webServer>.
        /// Alternatively make sure you have Microsoft.Web.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35 assembly in your GAC (it is installed by ASP.NET MVC3 or WebMatrix) and Windsor will be able to register the module automatically without having to add anything to the config file.
        /// </summary>
        /// <param name="model"></param>
        public static void OverrideContainerLifestyle(ComponentModel model)
        {
            if (model.LifestyleType == LifestyleType.Undefined)
                model.LifestyleType = LifestyleType.Transient;

            if (model.LifestyleType == LifestyleType.PerWebRequest)
                model.LifestyleType = LifestyleType.Transient;
        }

        public static void OverrideNhibernateCfg(IWindsorContainer container)
        {
            var configuration = container.Resolve<Configuration>();
            configuration.SetProperty("cache.provider_class", "NHibernate.Cache.NoCacheProvider, NHibernate.Cache");
            configuration.SetProperty("cache.use_second_level_cache", "false");
            configuration.SetProperty("cache.use_query_cache", "false");
            configuration.SetProperty("current_session_context_class", "thread_static");
        }
    }
}