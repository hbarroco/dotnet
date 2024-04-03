using school_route.infrastructure.Log;
using school_route.services;

namespace school_route.api.Utils
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {            
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddSingleton<ILoggerManager, LoggerManager>();
            ServicesIoCRegistration.AddServiceInfrastructure(services);
        }
    }
}
