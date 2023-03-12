using StoreStats.Data.Models;
using StoreStats.Data.Services;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace StoreStats.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IStoreStatsDbContext, StoreStatsDbContext>();
            container.RegisterType<IStatisticsService, StatisticsService>();
            container.RegisterType<IStoresService, StoresService>();
            container.RegisterType<IEntriesService, EntriesService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}